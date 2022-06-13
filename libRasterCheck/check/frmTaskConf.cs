using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using geodata;
using Utils;

namespace CheckerUI
{
	public partial class frmTaskConf : Form
	{
		public CfgPack Cfgs = null;

		string errstr = "";
		string currTCname = null;
		TaskCfg currTC = null;

		int NewExtFormu_idx = 0;
		int OrigExtFormu_idx = 0;
		string NewExtFormu_name = "新公式";
		string OrigExtFormu_name = "原公式";
		string NewExtFormu_str =	"角点像元中心计算公式如下：\n" + 
									"	X起 = INT[(MAX(X1, X2, X3, X4) + N*d) / d] * d\n" +
									"	Y起 = INT[(MIN(Y1, Y2, Y3, Y4) - N*d) / d] * d\n" +
									"	X止 = INT[(MIN(X1, X2, X3, X4) - N*d) / d] * d\n" +
									"	Y止 = INT[(MAX(Y1, Y2, Y3, Y4) + N*d) / d] * d\n" +
									"其中 N 为外扩像素数目，d 为像素地面分辨率";
		string OrigExtFormu_str =	"角点像元中心计算公式如下：\n" + 
									"	X起 = INT[(MAX(X1, X2, X3, X4) / d + 1] * d + N*d\n" +
									"	Y起 = INT[(MIN(Y1, Y2, Y3, Y4) / d] * d - N*d\n" +
									"	X止 = INT[(MIN(X1, X2, X3, X4) / d] * d - N*d\n" +
									"	Y止 = INT[(MAX(Y1, Y2, Y3, Y4) / d + 1] * d + N*d\n" +
									"其中 N 为外扩像素数目，d 为像素地面分辨率";

		List<Control> CNSimg_only = null;
		List<Control> DEM_only = null;

		public frmTaskConf()
		{
			InitializeComponent();

			timer_editTC.Start();
		}

		public frmTaskConf(CfgPack cfgs)
		{
			InitializeComponent();

			CNSimg_only = new List<Control>();
			DEM_only = new List<Control>();
			CNSimg_only.Add(lbl_NoiseVal);
			CNSimg_only.Add(tbx_NoiseVal);
			CNSimg_only.Add(lbl_PosTolar);
			CNSimg_only.Add(tbx_PosTolar);
			DEM_only.Add(lbl_HeighTolar);
			DEM_only.Add(tbx_HeightTolar);
			

			this.Cfgs = cfgs;
			cmbbx_ExtFormula.Items.Add(NewExtFormu_name);
			cmbbx_ExtFormula.Items.Add(OrigExtFormu_name);
			NewExtFormu_idx = cmbbx_ExtFormula.Items.IndexOf(NewExtFormu_name);
			OrigExtFormu_idx = cmbbx_ExtFormula.Items.IndexOf(OrigExtFormu_name);
			loadTcfgs2cmbbx();

			timer_editTC.Start();
		}

		//==============================================================================================//
		//										项目模板列表相关											//
		//==============================================================================================//
		private void cmbbx_tskcfgs_SelectedIndexChanged(object sender, EventArgs e)
		{
			string name = cmbbx_tskcfgs.SelectedItem.ToString();
			TaskCfg tc = this.Cfgs.getTC(name);
			if (tc != null)
			{
				this.currTCname = name;
				this.currTC = tc;
				this.Cfgs.setLastTCname(name);

				cfg2frm(this.currTC);
			}
			else
			{
				MessageBox.Show("错误，该配置不存在");
				cmbbx_tskcfgs.SelectedItem = this.currTCname;
			}
		}

		private void btn_NewCfg_Click(object sender, EventArgs e)
		{
			frmTXTInput wTI = new frmTXTInput(false);
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
				Cfgs.addTC(this.currTCname, this.currTC);
				cmbbx_tskcfgs.Items.Add(currTCname);

				MessageBox.Show("新建配置:" + currTCname + ", 采用默认配置模板");
			}
		}

		private void btn_CopyCreate_Click(object sender, EventArgs e)
		{

		}

		private void btn_Rename_Click(object sender, EventArgs e)
		{
			frmTXTInput wTI = new frmTXTInput(false);
			wTI.ShowDialog();

			string newName = wTI.ret_val;
			if (newName != null)
			{
				this.Cfgs.removeTC(this.currTCname);
				this.currTCname = newName;
				this.Cfgs.addTC(this.currTCname, this.currTC);
				this.Cfgs.setLastTCname(this.currTCname);

				MessageBox.Show("新建配置:" + currTCname + ", 采用默认配置模板");

				loadTcfgs2cmbbx();
			}
		}

		private void btn_deleteCurr_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("确定删除当前配置？", "", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;

			this.Cfgs.removeTC(this.currTCname);
			this.Cfgs.flushTC();

			loadTcfgs2cmbbx();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			this.Cfgs.flushPC();
			this.Cfgs.flushTC();
			this.Cfgs.reloadSelf();

			base.OnClosing(e);
		}

		private void loadTcfgs2cmbbx()
		{
			string[] keys = this.Cfgs.TCkeys;
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

			this.currTCname = this.Cfgs.getLastTCname();
			this.currTC = this.Cfgs.getTC(currTCname);
			cmbbx_tskcfgs.SelectedItem = currTCname;
			cfg2frm(this.currTC);
		}


		//==============================================================================================//
		//										项目模板内容相关											//
		//==============================================================================================//
		private void timer_editTC_Tick(object sender, EventArgs e)
		{
			frm2cfg(ref this.currTC);
			if (errstr != null && errstr.Length > 1)
			{
				timer_editTC.Stop();
				MessageBox.Show(errstr);
				timer_waitErr.Start();
			}
		}

