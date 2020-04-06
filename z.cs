using System;
using System.Runtime.InteropServices;

internal class z
{
	public enum a
	{
		a = -1,
		b,
		c,
		d,
		e,
		f,
		g,
		h,
		i,
		j,
		k,
		l,
		m,
		n,
		o
	}

	public enum b
	{
		a = 0,
		b = 1,
		c = 2,
		d = 3,
		e = 4,
		f = 5,
		g = 100,
		h = 10000
	}

	public struct c
	{
		public Guid SchemaId;

		public IntPtr a;

		public IntPtr pResourceElement;

		public IntPtr pIdentityElement;

		public IntPtr pAuthenticatorElement;

		public IntPtr pPackageSid;

		public ulong LastModified;

		public uint b;

		public uint c;

		public IntPtr d;
	}

	public struct d
	{
		public Guid SchemaId;

		public IntPtr a;

		public IntPtr pResourceElement;

		public IntPtr pIdentityElement;

		public IntPtr pAuthenticatorElement;

		public ulong LastModified;

		public uint b;

		public uint c;

		public IntPtr d;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct e
	{
		[FieldOffset(0)]
		public b a;

		[FieldOffset(8)]
		public a Type;
	}

	[DllImport("vaultcli.dll", EntryPoint = "VaultOpenVault")]
	public static extern int a(ref Guid fc, uint fd, ref IntPtr fe);

	[DllImport("vaultcli.dll", EntryPoint = "VaultCloseVault")]
	public static extern int b(ref IntPtr ff);

	[DllImport("vaultcli.dll", EntryPoint = "VaultFree")]
	public static extern int c(ref IntPtr fg);

	[DllImport("vaultcli.dll", EntryPoint = "VaultEnumerateVaults")]
	public static extern int d(int fh, ref int fi, ref IntPtr fj);

	[DllImport("vaultcli.dll", EntryPoint = "VaultEnumerateItems")]
	public static extern int e(IntPtr fk, int fl, ref int fm, ref IntPtr fn);

	[DllImport("vaultcli.dll", EntryPoint = "VaultGetItem")]
	public static extern int f(IntPtr fo, ref Guid fp, IntPtr fq, IntPtr fr, IntPtr fs, IntPtr ft, int fu, ref IntPtr fv);

	[DllImport("vaultcli.dll", EntryPoint = "VaultGetItem")]
	public static extern int g(IntPtr fw, ref Guid fx, IntPtr fy, IntPtr fz, IntPtr ga, int gb, ref IntPtr gc);
}
