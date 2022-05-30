namespace CheckerUI
{
	partial class frmChkItems
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.chkbx_DataOrganize = new System.Windows.Forms.CheckBox();
			this.chkbx_DataInfo = new System.Windows.Forms.CheckBox();
			this.chkbx_ImgNoise = new System.Windows.Forms.CheckBox();
			this.chkbx_PrjSys = new System.Windows.Forms.CheckBox();
			this.chkbx_PrjOther = new System.Windows.Forms.CheckBox();
			this.chkbx_ImgChkPoint = new System.Windows.Forms.CheckBox();
			this.chkbx_IMG_Noise = new System.Windows.Forms.CheckBox();
			this.chkbx_ColorMode = new System.Windows.Forms.CheckBox();
			this.gbx_CI_common = new System.Windows.Forms.GroupBox();
			this.gbx_CI_img = new System.Windows.Forms.GroupBox();
			this.chkbx_ImgEdgeMatch = new System.Windows.Forms.CheckBox();
			this.gbx_CI_dem = new System.Windows.Forms.GroupBox();
			this.chkbx_DemEdgeMatch = new System.Windows.Forms.CheckBox();
			this.chkbx_GMitems = new System.Windows.Forms.CheckBox();
			this.chkbx_GenContour = new System.Windows.Forms.CheckBox();
			this.chkbx_DemChkPoint = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.tbx_resultPath = new System.Windows.Forms.TextBox();
			this.btn_resultPath = new System.Windows.Forms.Button();
			this.timer_updateCI = new System.Windows.Forms.Timer(this.components);
			this.gbx_CI_common.SuspendLayout();
			this.gbx_CI_img.SuspendLayout();
			this.gbx_CI_dem.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkbx_DataOrganize
			// 
			this.chkbx_DataOrganize.AutoSize = true;
			this.chkbx_DataOrganize.Enabled = false;
			this.chkbx_DataOrganize.Location = new System.Drawing.Point(21, 125);
			this.chkbx_DataOrganize.Name = "chkbx_DataOrganize";
			this.chkbx_DataOrganize.Size = new System.Drawing.Size(104, 19);
			this.chkbx_DataOrganize.TabIndex = 7;
			this.chkbx_DataOrganize.Text = "格式一致性";
			this.chkbx_DataOrganize.UseVisualStyleBackColor = true;
			// 
			// chkbx_DataInfo
			// 
			this.chkbx_DataInfo.AutoSize = true;
			this.chkbx_DataInfo.Location = new System.Drawing.Point(21, 99);
			this.chkbx_DataInfo.Name = "chkbx_DataInfo";
			this.chkbx_DataInfo.Size = new System.Drawing.Size(314, 19);
			this.chkbx_DataInfo.TabIndex = 6;
			this.chkbx_DataInfo.Text = "数据信息（分辨率，起点坐标，裁切范围）";
			this.chkbx_DataInfo.UseVisualStyleBackColor = true;
			// 
			// chkbx_ImgNoise
			// 
			this.chkbx_ImgNoise.AutoSize = true;
			this.chkbx_ImgNoise.Location = new System.Drawing.Point(19, 24);
			this.chkbx_ImgNoise.Name = "chkbx_ImgNoise";
			this.chkbx_ImgNoise.Size = new System.Drawing.Size(194, 19);
			this.chkbx_ImgNoise.TabIndex = 5;
			this.chkbx_ImgNoise.Text = "影像噪音（白点，黑点）";
			this.chkbx_ImgNoise.UseVisualStyleBackColor = true;
			// 
			// chkbx_PrjSys
			// 
			this.chkbx_PrjSys.AutoSize = true;
			this.chkbx_PrjSys.Location = new System.Drawing.Point(21, 24);
			this.chkbx_PrjSys.Name = "chkbx_PrjSys";
			this.chkbx_PrjSys.Size = new System.Drawing.Size(299, 19);
			this.chkbx_PrjSys.TabIndex = 4;
			this.chkbx_PrjSys.Text = "投影（投影系，扁率，半长轴，变形比）";
			this.chkbx_PrjSys.UseVisualStyleBackColor = true;
			// 
			// chkbx_PrjOther
			// 
			this.chkbx_PrjOther.AutoSize = true;
			this.chkbx_PrjOther.Location = new System.Drawing.Point(21, 49);
			this.chkbx_PrjOther.Name = "chkbx_PrjOther";
			this.chkbx_PrjOther.Size = new System.Drawing.Size(284, 19);
			this.chkbx_PrjOther.TabIndex = 8;
			this.chkbx_PrjOther.Text = "其他投影信息（中央经线，坐标偏移）";
			this.chkbx_PrjOther.UseVisualStyleBackColor = true;
			// 
			// chkbx_ImgChkPoint
			// 
			this.chkbx_ImgChkPoint.AutoSize = true;
			this.chkbx_ImgChkPoint.Enabled = false;
			this.chkbx_ImgChkPoint.Location = new System.Drawing.Point(19, 49);
			this.chkbx_ImgChkPoint.Name = "chkbx_ImgChkPoint";
			this.chkbx_ImgChkPoint.Size = new System.Drawing.Size(224, 19);
			this.chkbx_ImgChkPoint.TabIndex = 9;
			this.chkbx_ImgChkPoint.Text = "影像平面精度（检测点文件）";
			this.chkbx_ImgChkPoint.UseVisualStyleBackColor = true;
			// 
			// chkbx_IMG_Noise
			// 
			this.chkbx_IMG_Noise.AutoSize = true;
			this.chkbx_IMG_Noise.Location = new System.Drawing.Point(13, 113);
			this.chkbx_IMG_Noise.Name = "chkbx_IMG_Noise";
			this.chkbx_IMG_Noise.Size = new System.Drawing.Size(194, 19);
			this.chkbx_IMG_Noise.TabIndex = 10;
			this.chkbx_IMG_Noise.Text = "影像噪音（白点，黑点）";
			this.chkbx_IMG_Noise.UseVisualStyleBackColor = true;
			// 
			// chkbx_ColorMode
			// 
			this.chkbx_ColorMode.AutoSize = true;
			this.chkbx_ColorMode.Location = new System.Drawing.Point(21, 74);
			this.chkbx_ColorMode.Name = "chkbx_ColorMode";
			this.chkbx_ColorMode.Size = new System.Drawing.Size(224, 19);
			this.chkbx_ColorMode.TabIndex = 11;
			this.chkbx_ColorMode.Text = "色彩模式（波段数，位深度）";
			this.chkbx_ColorMode.UseVisualStyleBackColor = true;
			// 
			// gbx_CI_common
			// 
			this.gbx_CI_common.Controls.Add(this.chkbx_PrjSys);
			this.gbx_CI_common.Controls.Add(this.chkbx_DataOrganize);
			this.gbx_CI_common.Controls.Add(this.chkbx_DataInfo);
			this.gbx_CI_common.Controls.Add(this.chkbx_ColorMode);
			this.gbx_CI_common.Controls.Add(this.chkbx_PrjOther);
			this.gbx_CI_common.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbx_CI_common.Location = new System.Drawing.Point(10, 10);
			this.gbx_CI_common.Margin = new System.Windows.Forms.Padding(5);
			this.gbx_CI_common.Name = "gbx_CI_common";
			this.gbx_CI_common.Size = new System.Drawing.Size(511, 159);
			this.gbx_CI_common.TabIndex = 12;
			this.gbx_CI_common.TabStop = false;
			this.gbx_CI_common.Text = "通用检查项";
			this.gbx_CI_common.MouseHover += new System.EventHandler(this.frmChkItems_MouseEnter);
			// 
			// gbx_CI_img
			// 
			this.gbx_CI_img.Controls.Add(this.chkbx_ImgEdgeMatch);
			this.gbx_CI_img.Controls.Add(this.chkbx_ImgNoise);
			this.gbx_CI_img.Controls.Add(this.chkbx_ImgChkPoint);
			this.gbx_CI_img.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbx_CI_img.Location = new System.Drawing.Point(10, 169);
			this.gbx_CI_img.Margin = new System.Windows.Forms.Padding(5);
			this.gbx_CI_img.Name = "gbx_CI_img";
			this.gbx_CI_img.Size = new System.Drawing.Size(511, 104);
			this.gbx_CI_img.TabIndex = 13;
			this.gbx_CI_img.TabStop = false;
			this.gbx_CI_img.Text = "影像专有项";
			this.gbx_CI_img.MouseHover += new System.EventHandler(this.frmChkItems_MouseEnter);
			// 
			// chkbx_ImgEdgeMatch
			// 
			this.chkbx_ImgEdgeMatch.AutoSize = true;
			this.chkbx_ImgEdgeMatch.Location = new System.Drawing.Point(19, 74);
			this.chkbx_ImgEdgeMatch.Name = "chkbx_ImgEdgeMatch";
			this.chkbx_ImgEdgeMatch.Size = new System.Drawing.Size(89, 19);
			this.chkbx_ImgEdgeMatch.TabIndex = 10;
			this.chkbx_ImgEdgeMatch.Text = "影像接边";
			this.chkbx_ImgEdgeMatch.UseVisualStyleBackColor = true;
			// 
			// gbx_CI_dem
			// 
			this.gbx_CI_dem.Controls.Add(this.chkbx_DemEdgeMatch);
			this.gbx_CI_dem.Controls.Add(this.chkbx_GMitems);
			this.gbx_CI_dem.Controls.Add(this.chkbx_GenContour);
			this.gbx_CI_dem.Controls.Add(this.chkbx_DemChkPoint);
			this.gbx_CI_dem.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbx_CI_dem.Location = new System.Drawing.Point(10, 273);
			this.gbx_CI_dem.Margin = new System.Windows.Forms.Padding(5);
			this.gbx_CI_dem.Name = "gbx_CI_dem";
			this.gbx_CI_dem.Size = new System.Drawing.Size(511, 130);
			this.gbx_CI_dem.TabIndex = 14;
			this.gbx_CI_dem.TabStop = false;
			this.gbx_CI_dem.Text = "DEM/DSM专有项";
			this.gbx_CI_dem.MouseHover += new System.EventHandler(this.frmChkItems_MouseEnter);
			// 
			// chkbx_DemEdgeMatch
			// 
			this.chkbx_DemEdgeMatch.AutoSize = true;
			this.chkbx_DemEdgeMatch.Location = new System.Drawing.Point(19, 74);
			this.chkbx_DemEdgeMatch.Name = "chkbx_DemEdgeMatch";
			this.chkbx_DemEdgeMatch.Size = new System.Drawing.Size(83, 19);
			this.chkbx_DemEdgeMatch.TabIndex = 10;
			this.chkbx_DemEdgeMatch.Text = "DEM接边";
			this.chkbx_DemEdgeMatch.UseVisualStyleBackColor = true;
			// 
			// chkbx_GMitems
			// 
			this.chkbx_GMitems.AutoSize = true;
			this.chkbx_GMitems.Enabled = false;
			this.chkbx_GMitems.Location = new System.Drawing.Point(19, 99);
			this.chkbx_GMitems.Name = "chkbx_GMitems";
			this.chkbx_GMitems.Size = new System.Drawing.Size(134, 19);
			this.chkbx_GMitems.TabIndex = 11;
			this.chkbx_GMitems.Text = "全球测图专有项";
			this.chkbx_GMitems.UseVisualStyleBackColor = true;
			// 
			// chkbx_GenContour
			// 
			this.chkbx_GenContour.AutoSize = true;
			this.chkbx_GenContour.Location = new System.Drawing.Point(19, 24);
			this.chkbx_GenContour.Name = "chkbx_GenContour";
			this.chkbx_GenContour.Size = new System.Drawing.Size(224, 19);
			this.chkbx_GenContour.TabIndex = 5;
			this.chkbx_GenContour.Text = "等高线套合（仅反生等高线）";
			this.chkbx_GenContour.UseVisualStyleBackColor = true;
			// 
			// chkbx_DemChkPoint
			// 
			this.chkbx_DemChkPoint.AutoSize = true;
			this.chkbx_DemChkPoint.Enabled = false;
			this.chkbx_DemChkPoint.Location = new System.Drawing.Point(19, 49);
			this.chkbx_DemChkPoint.Name = "chkbx_DemChkPoint";
			this.chkbx_DemChkPoint.Size = new System.Drawing.Size(218, 19);
			this.chkbx_DemChkPoint.TabIndex = 9;
			this.chkbx_DemChkPoint.Text = "DEM高程精度（检测点文件）";
			this.chkbx_DemChkPoint.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.tbx_resultPath);
			this.groupBox9.Controls.Add(this.btn_resultPath);
			this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox9.Location = new System.Drawing.Point(10, 403);
			this.groupBox9.Margin = new System.Windows.Forms.Padding(5);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(511, 108);
			this.groupBox9.TabIndex = 19;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "结果输出";
			this.groupBox9.MouseHover += new System.EventHandler(this.frmChkItems_MouseEnter);
			// 
			// tbx_resultPath
			// 
			this.tbx_resultPath.Location = new System.Drawing.Point(146, 34);
			this.tbx_resultPath.Name = "tbx_resultPath";
			this.tbx_resultPath.Size = new System.Drawing.Size(348, 25);
			this.tbx_resultPath.TabIndex = 1;
			// 
			// btn_resultPath
			// 
			this.btn_resultPath.Location = new System.Drawing.Point(22, 34);
			this.btn_resultPath.Name = "btn_resultPath";
			this.btn_resultPath.Size = new System.Drawing.Size(105, 25);
			this.btn_resultPath.TabIndex = 0;
			this.btn_resultPath.Text = "选择文件夹";
			this.btn_resultPath.UseVisualStyleBackColor = true;
			this.btn_resultPath.Click += new System.EventHandler(this.btn_resultPath_Click);
			// 
			// timer_updateCI
			// 
			this.timer_updateCI.Interval = 250;
			this.timer_updateCI.Tick += new System.EventHandler(this.timer_updateCI_Tick);
			// 
			// frmChkItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(531, 526);
			this.Controls.Add(this.groupBox9);
			this.Controls.Add(this.gbx_CI_dem);
			this.Controls.Add(this.gbx_CI_img);
			this.Controls.Add(this.gbx_CI_common);
			this.Controls.Add(this.chkbx_IMG_Noise);
			this.Name = "frmChkItems";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "检查内容";
			this.MouseEnter += new System.EventHandler(this.frmChkItems_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.frmChkItems_MouseLeave);
			this.gbx_CI_common.ResumeLayout(false);
			this.gbx_CI_common.PerformLayout();
			this.gbx_CI_img.ResumeLayout(false);
			this.gbx_CI_img.PerformLayout();
			this.gbx_CI_dem.ResumeLayout(false);
			this.gbx_CI_dem.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox chkbx_DataOrganize;
		private System.Windows.Forms.CheckBox chkbx_DataInfo;
		private System.Windows.Forms.CheckBox chkbx_ImgNoise;
		private System.Windows.Forms.CheckBox chkbx_PrjSys;
		private System.Windows.Forms.CheckBox chkbx_PrjOther;
		private System.Windows.Forms.CheckBox chkbx_ImgChkPoint;
		private System.Windows.Forms.CheckBox chkbx_IMG_Noise;
		private System.Windows.Forms.CheckBox chkbx_ColorMode;
		private System.Windows.Forms.GroupBox gbx_CI_common;
		private System.Windows.Forms.GroupBox gbx_CI_img;
		private System.Windows.Forms.GroupBox gbx_CI_dem;
		private System.Windows.Forms.CheckBox chkbx_GenContour;
		private System.Windows.Forms.CheckBox chkbx_DemChkPoint;
		private System.Windows.Forms.CheckBox chkbx_ImgEdgeMatch;
		private System.Windows.Forms.CheckBox chkbx_DemEdgeMatch;
		private System.Windows.Forms.CheckBox chkbx_GMitems;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox tbx_resultPath;
		private System.Windows.Forms.Button btn_resultPath;
		private System.Windows.Forms.Timer timer_updateCI;
	}
}