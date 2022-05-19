using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace geodata
{
		public struct Extent
	{
		public Point	Start;
		public Point	End;

		public int		Width;
		public int		Height;
		public long		Area;

		public Extent(Point s, Point e)
		{
			this.Start	= s;
			this.End	= e;

			this.Width	= e.X - s.X;
			this.Height = s.Y - e.Y;
			this.Area	= this.Width * this.Height;
		}
		
		public static Extent operator- (Extent a, Extent b)
		{
			return new Extent(a.Start - b.Start,
								a.End - b.End);
		}

		public bool Equals(Extent b)
		{
			return (this.Start == b.Start) && (this.End == b.End);
		}
	}

	public struct Extent2d
	{
		public Point2d	Start;
		public Point2d	End;

		public double	Width;
		public double	Height;
		public double	Area;

		public Extent2d(Point2d s, Point2d e)
		{
			this.Start	= s;
			this.End	= e;

			this.Width	= e.X - s.X;
			this.Height = s.Y - e.Y;
			this.Area	= this.Width * this.Height;
		}
		
		public static Extent2d operator- (Extent2d a, Extent2d b)
		{
			return new Extent2d(a.Start - b.Start,
								a.End - b.End);
		}

		public bool Equals(Extent2d b)
		{
			return (this.Start == b.Start) && (this.End == b.End);
		}
	}

	public struct Corners
	{
		public Point2d UpperLeft;
		public Point2d UpperRight;
		public Point2d LowerRight;
		public Point2d LowerLeft;

		public Corners(	Point2d UL,
						Point2d UR,
						Point2d LR,
						Point2d LL)
		{
			this.UpperLeft	= UL;
			this.UpperRight	= UR;
			this.LowerRight	= LR;
			this.LowerLeft	= LL;
		}
	}
}
