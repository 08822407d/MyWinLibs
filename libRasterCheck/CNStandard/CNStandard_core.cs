using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

using Utils;

namespace geodata
{
	public partial class CNMapNo
	{
		bool parseMapNo(String MapNo)
		{
			if (MapNo.Length != 10 &&
				MapNo.Length != 11)
				return false;
			// 处理全球测图专用图号
			if (MapNo.Length == 11)
			{
				String HSflag = MapNo.Substring(0, 1).ToUpper();
				if (HSflag.Equals("N"))
					this.HSflag = Hemisphere.N;
				else if (HSflag.Equals("S"))
					this.HSflag = Hemisphere.S;
				else
					return false;
				this.hasHSflag = true;
				MapNo = MapNo.Substring(1);
			}

			// 图号提取行列号
			// 百万行号
			// 北半球百万行号A等于0
			if (MapNo[0] < 'A' || MapNo[0] > 'V')
				return false;
			// 百万列号
			uint mil_cow = 0;
			if (!uint.TryParse(MapNo.Substring(1, 2), out mil_cow))
				return false;
			if (mil_cow < 1 || mil_cow > 60)
				return false;
			// 比例尺
			char sc = MapNo[3];
			if (sc < 'A' || sc > 'K')
				return false;
			// 最大行列数
			uint mcr = CNSconst.Consts[sc].maxColRow;
			// 行号
			uint row = 0;
			if (!uint.TryParse(MapNo.Substring(4, 3), out row))
				return false;
			if (row < 1 || row > mcr)
				return false;
			// 列号
			uint cow = 0;
			if (!uint.TryParse(MapNo.Substring(7, 3), out cow))
				return false;
			if (cow < 1 || cow > mcr)
				return false;
			
			// 数值全部合法
			this.ColNo = UInt32.Parse(MapNo.Substring(7,3)) - 1;
			this.MilRowNo = MapNo.Substring(0, 1)[0] - 'A' + 1;
			// 南半球百万行号A等于-1
			if (this.hasHSflag && this.HSflag == Hemisphere.S)
				this.MilRowNo = 'A' - MapNo.Substring(0, 1)[0];
			this.MilColNo = mil_cow - 1;
			this.Scale = sc;
			this.RowNo = row - 1;
			this.MaxColRow = mcr;
			return true;
		}

		/// <summary>
		/// 行号加
		/// </summary>
		public void row_Inc()
		{
			if (this.RowNo == (this.MaxColRow - 1))
			{
				this.RowNo = 0;
				// 行号加则百万行号减
				if (this.HSflag == Hemisphere.N &&
					this.MilRowNo == 1)
					this.HSflag = Hemisphere.S;
				this.MilRowNo--;
			}
			else
				this.RowNo++;
		}
		/// <summary>
		/// 行号减
		/// </summary>
		public void row_dec()
		{
			if (this.RowNo == 0)
			{
				this.RowNo = this.MaxColRow - 1;
				// 行号减则百万行号加
				if (this.HSflag == Hemisphere.S &&
					this.MilRowNo == 0)
					this.HSflag = Hemisphere.N;
				this.MilRowNo++;
			}
			else
				this.RowNo--;
		}
		/// <summary>
		/// 列号加
		/// </summary>
		public void col_inc()
		{
			if (this.ColNo == (this.MaxColRow - 1))
			{
				this.ColNo = 0;
				// 列号加则百万列号加
				this.MilColNo = (this.MilColNo + 60 + 1) % 60;
			}
			else
				this.ColNo++;
		}
		/// <summary>
		/// 列号减
		/// </summary>
		public void col_dec()
		{
			if (this.ColNo == 0)
			{
				this.ColNo = this.MaxColRow - 1;
				// 列号减则百万列号减
				this.MilColNo = (this.MilColNo + 60 - 1) % 60;
			}
			else
				this.ColNo--;
		}
	}

