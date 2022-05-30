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

namespace CheckerUI
{
	public partial class frmChkItems : Form
	{
		CfgPack Cfgs = null;
		public frmChkItems()
		{
			InitializeComponent();
		}

		public frmChkItems(CfgPack cfgs)
		{
			InitializeComponent();
			this.Cfgs = cfgs;

			ci2frm(this.Cfgs.getChkItems());
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

		private void timer_updateCI_Tick(object sender, EventArgs e)
		{
			tbx_resultPath.Text = DateTime.Now.ToLongTimeString();
		}

		private void frmChkItems_MouseEnter(object sender, EventArgs e)
		{
			timer_updateCI.Start();
		}

		private void frmChkItems_MouseLeave(object sender, EventArgs e)
		{
			timer_updateCI.Stop();
		}
	}
}
