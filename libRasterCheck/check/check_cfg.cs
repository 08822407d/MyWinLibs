using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using OSGeo.GDAL;

namespace geodata
{
	public enum TaskType
	{
		CNSimg,
		DEM,
		ImgSrc,
	}


	/// <summary>
	/// 程序配置参数，主要是和各参数类相关的内容
	/// </summary>
	public class ProgramCfg
	{
		public string Last_Tcfg { get; set; }
		public string AutoChk_OPath { get; set; }

		public string Citms_path { get; set; }
		public string Tcfgs_path { get; set; }

		public string DataFile_Ext { get; set; }

		public ProgramCfg()
		{
			Last_Tcfg = "";
			AutoChk_OPath = "";

			Citms_path = "";
			Tcfgs_path = "";

			DataFile_Ext = "tif,tiff,img,image";
		}
	}

	/// <summary>
	/// 检查项所需的配置参数
	/// </summary>
	public class TaskCfg
	{
		public bool isChanged { get; set; }

		public TaskType	TskType { get; set; }

		/// <summary>
		/// 数学基础
		/// </summary>
		//	投影系
		public ProjSystem	PrjSys { get; set; }
		// 半长轴
		public double	SemiMajor { get; set; }
		// 扁率
		public double	InvFlatt { get; set; }
		// 长度变形比
		public double	ScaleFactor { get; set; }
		// 中央经线
		public int		CentralMeridian { get; set; }
		// 坐标东移
		public double	FalseEast { get; set; }
		// 坐标北移
		public double	FalseNorth { get; set; }

		/// <summary>
		/// 数据质量
		/// </summary>
		// 影像位深度
		public DataType	Depth { get; set; }
		// 影像波段数
		public uint		BandCount { get; set; }
		// 分辨率
		public double	Resolution { get; set; }
		// DPI
		public uint		DPI { get; set; }
		// 块尺寸
		public int		BlkSize { get; set; }
		// 外扩范围(单位像素)
		public uint		ClipExtent { get; set; }
		// 外扩公式
		public ClipExtFormula	ExtFormula { get; set; }
		// 无数据区值
		public double[]	NoData { get; set; }
		// 噪音值
		public int[]	Noise { get; set; }

		/// <summary>
		/// 限差
		/// </summary>
		public double	PositionDiffTolarence { get; set; }
		public double	HeightDiffTolarence { get; set; }

		/// <summary>
		/// 附加文件设置
		/// </summary>
		// TFW文件小数位数
		public int		TFWPrec { get; set; }


		public TaskCfg()
		{
			isChanged = false;

			TskType = TaskType.CNSimg;

			PrjSys = ProjSystem.wgs84;
			SemiMajor = 6378137.0;
			InvFlatt = 298.257223563;
			ScaleFactor = 0.9996;
			CentralMeridian = 99;
			FalseEast = 500000.0;
			FalseNorth = 0.0;


			Depth = DataType.GDT_Byte;
			BandCount = 3;
			Resolution = 1;
			DPI = 96;
			BlkSize = 256;
			ClipExtent = 0;
			ExtFormula = ClipExtFormula.NewFormula;
			NoData = new double[] { 0.0, 0.0, 0.0};
			Noise = new int[] { 255, 255, 255};

			PositionDiffTolarence = 0.0;
			HeightDiffTolarence = 0.0;

			TFWPrec = 2;
		}

		public TaskCfg(TaskCfg tc)
		{
			this.isChanged = tc.isChanged;

			this.TskType = tc.TskType;

			this.PrjSys = tc.PrjSys;
			this.SemiMajor = tc.SemiMajor;
			this.InvFlatt = tc.InvFlatt;
			this.ScaleFactor = tc.ScaleFactor;
			this.CentralMeridian = tc.CentralMeridian;
			this.FalseEast = tc.FalseEast;
			this.FalseNorth = tc.FalseNorth;


			this.Depth = tc.Depth;
			this.BandCount = tc.BandCount;
			this.Resolution = tc.Resolution;
			this.DPI = tc.DPI;
			this.ClipExtent = tc.ClipExtent;
			this.BlkSize = tc.BlkSize;
			this.ExtFormula = tc.ExtFormula;
			this.NoData = tc.NoData;

			this.PositionDiffTolarence = tc.PositionDiffTolarence;
			this.HeightDiffTolarence = tc.HeightDiffTolarence;

			this.TFWPrec = tc.TFWPrec;
		}

