using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using OSGeo.GDAL;
using OpenCvSharp;

namespace geodata
{
	public class CheckResult
	{
		public string PrjSys { get; set; }
		public string PrjOther { get; set; }
		public string ColorMode { get; set; }
		public string DataInfo { get; set; }
	}

	public class CheckTask
	{
		public bool output_onefile = true;

		CfgPack Cfgs;
		CheckItem ci;
		TaskCfg tc;

		List<Raster> raster_list;
		List<string> tfw_list;
		List<CheckResult> chk_results;

		public CheckTask(CfgPack cfgs)
		{
			raster_list = new List<Raster>();
			chk_results = new List<CheckResult>();

			this.Cfgs = cfgs;
			this.ci= cfgs.getChkItems();
			this.tc = cfgs.getTC(cfgs.getLastTCname());
		}

		public void setDataList(List<string> file_list)
		{
			foreach (string f in file_list)
			{
				Raster r = new Raster(f, tc);
				if (r != null)
				{
					raster_list.Add(r);
				}
			}
		}

		public void setTFWList(List<string> tfws)
		{
			this.tfw_list = tfws;
		}

		public void checkAll()
		{
			string opath = this.Cfgs.getAutoChkOPath();

			Check.checkCNSMapNo(raster_list, Path.Combine(opath, "InvalidMapNo.txt"));
			string prj_total = Path.Combine(opath, "投影检查.txt");
			string colormode_total = Path.Combine(opath, "色彩模式检查.txt");
			string datainfo_total = Path.Combine(opath, "其他数据信息.txt");
			string imgedge_total = Path.Combine(opath, "影像接边检查.txt");
			string imgnoise_total = Path.Combine(opath, "影像噪音检查.txt");
			string demedge_total = Path.Combine(opath, "DEM接边检查.txt");

			StreamWriter sw_prj = new StreamWriter(prj_total, true);
			StreamWriter sw_colormode = new StreamWriter(colormode_total, true);
			StreamWriter sw_datainfo = new StreamWriter(datainfo_total, true);

			foreach (Raster r in raster_list)
			{
				if (r.CNS == null)
					continue;

				r.getOverlapsByNeighbour(this.raster_list);

				string opath_with_mapno = Path.Combine(opath, r.CNS.MapNo_str);
				string general_ofname = Path.Combine(opath_with_mapno, "GeneralResult.txt");
				string noise_ofname = Path.Combine(opath_with_mapno, "ImageNoise.txt");
				string imgedge_ofpath = Path.Combine(opath_with_mapno, "ImgEdge");
				string demedge_ofpath = Path.Combine(opath_with_mapno, "DEMEdge");
				if (!Directory.Exists(imgedge_ofpath))
					Directory.CreateDirectory(imgedge_ofpath);
				if (!Directory.Exists(demedge_ofpath))
					Directory.CreateDirectory(demedge_ofpath);

				if (!Directory.Exists(opath_with_mapno))
					Directory.CreateDirectory(opath_with_mapno);
				CheckResult cr = new CheckResult();

				Check.checkProjSystem(r, tc, cr);
				Check.checkProjOther(r, tc, cr);
				Check.checkColorMode(r, tc, cr);
				Check.checkDataInfo(r, tc, cr);
				Check.checkClipExtent(r, tc, cr);
				if (ci.ImgNoise)
					Check.checkNoise(r, tc, noise_ofname);
				if (ci.ImgEdgeMatch)
					Check.checkImgEdge(r, tc, imgedge_ofpath);
				if (ci.DemEdgeMatch)
					Check.checkDemEdge(r, tc, demedge_ofpath);
				chk_results.Add(cr);

				// 为每个数据文件输出独立检查报告
				if (!output_onefile)
				{
					StreamWriter sw_seperate = new StreamWriter(general_ofname, false);
					if (ci.PrjSys)
						sw_seperate.WriteLine(cr.PrjSys);
					if (ci.PrjOther)
						sw_seperate.WriteLine(cr.PrjOther);
					if (ci.ColorMode)
						sw_seperate.WriteLine(cr.ColorMode);
					if (ci.DataInfo)
						sw_seperate.WriteLine(cr.DataInfo);
					sw_seperate.Flush();
					sw_seperate.Close();
				}
				// 为所有数据文件的单项检查创建共用检查报告
				else
				{
					if (ci.PrjSys && cr.PrjSys != null && !cr.PrjSys.Equals(""))
					{
						sw_prj.WriteLine("图号：" + r.CNS.getMapNoStr());
						sw_prj.WriteLine(cr.PrjSys + "\n");
					}
					if (ci.PrjOther && cr.PrjOther != null && !cr.PrjOther.Equals(""))
					{
						sw_prj.WriteLine("图号：" + r.CNS.getMapNoStr());
						sw_prj.WriteLine(cr.PrjOther + "\n");
					}
					if (ci.ColorMode && cr.ColorMode != null && !cr.ColorMode.Equals(""))
					{
						sw_colormode.WriteLine("图号：" + r.CNS.getMapNoStr());
						sw_colormode.WriteLine(cr.ColorMode + "\n");
					}
					if (ci.DataInfo && cr.DataInfo != null && !cr.DataInfo.Equals(""))
					{
						sw_datainfo.WriteLine("图号：" + r.CNS.getMapNoStr());
						sw_datainfo.WriteLine(cr.DataInfo + "\n");
					}
					if (ci.ImgNoise)
					{
						string[] lines = File.ReadAllLines(noise_ofname);
						File.WriteAllLines(imgnoise_total, lines);
					}
					if (ci.ImgEdgeMatch)
					{
						string[] files = Utils.FIO.traverseSearchFile_Ext(imgedge_ofpath, ".txt").ToArray();
						Utils.FIO.mergeTextFiles(files, imgedge_total, true);
					}
					if (ci.DemEdgeMatch)
					{
						string[] files = Utils.FIO.traverseSearchFile_Ext(demedge_ofpath, ".txt").ToArray();
						Utils.FIO.mergeTextFiles(files, imgedge_total, true);
					}

					sw_prj.Flush();
					sw_colormode.Flush();
					sw_datainfo.Flush();
				}

			}

			sw_prj.Close();
			sw_colormode.Close();
			sw_datainfo.Close();

			string TFWPrec_total = Path.Combine(opath, "TFW格式检查.txt");
			string cr_str = "";
			foreach (string f in tfw_list)
			{
				if (ci.OtherFile)
					Check.checkTFWPrec(f, tc, ref cr_str);
			}
			StreamWriter sw_tfwp = new StreamWriter(TFWPrec_total);
			sw_tfwp.Write(cr_str);
			sw_tfwp.Flush();
			sw_tfwp.Close();
		}
	}

