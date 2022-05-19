using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
	public partial class frmTXTInput : Form
	{
		public string ret_val = null;
		public frmTXTInput()
		{
			InitializeComponent();
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			this.ret_val = tbx_input.Text;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
