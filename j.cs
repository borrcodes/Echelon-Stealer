using System;

internal class j
{
	public static string a()
	{
		string text = "acegikmoqsuwyBDFHJLNPRTVXZ";
		string text2 = "";
		Random random = new Random();
		int num = random.Next(0, text.Length);
		for (int i = 0; i < num; i++)
		{
			text2 += text[random.Next(10, text.Length)];
		}
		return text2;
	}
}
