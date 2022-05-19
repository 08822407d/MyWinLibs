using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace geodata
{

	public partial class CNMapNo
	{
		public bool IsValid { get; }
		/// <summary>
		/// 南北半球标志
		/// </summary>
		public Hemisphere	HSflag { get; set; }
		public bool		hasHSflag { get; set; }

		/// <summary>
		/// 百万分幅行列号
		/// </summary>
		public int		MilRowNo { get; set; }
		public uint		MilColNo { get; set; }
		/// <summary>
		/// 百万图幅中分幅行列数
		/// </summary>
		public uint		MaxColRow { get; set; }

		/// <summary>
		/// 比例尺
		/// </summary>
		public char		Scale { get; set; }

		/// <summary>
		/// 分幅行列号
		/// </summary>
		public uint		RowNo { get; set; }
		public uint		ColNo { get; set; }

		public CNMapNo()
		{ }

		public CNMapNo(String MapNo)
		{
			this.hasHSflag = false;

			IsValid = parseMapNo(MapNo);
		}

		public override string ToString()
		{
			string HS = "";
			if (this.hasHSflag)
				HS = this.HSflag.ToString();
			string milrow = ((char)(this.MilRowNo + 'A' - 1)).ToString().PadLeft(1, '0');
			if (this.hasHSflag && this.HSflag == Hemisphere.S)
				milrow = ((char)(-this.MilRowNo + 'A')).ToString().PadLeft(1, '0');
			string milcow = (this.MilColNo + 1).ToString().PadLeft(2, '0');
			char scale = this.Scale;
			string row = (this.RowNo + 1).ToString().PadLeft(3, '0');
			string cow = (this.ColNo + 1).ToString().PadLeft(3, '0');

			return HS + milrow + milcow + scale + row + cow;
		}
	}

	public partial class CNStandard
	{
		/// <summary>
		/// 国标分幅图号
		/// </summary>
		public String	MapNo_str { get; set; }
		public CNMapNo	MapNo { get; set; }

		/// <summary>
		/// 四角坐标，经纬度和大地坐标
		/// </summary>
		public Extent2d	Extent_BL { get; set; }
		public Corners	Corners_XY { get; set; }

		/// <summary>
		/// 纬度地区（低纬，高纬，极圈）
		/// </summary>
		LatDist	LatDist { get; set; }
		/// <summary>
		/// 投影系，带号和中央子午线
		/// </summary>
		public int	ZoneNo { get; set; }
		public int	CentralMeridian { get; set; }

		/// <summary>
		/// 计算用参数
		/// </summary>
		CalcConsts CP { get; set; }

		/// <summary>
		/// 八邻
		/// </summary>
		public string [] Neighbours { get; set; }


		public CNStandard()
		{ }

		public CNStandard(String MapNo)
		{
			string mapno = MapNo.ToUpper();
			this.MapNo = new CNMapNo(mapno);
			if (this.MapNo.IsValid)
			{
				MapNo_str = mapno;
				Neighbours = new string[9];
				calcExtentBL();
			}
		}

		public override string ToString()
		{
			string ret_val = "";

			ret_val +=	"MapNo_str : " + base.ToString() + "\n" +
						"Scale : " + this.MapNo.Scale.ToString() +
						"; PrjZoneWidth : " + this.CP.PrjWidth.ToString() + "\n" +
						"ZoneNumber : " + this.ZoneNo.ToString() +
						"; CentralMeridian : " + this.CentralMeridian.ToString() + "\n" +
						"BLextent :\n" +
						"  Start -" + this.Extent_BL.Start.ToString() + "\n" +
						"  End   -" + this.Extent_BL.End.ToString() + "\n" +
						"Corners :\n" +
						"  UL -" + this.Corners_XY.UpperLeft.ToString() + "\n" +
						"  UR -" + this.Corners_XY.UpperRight.ToString() + "\n" +
						"  LR -" + this.Corners_XY.LowerRight.ToString() + "\n" +
						"  LL -" + this.Corners_XY.LowerLeft.ToString() + "\n";

			return ret_val;
		}
	}
}
