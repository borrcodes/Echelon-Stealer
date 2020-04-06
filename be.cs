using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

[CompilerGenerated]
internal static class be
{
	private static object m_a = new object();

	private static Dictionary<string, bool> m_b = new Dictionary<string, bool>();

	private static Dictionary<string, string> m_c = new Dictionary<string, string>();

	private static Dictionary<string, string> m_d = new Dictionary<string, string>();

	private static int m_e;

	private static string a(CultureInfo jx)
	{
		if (jx == null)
		{
			return "";
		}
		return jx.Name;
	}

	private static Assembly b(AssemblyName jy)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			AssemblyName name = assembly.GetName();
			if (string.Equals(name.Name, jy.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(a(name.CultureInfo), a(jy.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
			{
				return assembly;
			}
		}
		return null;
	}

	private static void c(Stream jz, Stream ka)
	{
		byte[] array = new byte[81920];
		int count;
		while ((count = jz.Read(array, 0, array.Length)) != 0)
		{
			ka.Write(array, 0, count);
		}
	}

	private static Stream d(string kb)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (kb.EndsWith(".compressed"))
		{
			using (Stream stream = executingAssembly.GetManifestResourceStream(kb))
			{
				using (DeflateStream jz = new DeflateStream(stream, CompressionMode.Decompress))
				{
					MemoryStream memoryStream = new MemoryStream();
					c(jz, memoryStream);
					memoryStream.Position = 0L;
					return memoryStream;
				}
			}
		}
		return executingAssembly.GetManifestResourceStream(kb);
	}

	private static Stream e(Dictionary<string, string> kc, string kd)
	{
		if (kc.TryGetValue(kd, out string value))
		{
			return d(value);
		}
		return null;
	}

	private static byte[] f(Stream ke)
	{
		byte[] array = new byte[ke.Length];
		ke.Read(array, 0, array.Length);
		return array;
	}

	private static Assembly g(Dictionary<string, string> kf, Dictionary<string, string> kg, AssemblyName kh)
	{
		string text = kh.Name.ToLowerInvariant();
		if (kh.CultureInfo != null && !string.IsNullOrEmpty(kh.CultureInfo.Name))
		{
			text = kh.CultureInfo.Name + "." + text;
		}
		byte[] rawAssembly;
		using (Stream stream = e(kf, text))
		{
			if (stream == null)
			{
				return null;
			}
			rawAssembly = f(stream);
		}
		using (Stream stream2 = e(kg, text))
		{
			if (stream2 != null)
			{
				byte[] rawSymbolStore = f(stream2);
				return Assembly.Load(rawAssembly, rawSymbolStore);
			}
		}
		return Assembly.Load(rawAssembly);
	}

	public static Assembly h(object ki, ResolveEventArgs kj)
	{
		lock (be.m_a)
		{
			if (be.m_b.ContainsKey(kj.Name))
			{
				return null;
			}
		}
		AssemblyName assemblyName = new AssemblyName(kj.Name);
		Assembly assembly = b(assemblyName);
		if (assembly != null)
		{
			return assembly;
		}
		assembly = g(be.m_c, be.m_d, assemblyName);
		if (assembly == null)
		{
			lock (be.m_a)
			{
				be.m_b[kj.Name] = true;
			}
			if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
			{
				assembly = Assembly.Load(assemblyName);
			}
		}
		return assembly;
	}

	static be()
	{
		be.m_c.Add("costura", "costura.costura.dll.compressed");
		be.m_c.Add("decoder", "costura.decoder.dll.compressed");
	}

	public static void i()
	{
		if (Interlocked.Exchange(ref be.m_e, 1) != 1)
		{
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object ki, ResolveEventArgs kj)
			{
				lock (be.m_a)
				{
					if (be.m_b.ContainsKey(kj.Name))
					{
						return null;
					}
				}
				AssemblyName assemblyName = new AssemblyName(kj.Name);
				Assembly assembly = b(assemblyName);
				if (assembly != null)
				{
					return assembly;
				}
				assembly = g(be.m_c, be.m_d, assemblyName);
				if (assembly == null)
				{
					lock (be.m_a)
					{
						be.m_b[kj.Name] = true;
					}
					if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
					{
						assembly = Assembly.Load(assemblyName);
					}
				}
				return assembly;
			};
		}
	}
}
