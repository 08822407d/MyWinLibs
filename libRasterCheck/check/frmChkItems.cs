using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using geodata;

namespace CheckerUI
{
	public partial class frmChkItems : Form
	{
		CfgPack Cfgs = null;

		public frmChkItems()
		{
			InitializeComponent();

			initLayout();
		}

		public frmChkItems(CfgPack cfgs)
		{
			InitializeComponent();
			this.Cfgs = cfgs;

			ci2frm(this.Cfgs.getChkItems());

			initLayout();
		}

		public void updateCI()
		{
			CheckItem tmpci = this.Cfgs.getChkItems();
			frm2ci(ref tmpci);

			TaskCfg ctc = this.Cfgs.getTC(this.Cfgs.getLastTCname());
			if (ctc.TskType == TaskType.CNSimg)
			{
				gbx_CI_img.Enabled = true;
				gbx_CI_dem.Enabled = false;
			} else if (ctc.TskType == TaskType.DEM)
			{
				gbx_CI_dem.Enabled = true;
				gbx_CI_img.Enabled = false;
			}
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
					this.Cfgs.setAutoChkOPath(dir);
				}
			}
		}

		private void ci2frm(CheckItem ci)
		{
			this.tbx_resultPath.Text = this.Cfgs.getAutoChkOPath();

			if (ci.PrjSys)
				chkbx_PrjSys.Checked = true;
			if (ci.PrjOther)
				chkbx_PrjOther.Checked = true;
			if (ci.ColorMode)
				chkbx_ColorMode.Checked = true;
			if (ci.DataInfo)
				chkbx_DataInfo.Checked = true;
			if (ci.ClipExt)
				chkbx_ClipExt.Checked = true;

			if (ci.ImgNoise)
				chkbx_ImgNoise.Checked = true;
			if (ci.ImgEdgeMatch)
				chkbx_ImgEdgeMatch.Checked = true;

			if (ci.DemChkPoint)
				chkbx_DemChkPoint.Checked = true;
			if (ci.DemEdgeMatch)
				chkbx_DemEdgeMatch.Checked = true;
			if (ci.GlobalMappingItems)
				chkbx_GMitems.Checked = true;

			if (ci.OtherFile)
				chkbx_OtherFile.Checked = true;

			if (ci.DataOrganize)
				chkbx_DataOrganize.Checked = true;
		}

		private void frm2ci(ref CheckItem ci)
		{
			ci.Clear();

			if (Directory.Exists(tbx_resultPath.Text))
				this.Cfgs.setAutoChkOPath(tbx_resultPath.Text);

			if (chkbx_PrjSys.Checked)
				ci.PrjSys = true;
			if (chkbx_PrjOther.Checked)
				ci.PrjOther = true;
			if (chkbx_ColorMode.Checked)
				ci.ColorMode = true;
			if (chkbx_DataInfo.Checked)
				ci.DataInfo = true;
			if (chkbx_ClipExt.Checked)
				ci.ClipExt = true;

			if (chkbx_ImgNoise.Checked)
				ci.ImgNoise = true;
			if (chkbx_ImgEdgeMatch.Checked)
				ci.ImgEdgeMatch = true;

			if (chkbx_DemChkPoint.Checked)
				ci.DemChkPoint = true;
			if (chkbx_DemEdgeMatch.Checked)
				ci.DemEdgeMatch = true;
			if (chkbx_GMitems.Checked)
				ci.GlobalMappingItems = true;

			if (chkbx_OtherFile.Checked)
				ci.OtherFile = true;

			if (chkbx_DataOrganize.Checked)
				ci.DataOrganize = true;
		}

		private void initLayout()
		{
			this.Controls.SetChildIndex(this.gbx_check, 0);
			this.Controls.SetChildIndex(this.gbx_CI_common, 0);
			this.Controls.SetChildIndex(this.gbx_CI_img, 0);
			this.Controls.SetChildIndex(this.gbx_CI_dem, 0);

			this.gbx_check.Dock = DockStyle.Top;
			this.gbx_CI_common.Dock = DockStyle.Top;
			this.gbx_CI_img.Dock = DockStyle.Top;
			this.gbx_CI_dem.Dock = DockStyle.Top;
		}
	}
}