	public static class Check
	{
		public static void checkCNSMapNo(List<Raster> rlist, string ofname)
		{
			StreamWriter sw = new StreamWriter(ofname);

			foreach (Raster r in rlist)
				if (r.CNS == null)
					sw.WriteLine(r.FileName);

			sw.Flush();
			sw.Close();
		}

		public static void checkProjSystem(Raster img, TaskCfg tc, CheckResult cr)
		{
			if (tc.PrjSys != img.PrjSys)
				cr.PrjSys += "投影系统错误: " + img.PrjSys.ToString() + "\n";
			if (tc.SemiMajor != img.SemiMajor)
				cr.PrjSys += "半长轴错误: " + img.SemiMajor.ToString() + "\n";
			if (tc.InvFlatt != img.InvFlatt)
				cr.PrjSys += "扁率错误: " + img.InvFlatt.ToString() + "\n";
		}

		public static void checkProjOther(Raster img, TaskCfg tc, CheckResult cr)
		{
			if (tc.CentralMeridian != img.CentralMeridian)
				cr.PrjOther += "中央经线错误: " + img.CentralMeridian.ToString() + "\n";
			if (tc.FalseEast != img.FalseEast)
				cr.PrjOther += "坐标东移错误: " + img.FalseEast.ToString() + "\n";
			if (tc.FalseNorth != img.FalseNorth)
				cr.PrjOther += "坐标东移错误: " + img.FalseNorth.ToString() + "\n";
		}