		public TaskCfg(TaskType TskType, ProjSystem PrjSys, double SemiMajor, double InvFlatt,
							double ScaleFactor, int CentMerid, double FalseEast, double FalseNorth,
							DataType Depth, uint BandCount, double Resol, uint DPI, int BlkSize, uint ClipExt,
							ClipExtFormula ExtFormu, double[] Nodata, int[] Noise,
							double PosDiffTolarence, double HeighDiffTolarence,
							int tfwPrec)
		{
			this.isChanged = false;

			this.TskType = TskType;

			this.PrjSys = PrjSys;
			this.SemiMajor = SemiMajor;
			this.InvFlatt = InvFlatt;
			this.ScaleFactor = ScaleFactor;
			this.CentralMeridian = CentMerid;
			this.FalseEast = FalseEast;
			this.FalseNorth = FalseNorth;


			this.Depth = Depth;
			this.BandCount = BandCount;
			this.Resolution = Resol;
			this.DPI = DPI;
			this.ClipExtent = ClipExt;
			this.BlkSize = BlkSize;
			this.ExtFormula = ExtFormu;
			this.NoData = NoData;
			this.Noise = Noise;

			this.PositionDiffTolarence = PosDiffTolarence;
			this.HeightDiffTolarence = HeightDiffTolarence;

			this.TFWPrec = tfwPrec;
		}
	}

	/// <summary>
	/// 要执行的检查项
	/// </summary>
	public class CheckItem
	{
		/// <summary>
		/// 通用项目
		/// </summary>
		// 包含投影系，扁率，半长轴，变形比
		public bool PrjSys { get; set; }
		// 包含中央经线，坐标偏移
		public bool PrjOther { get; set; }
		// 色彩模式，包含波段数，位深度
		public bool ColorMode { get; set; }
		// 影像信息，包含分辨率，起点坐标
		public bool DataInfo { get; set; }
		// 裁切范围
		public bool ClipExt { get; set; }


		/// <summary>
		/// 影像专有
		/// </summary>
		// 影像噪音
		public bool ImgNoise { get; set; }
		// 影像接边
		public bool ImgEdgeMatch { get; set; }


		/// <summary>
		/// DEM专有项
		/// </summary>
		// 检测点高程精度
		public bool DemChkPoint { get; set; }
		// DEM/DSM接边
		public bool DemEdgeMatch { get; set; }
		// 全球测图特殊项目
		public bool GlobalMappingItems { get; set; }


		// TFW小数位
		public bool OtherFile { get; set; }

		// 文件组织
		public bool DataOrganize { get; set; }

		public CheckItem()
		{
			Clear();
		}

		public void Clear()
		{
			PrjSys = false;
			PrjOther = false;
			ColorMode = false;
			DataInfo = false;


			ImgNoise = false;
			ImgEdgeMatch = false;


			DemChkPoint = false;
			DemEdgeMatch = false;
			GlobalMappingItems = false;

			OtherFile = false;
			
			DataOrganize = false;
		}

		public override string ToString()
		{
			string retval = "\n";
			if (this.PrjSys)
				retval += "投影系参数\n";
			if (this.PrjOther)
				retval += "其他投影参数\n";
			if (this.ColorMode)
				retval += "色彩模式\n";
			if (this.DataInfo)
				retval += "其他数据信息\n";

			if (this.ImgNoise)
				retval += "影像噪声\n";
			if (this.ImgEdgeMatch)
				retval += "影像接边\n";

			if (this.DemChkPoint)
				retval += "高程监测点\n";
			if (this.DemEdgeMatch)
				retval += "DEM高程接边\n";
			if (this.GlobalMappingItems)
				retval += "全球测图专属项目\n";

			if (this.OtherFile)
				retval += "TFW小数位\n";

			if (this.DataOrganize)
				retval += "数据组织\n";

			return retval;
		}
	}

