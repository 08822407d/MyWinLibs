using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace geodata
{
	public static class GeoUtils
	{
		public static void GenContour(Raster dem, double ContIntv, double Nodata, string ofname)
		{
			String input = dem.FileName;

			ProcessStartInfo psi = new ProcessStartInfo();
			psi.CreateNoWindow = false;
			psi.UseShellExecute = false;
			psi.FileName = "DEM2Contour.exe";
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			psi.Arguments = "-a elev " + "-i " + ContIntv + " " +
							 "-snodata " + Nodata + " " +
							 "\"" + input + "\"" + " " +
							 "\"" + ofname + "\"";

			try
			{
				// Start the process with the info we specified.
				// Call WaitForExit and then the using statement will close.
				using (Process exeProcess = Process.Start(psi))
				{
					exeProcess.WaitForExit();
				}
			}
			catch
			{
				 // Log error.
			}
		}

	}
}