		public static void checkColorMode(Raster img, TaskCfg tc, CheckResult cr)
		{
			if (tc.BandCount != img.BandCount)
				cr.ColorMode += "波段数错误: " + img.BandCount.ToString() + "\n";
			if (tc.Depth != img.Depths[0])
				cr.ColorMode += "位深度错误: " + img.Depths[0].ToString() + "\n";
		}

		public static void checkDataInfo(Raster img, TaskCfg tc, CheckResult cr)
		{
			if (tc.Resolution != img.Resolution.X)
				cr.DataInfo += "地面分辨率错误: " + img.Resolution.X.ToString() + "\n";
			
			if (tc.BlkSize != img.BlockSize[0, 0])
				cr.DataInfo += "块尺寸错误: " + img.BlockSize[0, 0].ToString() + "\n";
		}

		public static void checkClipExtent(Raster img, TaskCfg tc, CheckResult cr)
		{
			Extent2d diff = new Extent2d();
			Extent2d CE = img.CNS.getClipExtent(img.Resolution, tc.ClipExtent, tc.ExtFormula);
			diff = CE - img.ImgExtent;

			if (diff.Start.X != 0 ||
				diff.Start.Y != 0 ||
				diff.End.X != 0 ||
				diff.End.Y != 0)
				cr.DataInfo += "裁切范围有误:\n\t理论值: {" + CE.Start.ToString() + " , " +
							CE.End.ToString() + "};\n\t" +
							"实际值: {" + img.ImgExtent.Start.ToString() + " , " +
							img.ImgExtent.End.ToString() + "};";
		}

		public static void checkNoise(Raster img, TaskCfg tc, string ofname)
		{
			double[] white = img.LimitVals;
			double[] black = new double[img.BandCount];
			for (int i = 0; i < img.BandCount; i++)
				black[i] = 0;

			img.ReadData();
			List<Point2d> whitePts = img.getPixByVal(white);
			List<Point2d> blackPts = img.getPixByVal(black);

			StreamWriter sw = new StreamWriter(ofname);
			sw.WriteLine("白点:");
			foreach (Point2d pt in whitePts)
			{
				sw.WriteLine(pt.X.ToString() + "," + pt.Y.ToString());
			}
			sw.Flush();
			sw.WriteLine("黑点:");
			foreach (Point2d pt in blackPts)
			{
				sw.WriteLine(pt.X.ToString() + "," + pt.Y.ToString());
			}
			sw.Flush();
			sw.Close();
		}

		public static void checkAltitudeMSE(Raster dem, List<Point2d> pts, double limit, string ofname)
		{
			double MSE = 0;
			StreamWriter sw = new StreamWriter(ofname);
			foreach (Point2d pt in pts)
			{
				Point pt_pix = dem.Geo2Pixel(pt);
				double val = dem.DataBuf[0][pt_pix.X + pt_pix.Y * dem.ImgSize.X];
				sw.WriteLine(pt.X.ToString() + "," + pt.Y.ToString() + "," + val.ToString());
				MSE += val * val;
			}
			MSE /= pts.Count - 1;
			sw.WriteLine("");
			sw.WriteLine("MSE : " + MSE.ToString());

			sw.Flush();
			sw.Close();
		}

