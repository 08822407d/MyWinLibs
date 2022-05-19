using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
	public static class UI
	{
		public static void units_disable(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
        }

        public static void units_enable(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
        }

	}
}
