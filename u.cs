using System;
using System.Runtime.InteropServices;

internal class u
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct a
	{
		public int a;

		public IntPtr b;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct b
	{
		public int a;

		public int b;

		public IntPtr c;

		public string d;
	}

	public static byte[] a(byte[] be, byte[] bf = null)
	{
		a bm = default(a);
		a bg = default(a);
		a bi = default(a);
		b b = default(b);
		b.a = Marshal.SizeOf(typeof(b));
		b.b = 0;
		b.c = IntPtr.Zero;
		b.d = null;
		b bk = b;
		string bh = string.Empty;
		try
		{
			try
			{
				if (be == null)
				{
					be = new byte[0];
				}
				bg.b = Marshal.AllocHGlobal(be.Length);
				bg.a = be.Length;
				Marshal.Copy(be, 0, bg.b, be.Length);
			}
			catch
			{
			}
			try
			{
				if (bf == null)
				{
					bf = new byte[0];
				}
				bi.b = Marshal.AllocHGlobal(bf.Length);
				bi.a = bf.Length;
				Marshal.Copy(bf, 0, bi.b, bf.Length);
			}
			catch
			{
			}
			u.b(ref bg, ref bh, ref bi, IntPtr.Zero, ref bk, 1, ref bm);
			byte[] array = new byte[bm.a];
			Marshal.Copy(bm.b, array, 0, bm.a);
			return array;
		}
		catch
		{
		}
		finally
		{
			if (bm.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(bm.b);
			}
			if (bg.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(bg.b);
			}
			if (bi.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(bi.b);
			}
		}
		return new byte[0];
	}

	[DllImport("crypt32.dll", CharSet = CharSet.Auto, EntryPoint = "CryptUnprotectData", SetLastError = true)]
	private static extern bool b(ref a bg, ref string bh, ref a bi, IntPtr bj, ref b bk, int bl, ref a bm);
}
