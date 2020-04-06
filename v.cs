using Echelon;
using System;

internal abstract class v
{
	internal static byte[] a()
	{
		return new byte[16]
		{
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
	}

	internal static uint[] b()
	{
		return new uint[4]
		{
			2147483648u,
			0u,
			0u,
			0u
		};
	}

	internal static uint[] c(byte[] ca)
	{
		return new uint[4]
		{
			w.d(ca, 0),
			w.d(ca, 4),
			w.d(ca, 8),
			w.d(ca, 12)
		};
	}

	internal static void d(byte[] cb, byte[] cc)
	{
		byte[] array = Arrays.Clone(cb);
		byte[] array2 = new byte[16];
		for (int i = 0; i < 16; i++)
		{
			byte b = cc[i];
			for (int num = 7; num >= 0; num--)
			{
				if ((b & (1 << num)) != 0)
				{
					j(array2, array);
				}
				bool num2 = (array[15] & 1) != 0;
				g(array);
				if (num2)
				{
					array[0] ^= 225;
				}
			}
		}
		Array.Copy(array2, 0, cb, 0, 16);
	}

	internal static void e(uint[] cd)
	{
		bool num = (cd[3] & 1) != 0;
		h(cd);
		if (num)
		{
			cd[0] ^= 3774873600u;
		}
	}

	internal static void f(uint[] ce)
	{
		uint num = ce[3];
		i(ce, 8);
		for (int num2 = 7; num2 >= 0; num2--)
		{
			if ((num & (1 << num2)) != 0L)
			{
				ce[0] ^= 3774873600u >> 7 - num2;
			}
		}
	}

	internal static void g(byte[] cf)
	{
		int num = 0;
		byte b = 0;
		while (true)
		{
			byte b2 = cf[num];
			cf[num] = (byte)((b2 >> 1) | b);
			if (++num == 16)
			{
				break;
			}
			b = (byte)(b2 << 7);
		}
	}

	internal static void h(uint[] cg)
	{
		int num = 0;
		uint num2 = 0u;
		while (true)
		{
			uint num3 = cg[num];
			cg[num] = ((num3 >> 1) | num2);
			if (++num == 4)
			{
				break;
			}
			num2 = num3 << 31;
		}
	}

	internal static void i(uint[] ch, int ci)
	{
		int num = 0;
		uint num2 = 0u;
		while (true)
		{
			uint num3 = ch[num];
			ch[num] = ((num3 >> ci) | num2);
			if (++num == 4)
			{
				break;
			}
			num2 = num3 << 32 - ci;
		}
	}

	internal static void j(byte[] cj, byte[] ck)
	{
		for (int num = 15; num >= 0; num--)
		{
			cj[num] ^= ck[num];
		}
	}

	internal static void k(uint[] cl, uint[] cm)
	{
		for (int num = 3; num >= 0; num--)
		{
			cl[num] ^= cm[num];
		}
	}
}