	/// <summary>
	/// 所有的参数都存储在这里，该类同时负责读取和写入配置文件
	/// </summary>
	public class CfgPack
	{
		const string cfgfile_dir = "./configs/";
		const string default_Pcfg_path = cfgfile_dir + "ProgCfg.json";
		const string default_Citm_path = cfgfile_dir + "ChkItems.json";
		const string default_Tcfgs_path = cfgfile_dir + "TaskCfgs.json";
		const string default_TCname = "default";


		public int TCcount { get { return Tcfgs.Count; }}
		public int Tcachecount { get { return Tcache.Count; } }
		public string[] TCkeys { get { return Tcache.Keys.ToArray(); } }


		private string PCpath;
		private ProgramCfg Pcfg;
		private CheckItem Citm;
		private Dictionary<string, TaskCfg> Tcfgs;
		private Dictionary<string, TaskCfg> Tcache;


		public CfgPack(string pc_path = default_Pcfg_path)
		{
			if (!Directory.Exists(cfgfile_dir))
				Directory.CreateDirectory(cfgfile_dir);

			Pcfg = new ProgramCfg();
			Citm = new CheckItem();
			Tcfgs = new Dictionary<string, TaskCfg>();
			Tcache = new Dictionary<string, TaskCfg>();

			this.PCpath = pc_path;
			reloadSelf();

			flushTC();
			flushPC();
			flushCI();

			reloadSelf();
		}
		public void reloadSelf()
		{
			openPCfile();
			openCIfile();
			openTCfile();

			Tcache = new Dictionary<string, TaskCfg>(Tcfgs);
		}
		private void openTCfile()
		{
			string TC_path = Pcfg.Tcfgs_path;
			// 清空现有项，每次任务配置都从json文件中加载
			Tcfgs.Clear();
			// 防止json文件不存在
			if (!File.Exists(TC_path))
			{
				FileStream fs;
				try
				{
					fs = File.Create(TC_path);
				}
				catch
				{
					fs = File.Create(default_Tcfgs_path);
				}
				fs.Close();
			}
			// 读取json字符串
			StreamReader sr = new StreamReader(TC_path);
			string jsonstr = sr.ReadLine();
			sr.Close();
			// 解析json
			if (jsonstr != null && !jsonstr.Equals(""))
				Tcfgs = JsonSerializer.Deserialize<Dictionary<string, TaskCfg>>(jsonstr);
			// 当json为空时创建默认项目配置模板
			if (Tcfgs.Count == 0)
				addTC(default_TCname, new TaskCfg());
		}
		private void openCIfile()
		{
			string CI_path = Pcfg.Citms_path;
			// 清空现有项，每次任务配置都从json文件中加载
			Citm.Clear();
			// 防止json文件不存在
			if (!File.Exists(CI_path))
			{
				FileStream fs;
				try
				{
					fs = File.Create(CI_path);
				}
				catch
				{
					fs = File.Create(default_Citm_path);
				}
				fs.Close();
			}
			// 读取json字符串
			StreamReader sr = new StreamReader(CI_path);
			string jsonstr = sr.ReadLine();
			sr.Close();
			// 解析json
			if (jsonstr != null && !jsonstr.Equals(""))
				Citm = JsonSerializer.Deserialize<CheckItem>(jsonstr);
		}
		private void openPCfile()
		{
			if (!File.Exists(this.PCpath))
			{
				FileStream fs;
				try
				{
					fs = File.Create(this.PCpath);
				}
				catch
				{
					fs = File.Create(default_Pcfg_path);
				}
				fs.Close();
			}
			StreamReader sr = new StreamReader(this.PCpath);
			string jsonstr = sr.ReadLine();
			sr.Close();

			if (jsonstr != null)
				Pcfg = JsonSerializer.Deserialize<ProgramCfg>(jsonstr);

			if (Pcfg.Last_Tcfg == null || Pcfg.Last_Tcfg.Equals(""))
				setLastTCname(default_TCname);

			if (Pcfg.Citms_path == null || Pcfg.Citms_path.Equals(""))
				Pcfg.Citms_path = default_Citm_path;

			if (Pcfg.Tcfgs_path == null || Pcfg.Tcfgs_path.Equals(""))
				Pcfg.Tcfgs_path = default_Tcfgs_path;
		}


