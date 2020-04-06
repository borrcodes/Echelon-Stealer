namespace Echelon
{
	public class Tables8kGcmMultiplier : IGcmMultiplier
	{
		private readonly uint[][][] a = new uint[32][][];

		public void Init(byte[] H)
		{
			a[0] = new uint[16][];
			a[1] = new uint[16][];
			a[0][0] = new uint[4];
			a[1][0] = new uint[4];
			a[1][8] = v.c(H);
			for (int num = 4; num >= 1; num >>= 1)
			{
				uint[] array = (uint[])a[1][num + num].Clone();
				v.e(array);
				a[1][num] = array;
			}
			uint[] array2 = (uint[])a[1][1].Clone();
			v.e(array2);
			a[0][8] = array2;
			for (int num2 = 4; num2 >= 1; num2 >>= 1)
			{
				uint[] array3 = (uint[])a[0][num2 + num2].Clone();
				v.e(array3);
				a[0][num2] = array3;
			}
			int num3 = 0;
			while (true)
			{
				for (int i = 2; i < 16; i += i)
				{
					for (int j = 1; j < i; j++)
					{
						uint[] array4 = (uint[])a[num3][i].Clone();
						v.k(array4, a[num3][j]);
						a[num3][i + j] = array4;
					}
				}
				if (++num3 == 32)
				{
					break;
				}
				if (num3 > 1)
				{
					a[num3] = new uint[16][];
					a[num3][0] = new uint[4];
					for (int num4 = 8; num4 > 0; num4 >>= 1)
					{
						uint[] array5 = (uint[])a[num3 - 2][num4].Clone();
						v.f(array5);
						a[num3][num4] = array5;
					}
				}
			}
		}

		public void MultiplyH(byte[] x)
		{
			uint[] array = new uint[4];
			for (int num = 15; num >= 0; num--)
			{
				uint[] array2 = a[num + num][x[num] & 0xF];
				array[0] ^= array2[0];
				array[1] ^= array2[1];
				array[2] ^= array2[2];
				array[3] ^= array2[3];
				array2 = a[num + num + 1][(x[num] & 0xF0) >> 4];
				array[0] ^= array2[0];
				array[1] ^= array2[1];
				array[2] ^= array2[2];
				array[3] ^= array2[3];
			}
			w.b(array[0], x, 0);
			w.b(array[1], x, 4);
			w.b(array[2], x, 8);
			w.b(array[3], x, 12);
		}
	}
}
