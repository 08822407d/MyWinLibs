using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace Utils
{
	public class HugeArray<T> : IEnumerable<T>
		where T : struct
	{
		public readonly int ChunkSize;
		public readonly long Capacity;
		private readonly T[][] content;

		public T this[long index]
		{
			get
			{
				if (index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();
				int chunk = (int)(index / ChunkSize);
				int offset = (int)(index % ChunkSize);
				return content[chunk][offset];
			}
			set
			{
				if (index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();
				int chunk = (int)(index / ChunkSize);
				int offset = (int)(index % ChunkSize);
				content[chunk][offset] = value;
			}
		}

		public HugeArray(long capacity)
		{
			ChunkSize = (Int32.MaxValue >> 4) / Marshal.SizeOf<T>();
			Capacity = capacity;
			int nChunks = (int)(capacity / ChunkSize);
			int nRemainder = (int)(capacity % ChunkSize);

			if (nRemainder == 0)
				content = new T[nChunks][];
			else
				content = new T[nChunks + 1][];

			for (int i = 0; i < nChunks; i++)
				content[i] = new T[ChunkSize];
			if (nRemainder > 0)
				content[content.Length - 1] = new T[nRemainder];
		}

		public IEnumerator<T> GetEnumerator()
		{
			return content.SelectMany(c => c).GetEnumerator();
		}

		IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
	}
}