		// 程序配置参数相关
		public string getDataFileExt()
		{
			return Pcfg.DataFile_Ext;
		}
		public string getLastTCname()
		{
			return Pcfg.Last_Tcfg;
		}
		public string getAutoChkOPath()
		{
			return Pcfg.AutoChk_OPath;
		}
		public bool setDataFileExt(string ext)
		{
			Pcfg.DataFile_Ext = ext;

			return true;
		}
		public bool setLastTCname(string ltc)
		{
			if (ltc != null && !ltc.Equals(""))
			{
				Pcfg.Last_Tcfg = ltc;
				return true;
			}
			else
				return false;
		}
		public bool setAutoChkOPath(string acop)
		{
			if (acop != null && !acop.Equals(""))
			{
				Pcfg.AutoChk_OPath = acop;
				return true;
			}
			else
				return false;
		}
		public void flushPC()
		{
			string jsonstr = JsonSerializer.Serialize(Pcfg);

			StreamWriter sw = new StreamWriter(default_Pcfg_path, false);
			sw.WriteLine(jsonstr);
			sw.Flush();
			sw.Close();
		}

		// 检查项模板相关函数
		public CheckItem getChkItems()
		{
			return this.Citm;
		}
		public void setChkItems(CheckItem ci)
		{
			this.Citm = ci;
		}
		public void flushCI()
		{
			string jsonstr = JsonSerializer.Serialize(Citm);

			StreamWriter sw = new StreamWriter(Pcfg.Citms_path, false);
			sw.WriteLine(jsonstr);
			sw.Flush();
			sw.Close();
		}

		// 检查参数模板相关函数
		public bool addTC(string name, TaskCfg cfg)
		{
			bool ret_val = true;

			if (!this.Tcache.ContainsKey(name))
				this.Tcache.Add(name, cfg);
			else
				ret_val = false;

			return ret_val;
		}
		public TaskCfg getTC(string name)
		{
			if (this.Tcache.ContainsKey(name))
				return this.Tcache[name];
			else
				return null;
		}
		public bool removeTC(string name)
		{
			return Tcache.Remove(name);
		}
		public bool getFirstNameTC(ref string name, ref TaskCfg tc)
		{
			if (Tcache.Count < 1)
				return false;
			else
			{
				name = Tcache.Keys.First();
				tc = Tcache[name];
				return true;
			}
		}
		public bool restoreTC(string name)
		{
			if (!Tcache.ContainsKey(name) &&
				Tcfgs.ContainsKey(name))
				return false;
			else if (Tcache.ContainsKey(name))
			{
				Tcache.Remove(name);
				if (Tcfgs.ContainsKey(name))
					Tcache.Add(name, new TaskCfg(Tcfgs[name]));
			}
			return true;
		}
		public int flushTC()
		{
			/* 将缓存更新到存储 */
			Tcfgs = new Dictionary<string, TaskCfg>(Tcache);
			// 然后清除缓存
			Tcache.Clear();
		/* 将存储写入磁盘 */
			string jsonstr = JsonSerializer.Serialize(Tcfgs);
			// 写入json文件,截断方式打开
			StreamWriter sw = new StreamWriter(Pcfg.Tcfgs_path, false);
			sw.WriteLine(jsonstr);
			sw.Flush();
			sw.Close();

			return Tcfgs.Count;
		}
	}
}
