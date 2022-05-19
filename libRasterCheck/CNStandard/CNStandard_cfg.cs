using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geodata
{
	public enum ProjSystem
	{
		wgs84,
		beijing54,
		xian80,
		cgcs2000,
	}

	public enum Hemisphere
	{
		N,
		S,
	}

	public enum LatDist
	{
		Low,
		High,
		CircumPolar,
	}

	public enum NeighbourIdx
	{
		NW, NN, NE,
		WW, CC, EE,
		SW, SS, SE,
	}

	/// <summary>
	/// 生成分幅计算参数
	/// </summary>
	public struct CalcConsts
	{
		/// <summary>
		/// 单位经纬差
		/// </summary>
		public double LI { get; set; }
		public double BI { get; set; }
		/// <summary>
		/// 投影带宽
		/// </summary>
		public double PrjWidth { get; set; }
		/// <summary>
		/// 每百万图分幅行列数目
		/// </summary>
		public uint MaxCowRow { get; set; }

		public CalcConsts(char c, LatDist ld)
		{
			var consts = CNSconst.Consts[c];
			LI = CNStandard.DEG(consts.LI[(int)ld]);
			BI = CNStandard.DEG(consts.BI);
			PrjWidth = consts.prjWidth;
			MaxCowRow = consts.maxColRow - 1;
		}
	}

	/// <summary>
	/// 国标分幅计算参数
	/// </summary>
	public static class CNSconst
	{
		// 单位经纬差，每行分别为{低纬经差，高纬经差，极圈经差，纬差，投影带宽, 百万图幅中分幅行列数}
		public static readonly Dictionary<char, (double[] LI, double BI, uint prjWidth, uint maxColRow)> Consts =
				new Dictionary<char, (double[] LI, double BI, uint prjWidth, uint maxColRow)>
		{
			//	1:1000000
			{ 'A', ( new[] { 6.0,		12.0,		24.0	}, 4.0,		6, 1	) },
			//	1:500000
			{ 'B', ( new[] { 3.0,		6.0,		12.0	}, 2.0,		6, 2	) },
			//	1:250000
			{ 'C', ( new[] { 1.3,		3.0,		6.0		}, 1.0,		6, 4	) },
			//	1:100000
			{ 'D', ( new[] { 0.3,		1.0,		2.0		}, 0.2,		6, 12	) },
			//	1:50000
			{ 'E', ( new[] { 0.15,		0.3,		1.0		}, 0.1,		6, 24	) },
			//	1:25000
			{ 'F', ( new[] { 0.073,		0.15,		0.3		}, 0.05,	3, 48	) },
			//	1:10000
			{ 'G', ( new[] { 0.0345,	0.073,		0.15	}, 0.023,	3, 96	) },
			//	1:5000
			{ 'H', ( new[] { 0.01525,	0.0345,		0.073	}, 0.0115,	3, 192	) },
			//	1:2000
			{ 'I', ( new[] { 0.00375,	0.0115,		0.023	}, 0.0025,	3, 576	) },
			//	1:1000
			{ 'J', ( new[] { 0.001875,	0.00375,	0.0115	}, 0.00125,	3, 1152	) },
			//	1:500
			{ 'K', ( new[] { 0.0009375,	0.001875,	0.00375	}, 0.000625,3, 2304	) },
		};
	}
}
