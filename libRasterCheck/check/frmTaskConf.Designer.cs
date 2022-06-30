namespace CheckerUI
{
	partial class frmTaskConf
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
			this.btn_NewCfg = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbbx_tskcfgs = new System.Windows.Forms.ComboBox();
			this.btn_deleteCurr = new System.Windows.Forms.Button();
			this.gbx_ClipExt = new System.Windows.Forms.GroupBox();
			this.rtbx_ExtFormula = new System.Windows.Forms.RichTextBox();
			this.cmbbx_ExtFormula = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.rdbtn_ByPixel = new System.Windows.Forms.RadioButton();
			this.tbx_ClipExt = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.rdbtn_ByMeter = new System.Windows.Forms.RadioButton();
			this.gbx_DataType = new System.Windows.Forms.GroupBox();
			this.rdbtn_ImgSrc = new System.Windows.Forms.RadioButton();
			this.rdbtn_DEM = new System.Windows.Forms.RadioButton();
			this.rdbtn_CNSimg = new System.Windows.Forms.RadioButton();
			this.gbx_prj = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbx_False_N = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbx_False_E = new System.Windows.Forms.TextBox();
			this.tbx_CM = new System.Windows.Forms.TextBox();
			this.tbx_ScaleFact = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbx_InvFlatt = new System.Windows.Forms.TextBox();
			this.tbx_SemiMajor = new System.Windows.Forms.TextBox();
			this.rdbtn_PrjSys_wgs84 = new System.Windows.Forms.RadioButton();
			this.rdbtn_PrjSys_xian80 = new System.Windows.Forms.RadioButton();
			this.rdbtn_PrjSys_bj54 = new System.Windows.Forms.RadioButton();
			this.rdbtn_PrjSys_2000 = new System.Windows.Forms.RadioButton();
			this.gbx_DataInfo = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbx_BlkSize = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbx_Resolution = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbx_BandCount = new System.Windows.Forms.TextBox();
			this.rdbtn_Depth_8 = new System.Windows.Forms.RadioButton();
			this.rdbtn_Depth_32 = new System.Windows.Forms.RadioButton();
			this.rdbtn_Depth_16 = new System.Windows.Forms.RadioButton();
			this.lbl_NoiseVal = new System.Windows.Forms.Label();
			this.tbx_NoiseVal = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbx_NoDataVal = new System.Windows.Forms.TextBox();
			this.gbx_Tolarence = new System.Windows.Forms.GroupBox();
			this.nud_tfwPrec = new System.Windows.Forms.NumericUpDown();
			this.lbl_HeighTolar = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbx_HeightTolar = new System.Windows.Forms.TextBox();
			this.lbl_PosTolar = new System.Windows.Forms.Label();
			this.tbx_PosTolar = new System.Windows.Forms.TextBox();
			this.gbx_Templete = new System.Windows.Forms.GroupBox();
			this.btn_CopyCreate = new System.Windows.Forms.Button();
			this.btn_Rename = new System.Windows.Forms.Button();
			this.gbx_SpecialValue = new System.Windows.Forms.GroupBox();
			this.timer_editTC = new System.Windows.Forms.Timer(this.components);
			this.timer_waitErr = new System.Windows.Forms.Timer(this.components);
			this.gbx_ClipExt.SuspendLayout();
			this.gbx_DataType.SuspendLayout();
			this.gbx_prj.SuspendLayout();
			this.gbx_DataInfo.SuspendLayout();
			this.gbx_Tolarence.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_tfwPrec)).BeginInit();
			this.gbx_Templete.SuspendLayout();
			this.gbx_SpecialValue.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_NewCfg
			// 
			this.btn_NewCfg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_NewCfg.Location = new System.Drawing.Point(371, 23);
			this.btn_NewCfg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_NewCfg.Name = "btn_NewCfg";
			this.btn_NewCfg.Size = new System.Drawing.Size(154, 24);
			this.btn_NewCfg.TabIndex = 5;
			this.btn_NewCfg.Text = "新建配置";
			this.btn_NewCfg.UseVisualStyleBackColor = true;
			this.btn_NewCfg.Click += new System.EventHandler(this.btn_NewCfg_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label15.Location = new System.Drawing.Point(18, 32);
			this.label15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(120, 15);
			this.label15.TabIndex = 15;
			this.label15.Text = "请选择项目配置:";
			// 
			// cmbbx_tskcfgs
			// 
			this.cmbbx_tskcfgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbx_tskcfgs.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbbx_tskcfgs.FormattingEnabled = true;
			this.cmbbx_tskcfgs.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.cmbbx_tskcfgs.ItemHeight = 18;
			this.cmbbx_tskcfgs.Location = new System.Drawing.Point(158, 24);
			this.cmbbx_tskcfgs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbbx_tskcfgs.Name = "cmbbx_tskcfgs";
			this.cmbbx_tskcfgs.Size = new System.Drawing.Size(183, 26);
			this.cmbbx_tskcfgs.Sorted = true;
			this.cmbbx_tskcfgs.TabIndex = 1;
			this.cmbbx_tskcfgs.SelectedIndexChanged += new System.EventHandler(this.cmbbx_tskcfgs_SelectedIndexChanged);
			// 
			// btn_deleteCurr
			// 
			this.btn_deleteCurr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_deleteCurr.Location = new System.Drawing.Point(370, 56);
			this.btn_deleteCurr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_deleteCurr.Name = "btn_deleteCurr";
			this.btn_deleteCurr.Size = new System.Drawing.Size(155, 24);
			this.btn_deleteCurr.TabIndex = 18;
			this.btn_deleteCurr.Text = "删除当前配置";
			this.btn_deleteCurr.UseVisualStyleBackColor = true;
			this.btn_deleteCurr.Click += new System.EventHandler(this.btn_deleteCurr_Click);
			// 
			// gbx_ClipExt
			// 
			this.gbx_ClipExt.Controls.Add(this.rtbx_ExtFormula);
			this.gbx_ClipExt.Controls.Add(this.cmbbx_ExtFormula);
			this.gbx_ClipExt.Controls.Add(this.label8);
			this.gbx_ClipExt.Controls.Add(this.rdbtn_ByPixel);
			this.gbx_ClipExt.Controls.Add(this.tbx_ClipExt);
			this.gbx_ClipExt.Controls.Add(this.label17);
			this.gbx_ClipExt.Controls.Add(this.rdbtn_ByMeter);
			this.gbx_ClipExt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_ClipExt.Location = new System.Drawing.Point(14, 518);
			this.gbx_ClipExt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbx_ClipExt.Name = "gbx_ClipExt";
			this.gbx_ClipExt.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_ClipExt.Size = new System.Drawing.Size(546, 174);
			this.gbx_ClipExt.TabIndex = 38;
			this.gbx_ClipExt.TabStop = false;
			this.gbx_ClipExt.Text = "裁切范围";
			// 
			// rtbx_ExtFormula
			// 
			this.rtbx_ExtFormula.Location = new System.Drawing.Point(19, 60);
			this.rtbx_ExtFormula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rtbx_ExtFormula.Name = "rtbx_ExtFormula";
			this.rtbx_ExtFormula.Size = new System.Drawing.Size(506, 107);
			this.rtbx_ExtFormula.TabIndex = 26;
			this.rtbx_ExtFormula.Text = "";
			// 
			// cmbbx_ExtFormula
			// 
			this.cmbbx_ExtFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbx_ExtFormula.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cmbbx_ExtFormula.FormattingEnabled = true;
			this.cmbbx_ExtFormula.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.cmbbx_ExtFormula.ItemHeight = 18;
			this.cmbbx_ExtFormula.Location = new System.Drawing.Point(100, 23);
			this.cmbbx_ExtFormula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbbx_ExtFormula.Name = "cmbbx_ExtFormula";
			this.cmbbx_ExtFormula.Size = new System.Drawing.Size(114, 26);
			this.cmbbx_ExtFormula.Sorted = true;
			this.cmbbx_ExtFormula.TabIndex = 25;
			this.cmbbx_ExtFormula.SelectedIndexChanged += new System.EventHandler(this.cmbbx_ExtFormula_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(18, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 15);
			this.label8.TabIndex = 17;
			this.label8.Text = "外扩公式:";
			// 
			// rdbtn_ByPixel
			// 
			this.rdbtn_ByPixel.AutoSize = true;
			this.rdbtn_ByPixel.Location = new System.Drawing.Point(467, 24);
			this.rdbtn_ByPixel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_ByPixel.Name = "rdbtn_ByPixel";
			this.rdbtn_ByPixel.Size = new System.Drawing.Size(58, 19);
			this.rdbtn_ByPixel.TabIndex = 15;
			this.rdbtn_ByPixel.TabStop = true;
			this.rdbtn_ByPixel.Text = "像素";
			this.rdbtn_ByPixel.UseVisualStyleBackColor = true;
			// 
			// tbx_ClipExt
			// 
			this.tbx_ClipExt.Location = new System.Drawing.Point(322, 23);
			this.tbx_ClipExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_ClipExt.Name = "tbx_ClipExt";
			this.tbx_ClipExt.Size = new System.Drawing.Size(87, 25);
			this.tbx_ClipExt.TabIndex = 12;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(240, 29);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(75, 15);
			this.label17.TabIndex = 14;
			this.label17.Text = "外扩范围:";
			// 
			// rdbtn_ByMeter
			// 
			this.rdbtn_ByMeter.AutoSize = true;
			this.rdbtn_ByMeter.Location = new System.Drawing.Point(418, 24);
			this.rdbtn_ByMeter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_ByMeter.Name = "rdbtn_ByMeter";
			this.rdbtn_ByMeter.Size = new System.Drawing.Size(43, 19);
			this.rdbtn_ByMeter.TabIndex = 16;
			this.rdbtn_ByMeter.TabStop = true;
			this.rdbtn_ByMeter.Text = "米";
			this.rdbtn_ByMeter.UseVisualStyleBackColor = true;
			// 
			// gbx_DataType
			// 
			this.gbx_DataType.Controls.Add(this.rdbtn_ImgSrc);
			this.gbx_DataType.Controls.Add(this.rdbtn_DEM);
			this.gbx_DataType.Controls.Add(this.rdbtn_CNSimg);
			this.gbx_DataType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_DataType.Location = new System.Drawing.Point(14, 116);
			this.gbx_DataType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_DataType.Name = "gbx_DataType";
			this.gbx_DataType.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_DataType.Size = new System.Drawing.Size(546, 62);
			this.gbx_DataType.TabIndex = 37;
			this.gbx_DataType.TabStop = false;
			this.gbx_DataType.Text = "项目类型";
			// 
			// rdbtn_ImgSrc
			// 
			this.rdbtn_ImgSrc.AutoSize = true;
			this.rdbtn_ImgSrc.Enabled = false;
			this.rdbtn_ImgSrc.Location = new System.Drawing.Point(395, 26);
			this.rdbtn_ImgSrc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_ImgSrc.Name = "rdbtn_ImgSrc";
			this.rdbtn_ImgSrc.Size = new System.Drawing.Size(88, 19);
			this.rdbtn_ImgSrc.TabIndex = 19;
			this.rdbtn_ImgSrc.TabStop = true;
			this.rdbtn_ImgSrc.Text = "影像原片";
			this.rdbtn_ImgSrc.UseVisualStyleBackColor = true;
			this.rdbtn_ImgSrc.CheckedChanged += new System.EventHandler(this.rdbtn_ImgSrc_CheckedChanged);
			// 
			// rdbtn_DEM
			// 
			this.rdbtn_DEM.AutoSize = true;
			this.rdbtn_DEM.Location = new System.Drawing.Point(232, 26);
			this.rdbtn_DEM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_DEM.Name = "rdbtn_DEM";
			this.rdbtn_DEM.Size = new System.Drawing.Size(84, 19);
			this.rdbtn_DEM.TabIndex = 17;
			this.rdbtn_DEM.TabStop = true;
			this.rdbtn_DEM.Text = "DEM/DSM";
			this.rdbtn_DEM.UseVisualStyleBackColor = true;
			this.rdbtn_DEM.CheckedChanged += new System.EventHandler(this.rdbtn_DEM_CheckedChanged);
			// 
			// rdbtn_CNSimg
			// 
			this.rdbtn_CNSimg.AutoSize = true;
			this.rdbtn_CNSimg.Location = new System.Drawing.Point(46, 26);
			this.rdbtn_CNSimg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_CNSimg.Name = "rdbtn_CNSimg";
			this.rdbtn_CNSimg.Size = new System.Drawing.Size(88, 19);
			this.rdbtn_CNSimg.TabIndex = 18;
			this.rdbtn_CNSimg.TabStop = true;
			this.rdbtn_CNSimg.Text = "分幅影像";
			this.rdbtn_CNSimg.UseVisualStyleBackColor = true;
			this.rdbtn_CNSimg.CheckedChanged += new System.EventHandler(this.rdbtn_CNSimg_CheckedChanged);
			// 
			// gbx_prj
			// 
			this.gbx_prj.Controls.Add(this.label12);
			this.gbx_prj.Controls.Add(this.label5);
			this.gbx_prj.Controls.Add(this.label6);
			this.gbx_prj.Controls.Add(this.tbx_False_N);
			this.gbx_prj.Controls.Add(this.label4);
			this.gbx_prj.Controls.Add(this.label3);
			this.gbx_prj.Controls.Add(this.tbx_False_E);
			this.gbx_prj.Controls.Add(this.tbx_CM);
			this.gbx_prj.Controls.Add(this.tbx_ScaleFact);
			this.gbx_prj.Controls.Add(this.label2);
			this.gbx_prj.Controls.Add(this.label1);
			this.gbx_prj.Controls.Add(this.tbx_InvFlatt);
			this.gbx_prj.Controls.Add(this.tbx_SemiMajor);
			this.gbx_prj.Controls.Add(this.rdbtn_PrjSys_wgs84);
			this.gbx_prj.Controls.Add(this.rdbtn_PrjSys_xian80);
			this.gbx_prj.Controls.Add(this.rdbtn_PrjSys_bj54);
			this.gbx_prj.Controls.Add(this.rdbtn_PrjSys_2000);
			this.gbx_prj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_prj.Location = new System.Drawing.Point(14, 187);
			this.gbx_prj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbx_prj.Name = "gbx_prj";
			this.gbx_prj.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_prj.Size = new System.Drawing.Size(546, 133);
			this.gbx_prj.TabIndex = 34;
			this.gbx_prj.TabStop = false;
			this.gbx_prj.Text = "投影信息";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(26, 26);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 15);
			this.label12.TabIndex = 16;
			this.label12.Text = "投影系:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(381, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 15);
			this.label5.TabIndex = 15;
			this.label5.Text = "北移:";
			this.label5.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(206, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 15);
			this.label6.TabIndex = 14;
			this.label6.Text = "东移:";
			this.label6.Visible = false;
			// 
			// tbx_False_N
			// 
			this.tbx_False_N.Location = new System.Drawing.Point(435, 90);
			this.tbx_False_N.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_False_N.Name = "tbx_False_N";
			this.tbx_False_N.Size = new System.Drawing.Size(100, 25);
			this.tbx_False_N.TabIndex = 13;
			this.tbx_False_N.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 15);
			this.label4.TabIndex = 11;
			this.label4.Text = "中央经线:";
			this.label4.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(367, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 15);
			this.label3.TabIndex = 10;
			this.label3.Text = "变形比:";
			this.label3.Visible = false;
			// 
			// tbx_False_E
			// 
			this.tbx_False_E.Location = new System.Drawing.Point(260, 91);
			this.tbx_False_E.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_False_E.Name = "tbx_False_E";
			this.tbx_False_E.Size = new System.Drawing.Size(100, 25);
			this.tbx_False_E.TabIndex = 12;
			this.tbx_False_E.Visible = false;
			// 
			// tbx_CM
			// 
			this.tbx_CM.Location = new System.Drawing.Point(93, 91);
			this.tbx_CM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_CM.Name = "tbx_CM";
			this.tbx_CM.Size = new System.Drawing.Size(100, 25);
			this.tbx_CM.TabIndex = 9;
			this.tbx_CM.Visible = false;
			// 
			// tbx_ScaleFact
			// 
			this.tbx_ScaleFact.Location = new System.Drawing.Point(435, 58);
			this.tbx_ScaleFact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_ScaleFact.Name = "tbx_ScaleFact";
			this.tbx_ScaleFact.Size = new System.Drawing.Size(100, 25);
			this.tbx_ScaleFact.TabIndex = 8;
			this.tbx_ScaleFact.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(206, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "扁率:";
			this.label2.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "半长轴:";
			this.label1.Visible = false;
			// 
			// tbx_InvFlatt
			// 
			this.tbx_InvFlatt.Location = new System.Drawing.Point(260, 59);
			this.tbx_InvFlatt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_InvFlatt.Name = "tbx_InvFlatt";
			this.tbx_InvFlatt.Size = new System.Drawing.Size(100, 25);
			this.tbx_InvFlatt.TabIndex = 5;
			this.tbx_InvFlatt.Visible = false;
			// 
			// tbx_SemiMajor
			// 
			this.tbx_SemiMajor.Location = new System.Drawing.Point(93, 59);
			this.tbx_SemiMajor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_SemiMajor.Name = "tbx_SemiMajor";
			this.tbx_SemiMajor.Size = new System.Drawing.Size(100, 25);
			this.tbx_SemiMajor.TabIndex = 4;
			this.tbx_SemiMajor.Visible = false;
			// 
			// rdbtn_PrjSys_wgs84
			// 
			this.rdbtn_PrjSys_wgs84.AutoSize = true;
			this.rdbtn_PrjSys_wgs84.Location = new System.Drawing.Point(107, 23);
			this.rdbtn_PrjSys_wgs84.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_PrjSys_wgs84.Name = "rdbtn_PrjSys_wgs84";
			this.rdbtn_PrjSys_wgs84.Size = new System.Drawing.Size(68, 19);
			this.rdbtn_PrjSys_wgs84.TabIndex = 3;
			this.rdbtn_PrjSys_wgs84.TabStop = true;
			this.rdbtn_PrjSys_wgs84.Text = "WGS84";
			this.rdbtn_PrjSys_wgs84.UseVisualStyleBackColor = true;
			// 
			// rdbtn_PrjSys_xian80
			// 
			this.rdbtn_PrjSys_xian80.AutoSize = true;
			this.rdbtn_PrjSys_xian80.Location = new System.Drawing.Point(331, 23);
			this.rdbtn_PrjSys_xian80.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_PrjSys_xian80.Name = "rdbtn_PrjSys_xian80";
			this.rdbtn_PrjSys_xian80.Size = new System.Drawing.Size(76, 19);
			this.rdbtn_PrjSys_xian80.TabIndex = 2;
			this.rdbtn_PrjSys_xian80.TabStop = true;
			this.rdbtn_PrjSys_xian80.Text = "XIAN80";
			this.rdbtn_PrjSys_xian80.UseVisualStyleBackColor = true;
			// 
			// rdbtn_PrjSys_bj54
			// 
			this.rdbtn_PrjSys_bj54.AutoSize = true;
			this.rdbtn_PrjSys_bj54.Location = new System.Drawing.Point(209, 23);
			this.rdbtn_PrjSys_bj54.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_PrjSys_bj54.Name = "rdbtn_PrjSys_bj54";
			this.rdbtn_PrjSys_bj54.Size = new System.Drawing.Size(100, 19);
			this.rdbtn_PrjSys_bj54.TabIndex = 1;
			this.rdbtn_PrjSys_bj54.TabStop = true;
			this.rdbtn_PrjSys_bj54.Text = "BEIJING54";
			this.rdbtn_PrjSys_bj54.UseVisualStyleBackColor = true;
			// 
			// rdbtn_PrjSys_2000
			// 
			this.rdbtn_PrjSys_2000.AutoSize = true;
			this.rdbtn_PrjSys_2000.Location = new System.Drawing.Point(433, 23);
			this.rdbtn_PrjSys_2000.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_PrjSys_2000.Name = "rdbtn_PrjSys_2000";
			this.rdbtn_PrjSys_2000.Size = new System.Drawing.Size(92, 19);
			this.rdbtn_PrjSys_2000.TabIndex = 0;
			this.rdbtn_PrjSys_2000.TabStop = true;
			this.rdbtn_PrjSys_2000.Text = "CGCS2000";
			this.rdbtn_PrjSys_2000.UseVisualStyleBackColor = true;
			// 
			// gbx_DataInfo
			// 
			this.gbx_DataInfo.Controls.Add(this.label11);
			this.gbx_DataInfo.Controls.Add(this.tbx_BlkSize);
			this.gbx_DataInfo.Controls.Add(this.label10);
			this.gbx_DataInfo.Controls.Add(this.tbx_Resolution);
			this.gbx_DataInfo.Controls.Add(this.label7);
			this.gbx_DataInfo.Controls.Add(this.label9);
			this.gbx_DataInfo.Controls.Add(this.tbx_BandCount);
			this.gbx_DataInfo.Controls.Add(this.rdbtn_Depth_8);
			this.gbx_DataInfo.Controls.Add(this.rdbtn_Depth_32);
			this.gbx_DataInfo.Controls.Add(this.rdbtn_Depth_16);
			this.gbx_DataInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_DataInfo.Location = new System.Drawing.Point(14, 330);
			this.gbx_DataInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbx_DataInfo.Name = "gbx_DataInfo";
			this.gbx_DataInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_DataInfo.Size = new System.Drawing.Size(546, 104);
			this.gbx_DataInfo.TabIndex = 35;
			this.gbx_DataInfo.TabStop = false;
			this.gbx_DataInfo.Text = "数据信息";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(385, 66);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 15);
			this.label11.TabIndex = 21;
			this.label11.Text = "块尺寸:";
			// 
			// tbx_BlkSize
			// 
			this.tbx_BlkSize.Location = new System.Drawing.Point(450, 62);
			this.tbx_BlkSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_BlkSize.Name = "tbx_BlkSize";
			this.tbx_BlkSize.Size = new System.Drawing.Size(75, 25);
			this.tbx_BlkSize.TabIndex = 20;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(207, 66);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 15);
			this.label10.TabIndex = 19;
			this.label10.Text = "分辨率:";
			// 
			// tbx_Resolution
			// 
			this.tbx_Resolution.Location = new System.Drawing.Point(272, 62);
			this.tbx_Resolution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_Resolution.Name = "tbx_Resolution";
			this.tbx_Resolution.Size = new System.Drawing.Size(75, 25);
			this.tbx_Resolution.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(30, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(60, 15);
			this.label7.TabIndex = 17;
			this.label7.Text = "位深度:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(29, 66);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 15);
			this.label9.TabIndex = 11;
			this.label9.Text = "波段数:";
			// 
			// tbx_BandCount
			// 
			this.tbx_BandCount.Location = new System.Drawing.Point(100, 62);
			this.tbx_BandCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_BandCount.Name = "tbx_BandCount";
			this.tbx_BandCount.Size = new System.Drawing.Size(75, 25);
			this.tbx_BandCount.TabIndex = 9;
			// 
			// rdbtn_Depth_8
			// 
			this.rdbtn_Depth_8.AutoSize = true;
			this.rdbtn_Depth_8.Location = new System.Drawing.Point(110, 23);
			this.rdbtn_Depth_8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_Depth_8.Name = "rdbtn_Depth_8";
			this.rdbtn_Depth_8.Size = new System.Drawing.Size(51, 19);
			this.rdbtn_Depth_8.TabIndex = 3;
			this.rdbtn_Depth_8.TabStop = true;
			this.rdbtn_Depth_8.Text = "8位";
			this.rdbtn_Depth_8.UseVisualStyleBackColor = true;
			// 
			// rdbtn_Depth_32
			// 
			this.rdbtn_Depth_32.AutoSize = true;
			this.rdbtn_Depth_32.Location = new System.Drawing.Point(351, 23);
			this.rdbtn_Depth_32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_Depth_32.Name = "rdbtn_Depth_32";
			this.rdbtn_Depth_32.Size = new System.Drawing.Size(59, 19);
			this.rdbtn_Depth_32.TabIndex = 2;
			this.rdbtn_Depth_32.TabStop = true;
			this.rdbtn_Depth_32.Text = "32位";
			this.rdbtn_Depth_32.UseVisualStyleBackColor = true;
			// 
			// rdbtn_Depth_16
			// 
			this.rdbtn_Depth_16.AutoSize = true;
			this.rdbtn_Depth_16.Location = new System.Drawing.Point(230, 23);
			this.rdbtn_Depth_16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdbtn_Depth_16.Name = "rdbtn_Depth_16";
			this.rdbtn_Depth_16.Size = new System.Drawing.Size(59, 19);
			this.rdbtn_Depth_16.TabIndex = 1;
			this.rdbtn_Depth_16.TabStop = true;
			this.rdbtn_Depth_16.Text = "16位";
			this.rdbtn_Depth_16.UseVisualStyleBackColor = true;
			// 
			// lbl_NoiseVal
			// 
			this.lbl_NoiseVal.AutoSize = true;
			this.lbl_NoiseVal.Location = new System.Drawing.Point(271, 30);
			this.lbl_NoiseVal.Name = "lbl_NoiseVal";
			this.lbl_NoiseVal.Size = new System.Drawing.Size(106, 15);
			this.lbl_NoiseVal.TabIndex = 25;
			this.lbl_NoiseVal.Text = "噪音(白点)值:";
			// 
			// tbx_NoiseVal
			// 
			this.tbx_NoiseVal.Location = new System.Drawing.Point(382, 25);
			this.tbx_NoiseVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_NoiseVal.Name = "tbx_NoiseVal";
			this.tbx_NoiseVal.Size = new System.Drawing.Size(142, 25);
			this.tbx_NoiseVal.TabIndex = 24;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(21, 30);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(78, 15);
			this.label16.TabIndex = 23;
			this.label16.Text = "NoData值:";
			// 
			// tbx_NoDataVal
			// 
			this.tbx_NoDataVal.Location = new System.Drawing.Point(99, 25);
			this.tbx_NoDataVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_NoDataVal.Name = "tbx_NoDataVal";
			this.tbx_NoDataVal.Size = new System.Drawing.Size(142, 25);
			this.tbx_NoDataVal.TabIndex = 22;
			// 
			// gbx_Tolarence
			// 
			this.gbx_Tolarence.Controls.Add(this.nud_tfwPrec);
			this.gbx_Tolarence.Controls.Add(this.lbl_HeighTolar);
			this.gbx_Tolarence.Controls.Add(this.label13);
			this.gbx_Tolarence.Controls.Add(this.tbx_HeightTolar);
			this.gbx_Tolarence.Controls.Add(this.lbl_PosTolar);
			this.gbx_Tolarence.Controls.Add(this.tbx_PosTolar);
			this.gbx_Tolarence.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_Tolarence.Location = new System.Drawing.Point(14, 702);
			this.gbx_Tolarence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbx_Tolarence.Name = "gbx_Tolarence";
			this.gbx_Tolarence.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_Tolarence.Size = new System.Drawing.Size(546, 70);
			this.gbx_Tolarence.TabIndex = 36;
			this.gbx_Tolarence.TabStop = false;
			this.gbx_Tolarence.Text = "精度";
			// 
			// nud_tfwPrec
			// 
			this.nud_tfwPrec.Location = new System.Drawing.Point(438, 24);
			this.nud_tfwPrec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.nud_tfwPrec.Name = "nud_tfwPrec";
			this.nud_tfwPrec.Size = new System.Drawing.Size(87, 25);
			this.nud_tfwPrec.TabIndex = 24;
			// 
			// lbl_HeighTolar
			// 
			this.lbl_HeighTolar.AutoSize = true;
			this.lbl_HeighTolar.Location = new System.Drawing.Point(174, 29);
			this.lbl_HeighTolar.Name = "lbl_HeighTolar";
			this.lbl_HeighTolar.Size = new System.Drawing.Size(75, 15);
			this.lbl_HeighTolar.TabIndex = 23;
			this.lbl_HeighTolar.Text = "高程限差:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(345, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 15);
			this.label13.TabIndex = 22;
			this.label13.Text = "tfw小数数:";
			// 
			// tbx_HeightTolar
			// 
			this.tbx_HeightTolar.Location = new System.Drawing.Point(255, 25);
			this.tbx_HeightTolar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_HeightTolar.Name = "tbx_HeightTolar";
			this.tbx_HeightTolar.Size = new System.Drawing.Size(61, 25);
			this.tbx_HeightTolar.TabIndex = 22;
			// 
			// lbl_PosTolar
			// 
			this.lbl_PosTolar.AutoSize = true;
			this.lbl_PosTolar.Location = new System.Drawing.Point(17, 30);
			this.lbl_PosTolar.Name = "lbl_PosTolar";
			this.lbl_PosTolar.Size = new System.Drawing.Size(75, 15);
			this.lbl_PosTolar.TabIndex = 21;
			this.lbl_PosTolar.Text = "平面限差:";
			// 
			// tbx_PosTolar
			// 
			this.tbx_PosTolar.Location = new System.Drawing.Point(98, 25);
			this.tbx_PosTolar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbx_PosTolar.Name = "tbx_PosTolar";
			this.tbx_PosTolar.Size = new System.Drawing.Size(62, 25);
			this.tbx_PosTolar.TabIndex = 20;
			// 
			// gbx_Templete
			// 
			this.gbx_Templete.Controls.Add(this.btn_CopyCreate);
			this.gbx_Templete.Controls.Add(this.btn_Rename);
			this.gbx_Templete.Controls.Add(this.btn_NewCfg);
			this.gbx_Templete.Controls.Add(this.cmbbx_tskcfgs);
			this.gbx_Templete.Controls.Add(this.label15);
			this.gbx_Templete.Controls.Add(this.btn_deleteCurr);
			this.gbx_Templete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_Templete.Location = new System.Drawing.Point(14, 13);
			this.gbx_Templete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_Templete.Name = "gbx_Templete";
			this.gbx_Templete.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_Templete.Size = new System.Drawing.Size(546, 98);
			this.gbx_Templete.TabIndex = 39;
			this.gbx_Templete.TabStop = false;
			this.gbx_Templete.Text = "配置模板";
			// 
			// btn_CopyCreate
			// 
			this.btn_CopyCreate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_CopyCreate.Location = new System.Drawing.Point(21, 56);
			this.btn_CopyCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_CopyCreate.Name = "btn_CopyCreate";
			this.btn_CopyCreate.Size = new System.Drawing.Size(155, 24);
			this.btn_CopyCreate.TabIndex = 21;
			this.btn_CopyCreate.Text = "复制当前配置新建";
			this.btn_CopyCreate.UseVisualStyleBackColor = true;
			this.btn_CopyCreate.Click += new System.EventHandler(this.btn_CopyCreate_Click);
			// 
			// btn_Rename
			// 
			this.btn_Rename.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_Rename.Location = new System.Drawing.Point(186, 56);
			this.btn_Rename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_Rename.Name = "btn_Rename";
			this.btn_Rename.Size = new System.Drawing.Size(154, 24);
			this.btn_Rename.TabIndex = 20;
			this.btn_Rename.Text = "重命名当前配置";
			this.btn_Rename.UseVisualStyleBackColor = true;
			this.btn_Rename.Click += new System.EventHandler(this.btn_Rename_Click);
			// 
			// gbx_SpecialValue
			// 
			this.gbx_SpecialValue.Controls.Add(this.lbl_NoiseVal);
			this.gbx_SpecialValue.Controls.Add(this.tbx_NoiseVal);
			this.gbx_SpecialValue.Controls.Add(this.tbx_NoDataVal);
			this.gbx_SpecialValue.Controls.Add(this.label16);
			this.gbx_SpecialValue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gbx_SpecialValue.Location = new System.Drawing.Point(14, 442);
			this.gbx_SpecialValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_SpecialValue.Name = "gbx_SpecialValue";
			this.gbx_SpecialValue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gbx_SpecialValue.Size = new System.Drawing.Size(546, 68);
			this.gbx_SpecialValue.TabIndex = 40;
			this.gbx_SpecialValue.TabStop = false;
			this.gbx_SpecialValue.Text = "特殊值";
			// 
			// timer_editTC
			// 
			this.timer_editTC.Interval = 250;
			this.timer_editTC.Tick += new System.EventHandler(this.timer_editTC_Tick);
			// 
			// timer_waitErr
			// 
			this.timer_waitErr.Interval = 10000;
			this.timer_waitErr.Tick += new System.EventHandler(this.timer_waitErr_Tick);
			// 
			// frmTaskConf
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(576, 790);
			this.Controls.Add(this.gbx_SpecialValue);
			this.Controls.Add(this.gbx_Templete);
			this.Controls.Add(this.gbx_ClipExt);
			this.Controls.Add(this.gbx_DataType);
			this.Controls.Add(this.gbx_prj);
			this.Controls.Add(this.gbx_DataInfo);
			this.Controls.Add(this.gbx_Tolarence);
			this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTaskConf";
			this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "配置项目参数";
			this.TopMost = true;
			this.gbx_ClipExt.ResumeLayout(false);
			this.gbx_ClipExt.PerformLayout();
			this.gbx_DataType.ResumeLayout(false);
			this.gbx_DataType.PerformLayout();
			this.gbx_prj.ResumeLayout(false);
			this.gbx_prj.PerformLayout();
			this.gbx_DataInfo.ResumeLayout(false);
			this.gbx_DataInfo.PerformLayout();
			this.gbx_Tolarence.ResumeLayout(false);
			this.gbx_Tolarence.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_tfwPrec)).EndInit();
			this.gbx_Templete.ResumeLayout(false);
			this.gbx_Templete.PerformLayout();
			this.gbx_SpecialValue.ResumeLayout(false);
			this.gbx_SpecialValue.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btn_NewCfg;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cmbbx_tskcfgs;
		private System.Windows.Forms.Button btn_deleteCurr;
		private System.Windows.Forms.GroupBox gbx_ClipExt;
		private System.Windows.Forms.RichTextBox rtbx_ExtFormula;
		private System.Windows.Forms.ComboBox cmbbx_ExtFormula;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton rdbtn_ByPixel;
		private System.Windows.Forms.TextBox tbx_ClipExt;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.RadioButton rdbtn_ByMeter;
		private System.Windows.Forms.GroupBox gbx_DataType;
		private System.Windows.Forms.RadioButton rdbtn_DEM;
		private System.Windows.Forms.RadioButton rdbtn_CNSimg;
		private System.Windows.Forms.GroupBox gbx_prj;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbx_False_N;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbx_False_E;
		private System.Windows.Forms.TextBox tbx_CM;
		private System.Windows.Forms.TextBox tbx_ScaleFact;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbx_InvFlatt;
		private System.Windows.Forms.TextBox tbx_SemiMajor;
		private System.Windows.Forms.RadioButton rdbtn_PrjSys_wgs84;
		private System.Windows.Forms.RadioButton rdbtn_PrjSys_xian80;
		private System.Windows.Forms.RadioButton rdbtn_PrjSys_bj54;
		private System.Windows.Forms.RadioButton rdbtn_PrjSys_2000;
		private System.Windows.Forms.GroupBox gbx_DataInfo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbx_Resolution;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbx_BandCount;
		private System.Windows.Forms.RadioButton rdbtn_Depth_8;
		private System.Windows.Forms.RadioButton rdbtn_Depth_32;
		private System.Windows.Forms.RadioButton rdbtn_Depth_16;
		private System.Windows.Forms.GroupBox gbx_Tolarence;
		private System.Windows.Forms.Label lbl_HeighTolar;
		private System.Windows.Forms.TextBox tbx_HeightTolar;
		private System.Windows.Forms.Label lbl_PosTolar;
		private System.Windows.Forms.TextBox tbx_PosTolar;
		private System.Windows.Forms.GroupBox gbx_Templete;
		private System.Windows.Forms.RadioButton rdbtn_ImgSrc;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbx_BlkSize;
		private System.Windows.Forms.Label lbl_NoiseVal;
		private System.Windows.Forms.TextBox tbx_NoiseVal;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbx_NoDataVal;
		private System.Windows.Forms.Button btn_Rename;
		private System.Windows.Forms.Button btn_CopyCreate;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown nud_tfwPrec;
		private System.Windows.Forms.GroupBox gbx_SpecialValue;
		private System.Windows.Forms.Timer timer_editTC;
		private System.Windows.Forms.Timer timer_waitErr;
	}
}