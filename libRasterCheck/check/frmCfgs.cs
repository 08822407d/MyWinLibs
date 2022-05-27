using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utils;

namespace geodata
{
	public partial class frmCfgs : Form
	{
		public CfgPack Cfgs = null;

		string errstr = "";
		string currTCname = null;
		TaskCfg currTC = null;

		int NewExtFormu_idx = 0;
		int OrigExtFormu_idx = 0;
		string NewExtFormu_name = "新公式";
		string OrigExtFormu_name = "原公式";
		string NewExtFormu_str =	"角点像元中心计算公式如下：" + 
									"	X起 = INT[(MAX(X1, X2, X3, X4) + N*d) / d] * d\n" +
									"	Y起 = INT[(MIN(Y1, Y2, Y3, Y4) - N*d) / d] * d\n" +
									"	X止 = INT[(MIN(X1, X2, X3, X4) - N*d) / d] * d\n" +
									"	Y止 = INT[(MAX(Y1, Y2, Y3, Y4) + N*d) / d] * d\n" +
									"其中 N 为外扩像素数，d 为像素地面分辨率";
		string OrigExtFormu_str =	"角点像元中心计算公式如下：" + 
									"	X起 = INT[(MAX(X1, X2, X3, X4) / d + 1] * d + N*d\n" +
									"	Y起 = INT[(MIN(Y1, Y2, Y3, Y4) / d] * d - N*d\n" +
									"	X止 = INT[(MIN(X1, X2, X3, X4) / d] * d - N*d\n" +
									"	Y止 = INT[(MAX(Y1, Y2, Y3, Y4) / d + 1] * d + N*d\n" +
									"其中 N 为外扩像素数，d 为像素地面分辨率";


		public frmCfgs()
		{
			InitializeComponent();
		}
		public frmCfgs(CfgPack cfgs)
		{
			InitializeComponent();
			this.Cfgs = cfgs;

			cmbbx_ExtFormula.Items.Add(NewExtFormu_name);
			cmbbx_ExtFormula.Items.Add(OrigExtFormu_name);
			NewExtFormu_idx = cmbbx_ExtFormula.Items.IndexOf(NewExtFormu_name);
			OrigExtFormu_idx = cmbbx_ExtFormula.Items.IndexOf(OrigExtFormu_name);
			loadTcfgs2cmbbx();

			ci2frm(this.Cfgs.getChkItems());

			tbx_resultPath.Text = this.Cfgs.chkOutput_path;
		}


		private void btn_newCfg_Click(object sender, EventArgs e)
		{
			frmTXTInput wTI = new frmTXTInput();
			wTI.ShowDialog();

			string newName = wTI.ret_val;
			if (newName == null)
			{
				MessageBox.Show("未输入名称, 取消新建配置");
				return;
			}
			else
			{
				this.currTC = new TaskCfg();
				this.currTCname = newName;
				Cfgs.addTcache(this.currTCname, this.currTC);
				cmbbx_tskcfgs.Items.Add(currTCname + " （新建）");

				MessageBox.Show("新建配置:" + currTCname + ", 采用默认配置模板");
			}
		}

		private void btn_saveCurr_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("确定保存当前配置？", "", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;

			// 保存检查参数
			frm2cfg(ref currTC);
			exitErr();
			Cfgs.setLastTskCfg(currTCname);
			Cfgs.addTcache(currTCname, currTC);
			Cfgs.flushPC();
			Cfgs.flushTC();
			loadTcfgs2cmbbx();

			// 保存检查项
			CheckItem ci = Cfgs.getChkItems();
			frm2ci(ref ci);
			Cfgs.setChkItems(ci);
			Cfgs.flushCI();

			MessageBox.Show("已保存当前配置");
		}

		private void btn_deleteCurr_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("确定删除当前配置？", "", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;

			this.Cfgs.removeTC(this.currTCname);
			this.Cfgs.setLastTskCfgByIdx(0);
			this.Cfgs.flushTC();

			loadTcfgs2cmbbx();
		}