	public partial class CNStandard
	{
		public string getMapNoStr()
		{
			return this.MapNo.ToString();
		}

		/// <summary>
		/// 计算裁切范围
		/// </summary>
		public Extent2d getClipExtent(Point2d resol, uint extwidth_pixel, ClipExtFormula CEF)
		{
			if (resol.Y < 0)
				resol.Y *= -1;

			double maxX = Const.minX;
			double maxY = Const.minY;
			double minX = Const.maxX;
			double minY = Const.maxY;

			Point2d[] corners = {this.Corners_XY.UpperLeft,
								this.Corners_XY.UpperRight,
								this.Corners_XY.LowerRight,
								this.Corners_XY.LowerLeft};
			for (int i = 0; i < 4; i++)
			{
				Point2d pt = corners[i];
				if (pt.X > maxX) maxX = pt.X;
				if (pt.X < minX) minX = pt.X;
				if (pt.Y > maxY) maxY = pt.Y;
				if (pt.Y < minY) minY = pt.Y;
			}

			double	sx = Const.minX,
					sy = Const.minY,
					ex = Const.minX,
					ey = Const.minY;
			// CH/T 9008.3 - 2010 (1:500 1:1000 1:2000)
			// CH/T 9009.3 - 2010 (1:10000 1:50000)
			if (CEF == ClipExtFormula.NewFormula)
			{
				sx = (int)((minX - resol.X * extwidth_pixel) /
						resol.X) * resol.X;
				sy = (int)((maxY - resol.Y * extwidth_pixel) /
						resol.Y) * resol.Y;
				ex = (int)((maxX + resol.X * extwidth_pixel) /
						resol.X) * resol.X;
				ey = (int)((minY + resol.Y * extwidth_pixel) /
						resol.Y) * resol.Y;
			}
			else if (CEF == ClipExtFormula.OrigFormula)
			// 原计算公式
			{
				sx = (int)(minX / resol.X) * resol.X -
						extwidth_pixel * resol.X;
				sy = ((int)(maxY / resol.Y) - 1) * resol.Y -
						extwidth_pixel * resol.Y;
				ex = (int)((maxX / resol.X) + 1) * resol.X +
						extwidth_pixel * resol.X;
				ey = (int)(minY / resol.Y) * resol.Y +
						extwidth_pixel * resol.Y;
			}

			return new Extent2d(new Point2d(sx, sy), new Point2d(ex, ey));
		}

		/// <summary>
		/// 获取八邻
		/// </summary>
		public void getNeighbour()
		{
			/* ------------- */
			/* | 0 | 1 | 2 | */
			/* |-----------| */
			/* | 3 | 4 | 5 | */
			/* |-----------| */
			/* | 6 | 7 | 8 | */
			/* ------------- */

			// 自己
			string selfMapNo = this.MapNo_str;
			if (selfMapNo.Length == 10)
				selfMapNo = "N" + this.MapNo_str;
			this.Neighbours[4] = selfMapNo;

			CNStandard tmp = new CNStandard(selfMapNo);
			CNMapNo tmpMN = tmp.MapNo;
			// 正北
			tmpMN.row_dec();
			this.Neighbours[1] = tmp.getMapNoStr();
			// 东北
			tmpMN.col_inc();
			this.Neighbours[2] = tmp.getMapNoStr();
			// 正东
			tmpMN.row_Inc();
			this.Neighbours[5] = tmp.getMapNoStr();
			// 东南
			tmpMN.row_Inc();
			this.Neighbours[8] = tmp.getMapNoStr();
			// 正南
			tmpMN.col_dec();
			this.Neighbours[7] = tmp.getMapNoStr();
			// 西南
			tmpMN.col_dec();
			this.Neighbours[6] = tmp.getMapNoStr();
			// 正西
			tmpMN.row_dec();
			this.Neighbours[3] = tmp.getMapNoStr();
			// 西北
			tmpMN.row_dec();
			this.Neighbours[0] = tmp.getMapNoStr();

			// 如果不是全球测图，则删除高纬度和南半球图号
			if (!tmpMN.hasHSflag)
			{
				if (tmpMN.MilRowNo == 1)
					this.Neighbours[6] =
					this.Neighbours[7] =
					this.Neighbours[8] = null;
				if (tmpMN.MilRowNo == 16)
					this.Neighbours[0] =
					this.Neighbours[1] =
					this.Neighbours[2] = null;
			}
		}

