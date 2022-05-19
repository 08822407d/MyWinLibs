using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

		public frmTaskConf()
		{
			InitializeComponent();

			pnl_editTskCfg.Visible = false;
		}

		public frmTaskConf(CfgPack cfgs)
		{
			InitializeComponent();
			this.Cfgs = cfgs;
			loadTcfgs2cmbbx();

			pnl_editTskCfg.Visible = false;
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			if (Cfgs.hasUnsavedChanges())
			{
				DialogResult dr = MessageBox.Show(
								"有" + Cfgs.Tcachecount.ToString() +
								"项未保存配置,确定退出吗？",
								"", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					e.Cancel = true;
				else
					Cfgs.clearTCCaches();
			}
			base.OnClosing(e);
		}

		private void cmbbx_tskcfgs_SelectedIndexChanged(object sender, EventArgs e)
		{
			string name = cmbbx_tskcfgs.SelectedItem.ToString();
			TaskCfg tc = this.Cfgs.getTC(name);
			if (tc != null)
			{
				this.currTCname = name;
				this.currTC = tc;
				cfg2frm(this.currTC);
			}
			else
			{
				MessageBox.Show("错误，该配置不存在");
				cmbbx_tskcfgs.SelectedItem = this.currTCname;
			}

			btn_viewTskCfg_Click(sender, e);
		}

		private void btn_NewCfg_Click(object sender, EventArgs e)
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
				btn_editTskCfg_Click(sender, e);
			}
		}

		private void btn_viewTskCfg_Click(object sender, EventArgs e)
		{
			Utils.UI.units_disable(pnl_editTskCfg.Controls);
			pnl_editTskCfg.Visible = true;
			btn_close.Enabled = true;
		}

		private void btn_editTskCfg_Click(object sender, EventArgs e)
		{
			Utils.UI.units_enable(pnl_editTskCfg.Controls);
			pnl_editTskCfg.Visible = true;
			btn_close.Enabled = true;

			Cfgs.addTcache(this.currTCname, this.currTC);
		}

		private void btn_saveCurr_Click(object sender, EventArgs e)
		{
			if (Cfgs.hasUnsavedChanges())
			{
				DialogResult dr = MessageBox.Show("确定保存当前配置？", "", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					return;

				frm2cfg(ref currTC);
				exitErr();

				Cfgs.setLastTskCfg(currTCname);
				Cfgs.addTcache(currTCname, currTC);
				Cfgs.flushPC();
				Cfgs.flushTC();

				loadTcfgs2cmbbx();
				btn_viewTskCfg_Click(sender, e);

				MessageBox.Show("已保存当前配置");
			}
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

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void loadTcfgs2cmbbx()
		{
			foreach (string key in this.Cfgs.getTCNames())
			{
				cmbbx_tskcfgs.Items.Add(key);
			}

			this.currTCname = this.Cfgs.getLastTskCfg();
			cmbbx_tskcfgs.SelectedItem = currTCname;
			this.currTC = this.Cfgs.getTC(currTCname);
			cfg2frm(this.currTC);
		}

		private void exitErr()
		{
			if (!errstr.Equals(""))
				MessageBox.Show(errstr);
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
			// 比例尺
			tbx_Scale.Text = cfg.Scale.ToString();
			// 外扩范围
			rdbtn_ByMeter.Checked = true;
			tbx_ClipExt.Text = cfg.ClipExtent.ToString();

			// 等高距
			tbx_ContIntv.Text = cfg.ContourInterval.ToString();
			// 平面限差
			tbx_PosTolar.Text = cfg.PositionDiffTolarence.ToString();
			// 高程限差
			tbx_HeightTolar.Text = cfg.HeightDiffTolarence.ToString();
		}

		private void frm2cfg(ref TaskCfg cfg)
		{
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
			// 比例尺
			string S = tbx_Scale.Text.ToUpper();
			if (S.Length == 1 && S[0] >= 'A' && S[0] <= 'K')
				cfg.Scale = S[0];
			else
				errstr += "比例尺输入值非法:" + S + ";";
			// 外扩范围
			if (res > 0)
			{
				double CE = 0;
				uint CEpix = 0;
				if (rdbtn_ByPixel.Checked && !rdbtn_ByMeter.Checked)
				{
					if (!UInt32.TryParse(tbx_ClipExt.Text, out CEpix))
						errstr += "外扩范围输入值非法:" + tbx_ClipExt.Text + ";";
					else
						CE = CEpix * res;
				}
				else
					if (!Double.TryParse(tbx_ClipExt.Text, out CE))
						errstr += "外扩范围输入值非法:" + tbx_ClipExt.Text + ";";

				cfg.ClipExtent = CE;

			}
			else
				tbx_ClipExt.Text = "0";

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
	}
}
