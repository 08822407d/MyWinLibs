using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using OSGeo.GDAL;
using OSGeo.OSR;
using OpenCvSharp;

namespace geodata
{
	public enum ClipExtFormula
	{
		NewFormula,
		OrigFormula,
	}

	public partial class Raster 
	{
		public String		FileName { get; }
		public CNStandard	CNS { get; set; }
		public double[][]	DataBuf { get; set; }
		public List<Raster>	Overlaps { get; set; }


		/// <summary>
		/// 分幅影像四角坐标
		/// </summary>
		public Extent2d		ImgExtent { get; set; }
		/// <summary>
		/// GDAL geo transform
		/// </summary>
		public double[]		Gt { get; set; }
		/// <summary>
		/// 像素尺寸/地面分辨率
		/// </summary>
		public Point2d		Resolution { get; set; }
		/// <summary>
		/// 影像尺寸，以像素计算
		/// </summary>
		public Point		ImgSize { get; set; }

		/// <summary>
		/// 影像波段数
		/// </summary>
		public int			BandCount { get; }
		/// <summary>
		/// 数据位宽，8/16/32位
		/// </summary>
		public DataType[]	Depths { get; }
		/// <summary>
		/// 对应数据位宽的最大值
		/// </summary>
		public double[]		LimitVals { get; set; }

		/// <summary>
		/// 数学基础
		/// </summary>
		// 投影系名称，长半轴，扁率
		public ProjSystem	PrjSys { get; set; }
		public double		SemiMajor { get; set; }
		public double		InvFlatt { get; set; }
		public double		ScaleFactor { get; set; }
		// 中央经线，坐标偏移
		public double		CentralMeridian { get; set; }
		public double		FalseEast { get; set; }
		public double		FalseNorth { get; set; }

		
		/// <summary>
		/// GDAL dataset
		/// </summary>
		public Dataset		Ds { get; }
		/// <summary>
		/// Gdal格式波段对象
		/// </summary>
		public Band[]		Bands { get; set; }
		/// <summary>
		/// GDAL data driver
		/// </summary>
		public Driver		Drv { get; }


		public Raster(String filename, TaskCfg TC)
		{
			if (File.Exists(filename))
			{
				// 投影系默认为2000系
				PrjSys = ProjSystem.cgcs2000;
				Ds		= Gdal.Open(filename, Access.GA_ReadOnly);

				if (Ds != null)
				{
					FileName	= filename;
					Drv			= Ds.GetDriver();
					// 影像信息
					BandCount	= Ds.RasterCount;
					Gt			= new double[6];
					ImgSize		= new Point(Ds.RasterXSize, Ds.RasterYSize);
					Depths		= new DataType[BandCount];
					Bands		= new Band[BandCount];
					LimitVals	= new double[BandCount];
					DataBuf		= new double[BandCount][];
					Overlaps	= new List<Raster>();

					Ds.GetGeoTransform(Gt);
					getResolution();
					getBandInfo();
					getImgExtent();
					parseProjInfo();

					string mapname = Path.GetFileNameWithoutExtension(filename);
					if (mapname.Length >= 10)
					{
						CNS	= new CNStandard(mapname.Substring(0, 10));
						if (!CNS.MapNo.IsValid)
						{
							CNS = new CNStandard(mapname.Substring(0, 11));
							if (!CNS.MapNo.IsValid)
								CNS = null;
						}
						if (CNS.MapNo.IsValid)
						{
							CNS.calcCornersXY(PrjSys);
							CNS.getNeighbour();
						}
					}
				}
			}
		}

		void getResolution()
		{
			Resolution = new Point2d(Gt[1], Gt[5]);
		}

        void getImgExtent()
        {
			// 外扩范围
			ImgExtent = new Extent2d(Pixel2Geo(new Point(0, 0)),
										Pixel2Geo(new Point(ImgSize.X - 1, ImgSize.Y - 1)));
        }