		public static void checkDemEdge(Raster dem1, TaskCfg tc, string ofpath)
		{
			foreach (Raster dem2 in dem1.Overlaps)
			{
				string ofname = Path.Combine(ofpath, dem1.CNS.MapNo_str + "-" +
											dem2.CNS.MapNo_str + ".txt");
				Extent ovlp1 = dem1.getOverlapPixel(dem2);
				Extent ovlp2 = dem2.getOverlapPixel(dem1);
				int width = ovlp1.Width;
				int height = ovlp1.Height;
				long imgsize = ovlp1.Area;
				Debug.Assert((width == ovlp2.Width) &&
								(height == ovlp2.Height) &&
								(imgsize == ovlp2.Area));

				double[] buf1 = new double[imgsize];
				double[] buf2 = new double[imgsize];
				dem1.Bands[1].ReadRaster(ovlp1.Start.X, ovlp1.Start.Y, width, height,
											buf1, width, height, 0, 0);
				dem2.Bands[1].ReadRaster(ovlp2.Start.X, ovlp2.Start.Y, width, height,
											buf2, width, height, 0, 0);

				StreamWriter sw = new StreamWriter(ofname);
				for (long i = 0; i < imgsize; i++)
				{
					double val = buf1[i] - buf2[i];
					if (val >= tc.HeightDiffTolarence)
					{
						Point2d pt = dem1.Pixel2Geo(new Point((int)(i % width) + ovlp1.Start.X,
												(int)(i / height) + ovlp1.Start.Y));
						sw.WriteLine(pt.X.ToString() + "," + pt.Y.ToString() + "," + val.ToString());
					}
				}
				sw.Flush();
				sw.Close();
			}
		}

		public static void checkImgEdge(Raster img1, TaskCfg tc, string ofpath)
		{
			foreach (Raster img2 in img1.Overlaps)
			{
				Debug.Assert(img1.PrjSys == img2.PrjSys);
				string ofname = Path.Combine(ofpath, img1.CNS.MapNo_str + "-" +
											img2.CNS.MapNo_str + ".txt");
				double NN_SQ_DIST_RATIO_THR = 0.3;
				double matchType = 0;

				ProcessStartInfo psi = new ProcessStartInfo();
				psi.RedirectStandardError = false;
				psi.RedirectStandardOutput = false;
				psi.UseShellExecute = true;
				psi.CreateNoWindow = true;
				psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				psi.ErrorDialog = false;
				psi.WorkingDirectory = System.Windows.Forms.Application.StartupPath + @"\lib64\geolib";
				psi.FileName = @".\siftMatch.exe";
				psi.WindowStyle = ProcessWindowStyle.Hidden;
				psi.Arguments = "19900413 " +
								"\"" + img1.FileName + "\" " +
								"\"" + img2.FileName + "\" " +
								"\"" + ofname + "\" " +
								NN_SQ_DIST_RATIO_THR.ToString() + " " +
								matchType.ToString();

				try
				{
					// Start the process with the info we specified.
					// Call WaitForExit and then the using statement will close.
					Process exeProcess = Process.Start(psi);
					exeProcess.EnableRaisingEvents = false;

					exeProcess.WaitForExit();
					exeProcess.Close();
					exeProcess.Dispose();
				}
				catch
				{
					 // Log error.
				}

				if (File.Exists(ofname))
				{
					string[] allpts = File.ReadAllLines(ofname);
					List<string> results = new List<string>();
					foreach (string line in allpts)
					{
						string[] pt_fields = line.Split(',');
						if (pt_fields.Length != 5)
							continue;

						double diff = 0;
						if (!double.TryParse(pt_fields[4], out diff))
							continue;

						if (diff >= tc.PositionDiffTolarence)
							results.Add(line);
					}
					File.WriteAllLines(ofname, results);
				}
			}
		}

		public static void checkTFWPrec(string fname, TaskCfg tc, ref string cr)
		{
			bool error = false;
			string[] lines = File.ReadAllLines(fname);
			foreach (string line in lines)
			{
				if ((line.Length - line.IndexOf('.') - 1) != tc.TFWPrec)
					error |= true;
			}

			if (error)
				cr += Path.GetFileNameWithoutExtension(fname) + "\n";
		}
	}
}