		private void btn_resetCurr_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("确定放弃当前更改？", "", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;

			loadTcfgs2cmbbx();
		}

		private void btn_resultPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd =new FolderBrowserDialog();
			fbd.Description = "请选择文件夹";
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string dir = fbd.SelectedPath;
				if (dir != null)
				{
					tbx_resultPath.Text = dir;
					this.Cfgs.chkOutput_path = dir;
				}
			}
		}

		private void cmbbx_tskcfgs_SelectedIndexChanged(object sender, EventArgs e)
		{
			string si = cmbbx_tskcfgs.SelectedItem.ToString();
			TaskCfg tc = Cfgs.getTC(si);
			if (tc != null)
			{
				this.currTCname = si;
				this.currTC = tc;
				cfg2frm(this.currTC);
			}
			else
			{

			}
		}

		private void cmbbx_ExtFormula_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbbx_ExtFormula.SelectedItem.ToString().Equals(NewExtFormu_name))
			{
				this.currTC.ExtFormula = ClipExtFormula.NewFormula;
				rtbx_ExtFormula.Text = NewExtFormu_str;
			}
			else if (cmbbx_ExtFormula.SelectedItem.ToString().Equals(OrigExtFormu_name))
			{
				this.currTC.ExtFormula = ClipExtFormula.OrigFormula;
				rtbx_ExtFormula.Text = OrigExtFormu_str;
			}
		}

		private void exitErr()
		{
			if (!errstr.Equals(""))
				MessageBox.Show(errstr);
		}

		private void loadTcfgs2cmbbx()
		{
			string[] keys = this.Cfgs.getTCNames();
			if (keys.Length < 1)
			{
				MessageBox.Show("未找到现有项目模板，请新建");
				return;
			}
			else
			{
				cmbbx_tskcfgs.Items.Clear();
				foreach (string key in keys)
					cmbbx_tskcfgs.Items.Add(key);
			}

			this.currTCname = this.Cfgs.getLastTskCfg();
			cmbbx_tskcfgs.SelectedItem = currTCname;
			this.currTC = this.Cfgs.getTC(currTCname);
			cfg2frm(this.currTC);
		}

		private void cfg2frm(TaskCfg cfg)
		{
			// 坐标系
			switch (cfg.PrjSys)
			{
				case ProjSystem.wgs84:
					rdbtn_PrjSys_wgs84.Checked = true;
					break;
				case ProjSystem.beijing54:
					rdbtn_PrjSys_bj54.Checked = true;
					break;
				case ProjSystem.xian80:
					rdbtn_PrjSys_xian80.Checked = true;
					break;
				case ProjSystem.cgcs2000:
					rdbtn_PrjSys_2000.Checked = true;
					break;

				default:
					rdbtn_PrjSys_wgs84.Checked = true;
					break;
			}
			// 半长轴
			tbx_SemiMajor.Text = cfg.SemiMajor.ToString();
			// 扁率
			tbx_InvFlatt.Text = cfg.InvFlatt.ToString();
			// 变形比
			tbx_ScaleFact.Text = cfg.ScaleFactor.ToString();
			// 中央经线
			tbx_CM.Text = cfg.CentralMeridian.ToString();
			// 坐标东移
			tbx_False_E.Text = cfg.FalseEast.ToString();
			// 坐标北移
			tbx_False_N.Text = cfg.FalseNorth.ToString();

			// 位深度
			switch(cfg.Depth)
			{
				case OSGeo.GDAL.DataType.GDT_Byte:
					rdbtn_Depth_8.Checked = true;
					break;
				case OSGeo.GDAL.DataType.GDT_CInt16:
				case OSGeo.GDAL.DataType.GDT_Int16:
				case OSGeo.GDAL.DataType.GDT_UInt16:
					rdbtn_Depth_8.Checked = true;
					break;
				case OSGeo.GDAL.DataType.GDT_CInt32:
				case OSGeo.GDAL.DataType.GDT_Int32:
				case OSGeo.GDAL.DataType.GDT_UInt32:
					rdbtn_Depth_32.Checked = true;
					break;
				default:
					rdbtn_Depth_8.Checked = true;
					break;
			}
			// 波段数
			tbx_BandCount.Text = cfg.BandCount.ToString();
			// 分辨率
			tbx_Resolution.Text = cfg.Resolution.ToString();
			// 外扩范围
			rdbtn_ByMeter.Checked = true;
			tbx_ClipExt.Text = cfg.ClipExtent.ToString();
			// 外扩公式
			if (cfg.ExtFormula == ClipExtFormula.NewFormula)
				cmbbx_ExtFormula.SelectedIndex = NewExtFormu_idx;
			else if (cfg.ExtFormula == ClipExtFormula.OrigFormula)
				cmbbx_ExtFormula.SelectedIndex = OrigExtFormu_idx;

			// 等高距
			tbx_ContIntv.Text = cfg.ContourInterval.ToString();
			// 平面限差
			tbx_PosTolar.Text = cfg.PositionDiffTolarence.ToString();
			// 高程限差
			tbx_HeightTolar.Text = cfg.HeightDiffTolarence.ToString();
		}

		private void frm2cfg(ref TaskCfg cfg)
		{
			// 数据类型

			// 坐标系
			if (rdbtn_PrjSys_wgs84.Checked)
				cfg.PrjSys = ProjSystem.wgs84;
			else if (rdbtn_PrjSys_bj54.Checked)
				cfg.PrjSys = ProjSystem.beijing54;
			else if (rdbtn_PrjSys_xian80.Checked)
				cfg.PrjSys = ProjSystem.xian80;
			else if (rdbtn_PrjSys_2000.Checked)
				cfg.PrjSys = ProjSystem.cgcs2000;
			else
				this.errstr += "未选择投影系；";
			// 半长轴
			double SM = 0;
			if (Double.TryParse(tbx_SemiMajor.Text, out SM))
				cfg.SemiMajor = SM;
			else
				this.errstr += "半长轴输入值非法:" + tbx_SemiMajor.Text + ";";
			// 扁率
			double IF = 0;
			if (Double.TryParse(tbx_InvFlatt.Text, out IF))
				cfg.InvFlatt = IF;
			else
				this.errstr += "扁率输入值非法:" + tbx_InvFlatt.Text + ";";
			// 变形比
			double SF = 0;
			if (Double.TryParse(tbx_ScaleFact.Text, out SF))
				cfg.ScaleFactor = SF;
			else
				this.errstr += "变形比输入值非法:" + tbx_ScaleFact.Text + ";";
			// 中央经线
			int CM = 0;
			if (Int32.TryParse(tbx_CM.Text, out CM))
				cfg.CentralMeridian = CM;
			else
				this.errstr += "中央经线输入值非法:" + tbx_CM.Text + ";";
			// 坐标东移
			int FE = 0;
			if (Int32.TryParse(tbx_False_E.Text, out FE))
				cfg.FalseEast = FE;
			else
				errstr += "坐标东移输入值非法:" + tbx_False_E.Text + ";";
			// 坐标北移
			int FN = 0;
			if (Int32.TryParse(tbx_False_N.Text, out FN))
				cfg.FalseNorth = FN;
			else
				errstr += "坐标北移输入值非法:" + tbx_False_N.Text + ";";

			// 位深度
			if (rdbtn_Depth_8.Checked)
				cfg.Depth = OSGeo.GDAL.DataType.GDT_Byte;
			else if (rdbtn_Depth_16.Checked)
				cfg.Depth = OSGeo.GDAL.DataType.GDT_UInt16;
			else if (rdbtn_Depth_32.Checked)
				cfg.Depth = OSGeo.GDAL.DataType.GDT_UInt32;
			else
				errstr += "位深度选择非法;";
			// 波段数
			uint bc = 0;
			if (UInt32.TryParse(tbx_BandCount.Text, out bc))
				cfg.BandCount = bc;
			else
				errstr += "波段数输入值非法:" + tbx_BandCount.Text + ";";
			// 分辨率
			double res = 0;
			if (Double.TryParse(tbx_Resolution.Text, out res))
				cfg.Resolution = res;
			else
				errstr += "分辨率输入值非法:" + tbx_Resolution.Text + ";";
			// 外扩范围
			if (res > 0)
			{
				double CEmeter = 0;
				uint CEpix = 0;
				if (rdbtn_ByPixel.Checked && !rdbtn_ByMeter.Checked)
				{
					if (!Double.TryParse(tbx_ClipExt.Text, out CEmeter))
						errstr += "外扩范围输入值非法:" + tbx_ClipExt.Text + ";";
					else
						CEpix = (uint)(CEmeter / res);
				}
				else
					if (!UInt32.TryParse(tbx_ClipExt.Text, out CEpix))
						errstr += "外扩范围输入值非法:" + tbx_ClipExt.Text + ";";

				cfg.ClipExtent = CEpix;
			}
			else
				tbx_ClipExt.Text = "0";
			// 外扩公式

			// 等高距
			double CI = 0;
			if (Double.TryParse(tbx_ContIntv.Text, out CI))
				cfg.ContourInterval = CI;
			else
				errstr += "等高距输入值非法:" + tbx_ContIntv.Text + ";";
			// 平面限差
			double PT = 0;
			if (Double.TryParse(tbx_PosTolar.Text, out PT))
				cfg.PositionDiffTolarence = PT;
			else
				errstr += "等高距输入值非法:" + tbx_PosTolar.Text + ";";
			// 高程限差
			double HT = 0;
			if (Double.TryParse(tbx_HeightTolar.Text, out HT))
				cfg.HeightDiffTolarence = HT;
			else
				errstr += "等高距输入值非法:" + tbx_HeightTolar.Text + ";";
		}
		private void ci2frm(CheckItem ci)
		{
			if (ci.PrjSys)
				chkbx_PrjSys.Checked = true;
			if (ci.PrjOther)
				chkbx_PrjOther.Checked = true;
			if (ci.ColorMode)
				chkbx_ColorMode.Checked = true;
			if (ci.DataInfo)
				chkbx_DataInfo.Checked = true;


			if (ci.ImgNoise)
				chkbx_ImgNoise.Checked = true;
			if (ci.ImgChkPoint)
				chkbx_ImgChkPoint.Checked = true;
			if (ci.ImgEdgeMatch)
				chkbx_ImgEdgeMatch.Checked = true;


			if (ci.GenContour)
				chkbx_GenContour.Checked = true;
			if (ci.DemChkPoint)
				chkbx_DemChkPoint.Checked = true;
			if (ci.DemEdgeMatch)
				chkbx_DemEdgeMatch.Checked = true;
			if (ci.GlobalMappingItems)
				chkbx_GMitems.Checked = true;
		}

		private void frm2ci(ref CheckItem ci)
		{
			ci.Clear();

			if (chkbx_PrjSys.Checked)
				ci.PrjSys = true;
			if (chkbx_PrjOther.Checked)
				ci.PrjOther = true;
			if (chkbx_ColorMode.Checked)
				ci.ColorMode = true;
			if (chkbx_DataInfo.Checked)
				ci.DataInfo = true;


			if (chkbx_ImgNoise.Checked)
				ci.ImgNoise = true;
			if (chkbx_ImgChkPoint.Checked)
				ci.ImgChkPoint = true;
			if (chkbx_ImgEdgeMatch.Checked)
				ci.ImgEdgeMatch = true;


			if (chkbx_GenContour.Checked)
				ci.GenContour = true;
			if (chkbx_DemChkPoint.Checked)
				ci.DemChkPoint = true;
			if (chkbx_DemEdgeMatch.Checked)
				ci.DemEdgeMatch = true;
			if (chkbx_GMitems.Checked)
				ci.GlobalMappingItems = true;
		}
	}
}