		// CalMapXYBL
		/// <summary>
		/// 计算四角坐标	
		/// </summary>
		void calcExtentBL()
		{
			CNMapNo thisMN = this.MapNo;
			// 图号提取算参数,计算百万图幅起点经纬度
			double mil_B = 0, mil_L = 0,
					milBI = 4, milLI = 0;
			int milrow = thisMN.MilRowNo;
			if (thisMN.hasHSflag && thisMN.HSflag == Hemisphere.S)
			{
				milrow = -milrow + 1;
			}
			mil_B = milrow * milBI;
			// 低纬度
			if (milrow <= 14)
			{
				this.LatDist = LatDist.Low;
				mil_L = (thisMN.MilColNo - 30) * 6;
			}
			// 高纬度
			else if (milrow > 14 && milrow <= 18)
			{
				this.LatDist = LatDist.High;
				mil_L = (thisMN.MilColNo - 15) * 12;
			}
			// 极圈
			else
			{
				this.LatDist = LatDist.CircumPolar;
				mil_L = (thisMN.MilColNo - 7.5) * 24;
			}
			this.CP = new CalcConsts(thisMN.Scale, this.LatDist);

			// 计算四角经纬度
			// 左上角
			Point2d UL_BL = new Point2d(mil_L + thisMN.ColNo * this.CP.LI,
										mil_B - thisMN.RowNo * this.CP.BI);
			// 右上角
			Point2d UR_BL = new Point2d(UL_BL.X + this.CP.LI, UL_BL.Y);
			// 右下角
			Point2d LR_BL = new Point2d(UR_BL.X, UL_BL.Y - this.CP.BI);
			// 左下角
			Point2d LL_BL = new Point2d(UL_BL.X, LR_BL.Y);
			this.Extent_BL = new Extent2d(UL_BL, LR_BL);

			if (this.CP.PrjWidth == 3)
			{
				this.CentralMeridian = (int)(UL_BL.X / 3 + 0.5000001) * 3;
				this.ZoneNo = this.CentralMeridian / 3;
			}
			else
			{
				this.CentralMeridian = (int)(UL_BL.X / 6 + 1) * 6 - 3;
				this.ZoneNo = this.CentralMeridian / 6 + 1;
			}

			return;
		}

		public void calcCornersXY(ProjSystem prjsys)
		{
			// 如果坐标系统为WGS84，并且为UTM投影。
			// UTM投影的起始经线为西经180度。
			// 注：UTM墨卡托投影均为6度分带！！！！！
			if (prjsys == ProjSystem.wgs84)
				this.ZoneNo += 30;

			// 左上角
			Point2d UL_BL = this.Extent_BL.Start;
			// 右下角
			Point2d LR_BL = this.Extent_BL.End;
			// 右上角
			Point2d UR_BL = new Point2d(LR_BL.X, UL_BL.Y);
			// 左下角
			Point2d LL_BL = new Point2d(UL_BL.X, LR_BL.Y);
			// 经纬度换算大地坐标
			Point2d UL_XY = new Point2d();
			Point2d UR_XY = new Point2d();
			Point2d LR_XY = new Point2d();
			Point2d LL_XY = new Point2d();
			BL2XY(UL_BL, ref UL_XY, prjsys, this.CentralMeridian);
			BL2XY(UR_BL, ref UR_XY, prjsys, this.CentralMeridian);
			BL2XY(LL_BL, ref LL_XY, prjsys, this.CentralMeridian);
			BL2XY(LR_BL, ref LR_XY, prjsys, this.CentralMeridian);
			this.Corners_XY = new Corners(UL_XY, UR_XY, LR_XY, LL_XY);
		}

