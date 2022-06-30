using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
	public static class UI
	{
		public static bool isContainer(Control Ctrl)
		{
			return true;
		}

		public static void units_disable(Control.ControlCollection Ctrls)
        {
            foreach (Control c in Ctrls)
            {
                c.Enabled = false;
            }
        }

        public static void units_enable(Control.ControlCollection Ctrls)
        {
            foreach (Control c in Ctrls)
            {
                c.Enabled = true;
            }
        }

		public static void shrinkContainer_NotAutoSize(Control Container)
		{
			PropertyInfo pi_asm = Container.GetType().GetProperty("AutoSizeMode");
			pi_asm.SetValue(Container, AutoSizeMode.GrowAndShrink);
			PropertyInfo pi_as = Container.GetType().GetProperty("AutoSize");
			pi_as.SetValue(Container, true);

			int width = Container.Width;
			int height = Container.Height;

			pi_as.SetValue(Container, false);
			Container.Width = width;
			Container.Height = height;
		}
	}
}