		void parseProjInfo()
		{
			string wkt = Ds.GetProjection();
			SpatialReference sr = new SpatialReference(wkt);

			string datum = sr.GetAttrValue("DATUM", 0);
			datum = datum.ToUpper();
			if (datum.Contains("WGS") && datum.Contains("84"))
				this.PrjSys = ProjSystem.wgs84;
			else if (datum.Contains("54"))
				this.PrjSys = ProjSystem.beijing54;
			else if (datum.Contains("80"))
				this.PrjSys = ProjSystem.xian80;
			else if (datum.Contains("CGCS") && datum.Contains("2000"))
				this.PrjSys = ProjSystem.cgcs2000;
			this.SemiMajor = sr.GetSemiMajor();
			this.InvFlatt = sr.GetInvFlattening();
			this.ScaleFactor = sr.GetProjParm(Osr.SRS_PP_SCALE_FACTOR, 0.0);

			this.CentralMeridian = sr.GetProjParm(Osr.SRS_PP_CENTRAL_MERIDIAN, 0.0);
			this.FalseEast = sr.GetProjParm(Osr.SRS_PP_FALSE_EASTING, 0.0);
			this.FalseNorth = sr.GetProjParm(Osr.SRS_PP_FALSE_NORTHING, 0.0);
		}

		void getBandInfo()
		{
			for (int i = 0; i < BandCount; i++)
			{
				Bands[i]	= Ds.GetRasterBand(i + 1);
				Depths[i]	= Bands[i].DataType;

				if (Depths[i] == DataType.GDT_Byte)
					LimitVals[i] = Byte.MaxValue;
				else if (Depths[i] == DataType.GDT_Int16)
					LimitVals[i] = Int16.MaxValue;
				else if (Depths[i] == DataType.GDT_UInt16)
					LimitVals[i] = UInt16.MaxValue;
			}
		}

		public override string ToString()
		{
			string ret_val = "";

			ret_val = "ImgSize : " + ImgSize.ToString() + "\n" +
						"BandCount : " + BandCount.ToString() +
						"; Depth : " + Depths[0].ToString() + "\n" +
						"ImgExtent :\n" +
						"  Start -" + ImgExtent.Start.ToString() + "\n" +
						"  End   -" + ImgExtent.End.ToString() + "\n" +
						"Datum : " + PrjSys.ToString() + "\n" +
						"SemiMajor : " + SemiMajor.ToString() + "\n" +
						"InvFlatt : " + InvFlatt.ToString() + "\n" +
						"ScaleFact : " + ScaleFactor.ToString() + "\n" +
						"CM : " + CentralMeridian.ToString() + "\n" +
						"False_E : " + FalseEast.ToString() + "\n" +
						"False_N : " + FalseNorth.ToString() + "\n";

			return ret_val;
		}

		public void getOverlapsByNeighbour(List<Raster> rlist)
		{
			foreach (Raster r in rlist)
			{
				if (r.CNS != null)
				{

					string rmn = r.CNS.getMapNoStr();
					string rmn_HSflag = rmn;
					if (rmn.Length == 10)
						rmn_HSflag = "N" + rmn;
					// 只获取东南角的邻接图幅
					if (rmn.Equals(this.CNS.Neighbours[5]) ||
						rmn_HSflag.Equals(this.CNS.Neighbours[5]))
						this.Overlaps.Add(r);
					if (rmn.Equals(this.CNS.Neighbours[6]) ||
						rmn_HSflag.Equals(this.CNS.Neighbours[6]))
						this.Overlaps.Add(r);
					if (rmn.Equals(this.CNS.Neighbours[7]) ||
						rmn_HSflag.Equals(this.CNS.Neighbours[7]))
						this.Overlaps.Add(r);
					if (rmn.Equals(this.CNS.Neighbours[8]) ||
						rmn_HSflag.Equals(this.CNS.Neighbours[8]))
						this.Overlaps.Add(r);
				}
			}
		}
	}
}