		// DEG
		/// <summary>
		/// 国标六十进制经纬度表示换算十进制小数表示
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static double DEG(double input)
		{
			int d, m, sign;
			double s, angle;

			sign = Math.Sign(input);
			input = Math.Abs(input);

			d = (int)input;
			m = (int)Math.Round((input - d) * 100, 10);
			s = (Math.Round((input - d) * 100, 10) - m) * 100;

			angle = sign * (d + m / 60.0 + s / 3600.0);

			return angle;
		}

		// BL2XY
		/// <summary>
		/// 经纬度换算大地坐标
		/// </summary>
		/// <param name="BL"></param>
		/// <param name="XY"></param>
		/// <param name="PrjSys"></param>
		/// <param name="CM"></param>
		public static void BL2XY(Point2d BL, ref Point2d XY, ProjSystem PrjSys, double CM)
		{
			double e, ci, c0, c1, c2, c3, r;
			e = ci = c0 = c1 = c2 = c3 = 0;
			r = 0.0174532925199;

			switch (PrjSys)
			{
				case ProjSystem.wgs84:
				{
					e	= 0.0067394967422764341;
					ci	= 6399593.62575849;
					c0	= 6367449.14582341;
					c1	= 32009.8185305927;
					c2	= 133.959889703456;
					c3	= 0.697551236971508;
					break;
				}
				case ProjSystem.beijing54:
				{
					e	= 0.006738525414683;
					ci	= 6399698.90178271;
					c0	= 6367558.49687;
					c1	= 32005.7801;
					c2	= 133.9213;
					c3	= 0.7032;
					break;
				}
				case ProjSystem.xian80:
				{
					e = 0.006739501819473;
					ci = 6399596.65198801;
					c0 = 6367452.13279;
					c1 = 32009.8575;
					c2 = 133.9602;
					c3 = 0.6976;
					break;
				}
				case ProjSystem.cgcs2000:
				{
					e = 0.00673949677548;
					ci = 6399593.62586;
					c0 = 6367449.145771;
					c1 = 32009.818687;
					c2 = 133.959891;
					c3 = 0.69755;
					break;
				}
			}

			double L = BL.X * Math.PI / 180;
			double B = BL.Y * Math.PI / 180;

			double yl;
			double s, c, t, t2, H2, h;
			double B0, R1, YL1, w;

			yl = L;
			s = Math.Sin(B);
			c = Math.Cos(B);
			t = s / c;
			t2 = t * t;
			H2 = e * c * c;
			h = ci / Math.Sqrt(1.0 + H2);
			B0 = c0 * B - c1 * c * s - c2 * c * Math.Pow(s, 3) - c3 * c * Math.Pow(s, 5);
			R1 = CM;
			YL1 = yl - R1 * r;
			w = YL1 * c;

			XY.Y = B0 + h * t * w * w * 0.5 + h * t * Math.Pow(w, 4) * (5.0 - t2 + 9.0 * H2 + 4.0 * H2 * H2) / 24.0
					+ h * t * Math.Pow(w, 6) * (61.0 - 58.0 * t2 + t2 * t2) / 720.0;
			XY.X = 500000.0 + h * w + h * Math.Pow(w, 3) * (1.0 - t2 + H2) / 6.0 +
					h * Math.Pow(w, 5) * (5.0 - 18.0 * t2 + t2 * t2 + 14.0 * H2 - 58.0 * H2 * t2) / 120.0;

			// 子午线收敛角
			double RR;
			RR = t * w + t * Math.Pow(w, 3) * (1.0 + 3.0 * H2 + 2.0 * H2 * H2) / 3.0 +
					t * Math.Pow(w, 5) * (2.0 - t2) / 15.0;
			RR = RR * 180 / Math.PI;
		}
	}

}