		private void timer_waitErr_Tick(object sender, EventArgs e)
		{
			timer_editTC.Start();
			timer_waitErr.Stop();
		}

		private void rdbtn_CNSimg_CheckedChanged(object sender, EventArgs e)
		{
			foreach (Control c in CNSimg_only)
			{
				c.Enabled = true;
			}
			foreach (Control c in DEM_only)
			{
				c.Enabled = false;
			}
		}

		private void rdbtn_DEM_CheckedChanged(object sender, EventArgs e)
		{
			foreach (Control c in DEM_only)
			{
				c.Enabled = true;
			}
			foreach (Control c in CNSimg_only)
			{
				c.Enabled = false;
			}
		}

		private void rdbtn_ImgSrc_CheckedChanged(object sender, EventArgs e)
		{

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

		private void cfg2frm(TaskCfg cfg)
		{
			// 数据类型
			switch (cfg.TskType)
			{
				case TaskType.CNSimg:
					rdbtn_CNSimg.Checked = true;
					break;
				case TaskType.DEM:
					rdbtn_DEM.Checked = true;
					break;
				case TaskType.ImgSrc:
					rdbtn_ImgSrc.Checked = true;
					break;

				default:
					rdbtn_CNSimg.Checked = true;
					break;
			}

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
			// 块尺寸
			tbx_BlkSize.Text = cfg.BlkSize.ToString();

			// 外扩范围
			rdbtn_ByPixel.Checked = true;
			tbx_ClipExt.Text = cfg.ClipExtent.ToString();
			// 外扩公式
			if (cfg.ExtFormula == ClipExtFormula.NewFormula)
				cmbbx_ExtFormula.SelectedIndex = NewExtFormu_idx;
			else if (cfg.ExtFormula == ClipExtFormula.OrigFormula)
				cmbbx_ExtFormula.SelectedIndex = OrigExtFormu_idx;

			// 平面限差
			tbx_PosTolar.Text = cfg.PositionDiffTolarence.ToString();
			// 高程限差
			tbx_HeightTolar.Text = cfg.HeightDiffTolarence.ToString();

			// TFW小数位数
			nud_tfwPrec.Value = cfg.TFWPrec;
		}

		private void frm2cfg(ref TaskCfg cfg)
		{
			errstr = "";

			// 数据类型
			if (rdbtn_CNSimg.Checked)
				cfg.TskType = TaskType.CNSimg;
			else if (rdbtn_DEM.Checked)
				cfg.TskType = TaskType.DEM;
			else if (rdbtn_ImgSrc.Checked)
				cfg.TskType = TaskType.ImgSrc;

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
			if (Double.TryParse(tbx_SemiMajor.Text, out double SM))
				cfg.SemiMajor = SM;
			else
				this.errstr += "半长轴输入值非法:" + tbx_SemiMajor.Text + ";";
			// 扁率
			if (Double.TryParse(tbx_InvFlatt.Text, out double IF))
				cfg.InvFlatt = IF;
			else
				this.errstr += "扁率输入值非法:" + tbx_InvFlatt.Text + ";";
			// 变形比
			if (Double.TryParse(tbx_ScaleFact.Text, out double SF))
				cfg.ScaleFactor = SF;
			else
				this.errstr += "变形比输入值非法:" + tbx_ScaleFact.Text + ";";
			// 中央经线
			if (Int32.TryParse(tbx_CM.Text, out int CM))
				cfg.CentralMeridian = CM;
			else
				this.errstr += "中央经线输入值非法:" + tbx_CM.Text + ";";
			// 坐标东移
			if (Double.TryParse(tbx_False_E.Text, out double FE))
				cfg.FalseEast = FE;
			else
				errstr += "坐标东移输入值非法:" + tbx_False_E.Text + ";";
			// 坐标北移
			if (Double.TryParse(tbx_False_N.Text, out double FN))
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
			if (UInt32.TryParse(tbx_BandCount.Text, out uint bc))
				cfg.BandCount = bc;
			else
				errstr += "波段数输入值非法:" + tbx_BandCount.Text + ";";
			// 分辨率
			if (Double.TryParse(tbx_Resolution.Text, out double res))
				cfg.Resolution = res;
			else
				errstr += "分辨率输入值非法:" + tbx_Resolution.Text + ";";
			// 块尺寸
			if (Int32.TryParse(tbx_BlkSize.Text, out int bs))
				cfg.BlkSize = bs;
			else
				errstr += "块尺寸输入值非法:" + tbx_BlkSize.Text + ";";

			// 外扩范围
			if (res > 0)
			{
				double CEmeter = 0;
				uint CEpix = 0;
				if (!rdbtn_ByPixel.Checked && rdbtn_ByMeter.Checked)
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

			// 平面限差
			if (Double.TryParse(tbx_PosTolar.Text, out double PT))
				cfg.PositionDiffTolarence = PT;
			else
				errstr += "平面限差输入值非法:" + tbx_PosTolar.Text + ";";
			// 高程限差
			if (Double.TryParse(tbx_HeightTolar.Text, out double HT))
				cfg.HeightDiffTolarence = HT;
			else
				errstr += "高程限差输入值非法:" + tbx_HeightTolar.Text + ";";


			// TFW小数位数
			cfg.TFWPrec = Convert.ToInt32(nud_tfwPrec.Value);
		}
	}
}
