using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSGeo.GDAL;
using OpenCvSharp;

using Utils;

namespace geodata
{
	public partial class Raster
	{
		/// <summary>
		/// 读取影像数据区
		/// </summary>
		public void ReadData()
		{
			for (int i = 0; i < this.BandCount; i++)
			{
				int x = this.ImgSize.X;
				int y = this.ImgSize.Y;
				this.DataBuf[i] = new double[x * y];
				this.Bands[i].ReadRaster(0, 0, x, y, this.DataBuf[i], x, y, 0 ,0);
			}
		}

		/// <summary>
		/// 像素坐标转地理坐标
		/// </summary>
		/// <param name="pixel"></param>
		/// <returns></returns>
		public Point2d Pixel2Geo(Point pixel)
		{
			Point2d retval = new Point2d();
			
            retval.X = this.Gt[0] + this.Gt[1] * (pixel.X + 0.5) + this.Gt[2] * (pixel.Y + 0.5);
            retval.Y = this.Gt[3] + this.Gt[4] * (pixel.X + 0.5) + this.Gt[5] * (pixel.Y + 0.5);

			return retval;
		}

		/// <summary>
		/// 地理坐标转像素坐标
		/// </summary>
		/// <param name="geo"></param>
		/// <returns></returns>
		public Point Geo2Pixel(Point2d geo)
		{
			Point retval = new Point();

			retval.X = (int)(geo.X - this.ImgExtent.Start.X) / this.ImgSize.X;
			retval.Y = (int)(geo.Y - this.ImgExtent.Start.Y) / this.ImgSize.Y;

			return retval;
		}

		/// <summary>
		/// 计算本影像与其他影像的重叠区，以地理坐标表示
		/// </summary>
		/// <param name="img"></param>
		/// <returns></returns>
		public Extent2d getOverlapGeo(Raster img)
		{
			double sx, sy, ex, ey;
			sx = Math.Max(this.ImgExtent.Start.X, img.ImgExtent.Start.X);
			sy = Math.Min(this.ImgExtent.Start.Y, img.ImgExtent.Start.Y);
			ex = Math.Min(this.ImgExtent.End.X, img.ImgExtent.End.X);
			ey = Math.Max(this.ImgExtent.End.Y, img.ImgExtent.End.Y);

			return new Extent2d(new Point2d(sx, sy), new Point2d(ex, ey));
		}
		/// <summary>
		/// 计算本影像与其他影像的重叠区，以像素坐标表示
		/// </summary>
		/// <param name="img"></param>
		/// <returns></returns>
		public Extent getOverlapPixel(Raster img)
		{
			Extent2d ovlpGeo = getOverlapGeo(img);
			return new Extent(Geo2Pixel(ovlpGeo.Start),
								Geo2Pixel(ovlpGeo.End));
		}

		/// <summary>
		/// 获取指定值的像素
		/// </summary>
		/// <param name="val"></param>
		public List<Point2d> getPixByVal(double[] val)
		{
			List<Point2d> retval = new List<Point2d>();
			int x = this.ImgSize.X;
			int y = this.ImgSize.Y;

			for (int i = 0; i < x * y; i++)
			{
				bool equal = true;
				for (int j = 0; j < this.BandCount; j++)
				{
					equal &= (this.DataBuf[j][i] == val[j]);
				}
				if (equal)
				{
					retval.Add(Pixel2Geo(new Point(i % x, i / x)));
				}
			}

			return retval;
		}

	}
}
