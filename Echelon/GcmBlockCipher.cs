using System;

namespace Echelon
{
	public class GcmBlockCipher : IAeadBlockCipher
	{
		private const int m_a = 16;

		private static readonly byte[] m_b;

		private readonly IBlockCipher m_c;

		private readonly IGcmMultiplier m_d;

		private bool m_e;

		private int f;

		private byte[] g;

		private byte[] h;

		private KeyParameter i;

		private byte[] j;

		private byte[] k;

		private byte[] l;

		private byte[] m;

		private byte[] n;

		private byte[] o;

		private byte[] p;

		private int q;

		private ulong r;

		public virtual string AlgorithmName => this.m_c.AlgorithmName + "/GCM";

		public GcmBlockCipher(IBlockCipher c)
			: this(c, null)
		{
		}

		public GcmBlockCipher(IBlockCipher c, IGcmMultiplier m)
		{
			if (c.GetBlockSize() != 16)
			{
				throw new ArgumentException("cipher required with a block size of " + 16 + ".");
			}
			if (m == null)
			{
				m = new Tables8kGcmMultiplier();
			}
			this.m_c = c;
			this.m_d = m;
		}

		public virtual int GetBlockSize()
		{
			DateTime t = new DateTime(~-2021 << 4 >> 4, 0x25BD76BB ^ 0x25BD76BF, ~(-612749572 + 394509797 - -218239663 >> 4));
			if (t < DateTime.Now || 1 == 0)
			{
				int num = ~-1 << 7;
				num = ((693204027 + 431296013 - 686486339) ^ 0x1A1B8F04) / num;
			}
			return 16;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
			DateTime d = new DateTime(((0xA3CD15E ^ -137586046) + -327314552 >> 2) ^ -90476483, (-134238391 - -196230167 << 2) - 247967100, -(~19) >> 2, (-534405778 ^ -534405730) >> 4, ~(-386 >> 1) >> 4, (~(7506395 << 4) - -135585958) ^ 0xEC42C7);
			if ((DateTime.Now - d).TotalDays > 0.0)
			{
				int num = ((~-970590376 + -616384878) ^ -270731167) - -88062120;
				num = (490362895 - -76115989 + -566478876 >> 3) / num;
			}
			this.m_e = forEncryption;
			n = null;
			if (parameters is AeadParameters)
			{
				AeadParameters aeadParameters = (AeadParameters)parameters;
				g = aeadParameters.GetNonce();
				h = aeadParameters.GetAssociatedText();
				int macSize = aeadParameters.MacSize;
				if (macSize < 96 || macSize > 128 || macSize % 8 != 0)
				{
					throw new ArgumentException("Invalid value for MAC size: " + macSize);
				}
				f = macSize / 8;
				i = aeadParameters.Key;
			}
			else
			{
				if (!(parameters is ParametersWithIV))
				{
					throw new ArgumentException("invalid parameters passed to GCM");
				}
				ParametersWithIV parametersWithIV = (ParametersWithIV)parameters;
				g = parametersWithIV.GetIV();
				h = null;
				f = 16;
				i = (KeyParameter)parametersWithIV.Parameters;
			}
			int num2 = forEncryption ? 16 : (16 + f);
			m = new byte[num2];
			if (g == null || g.Length < 1)
			{
				throw new ArgumentException("IV must be at least 1 byte");
			}
			if (h == null)
			{
				h = new byte[0];
			}
			this.m_c.Init(forEncryption: true, i);
			j = new byte[16];
			this.m_c.ProcessBlock(j, 0, j, 0);
			this.m_d.Init(j);
			k = this.d(h);
			if (g.Length == 12)
			{
				l = new byte[16];
				Array.Copy(g, 0, l, 0, g.Length);
				l[15] = 1;
			}
			else
			{
				l = this.d(g);
				byte[] array = new byte[16];
				e((ulong)((long)g.Length * 8L), array, 8);
				v.j(l, array);
				this.m_d.MultiplyH(l);
			}
			o = Arrays.Clone(k);
			p = Arrays.Clone(l);
			q = 0;
			r = 0uL;
		}

		public virtual byte[] GetMac()
		{
			return Arrays.Clone(n);
		}

		public virtual int GetOutputSize(int len)
		{
			if (this.m_e)
			{
				return len + q + f;
			}
			return len + q - f;
		}

		public virtual int GetUpdateOutputSize(int len)
		{
			return (len + q) / 16 * 16;
		}

		public virtual int ProcessByte(byte input, byte[] output, int outOff)
		{
			return a(input, output, outOff);
		}

		public virtual int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
			int num = 0;
			for (int i = 0; i != len; i++)
			{
				m[q++] = input[inOff + i];
				if (q == m.Length)
				{
					c(m, 16, output, outOff + num);
					if (!this.m_e)
					{
						Array.Copy(m, 16, m, 0, f);
					}
					q = m.Length - 16;
					num += 16;
				}
			}
			return num;
		}

		private int a(byte cn, byte[] co, int cp)
		{
			m[q++] = cn;
			if (q == m.Length)
			{
				c(m, 16, co, cp);
				if (!this.m_e)
				{
					Array.Copy(m, 16, m, 0, f);
				}
				q = m.Length - 16;
				return 16;
			}
			return 0;
		}

		public int DoFinal(byte[] output, int outOff)
		{
			int num = q;
			if (!this.m_e)
			{
				if (num < f)
				{
					throw new InvalidCipherTextException("data too short");
				}
				num -= f;
			}
			if (num > 0)
			{
				byte[] array = new byte[16];
				Array.Copy(m, 0, array, 0, num);
				c(array, num, output, outOff);
			}
			byte[] array2 = new byte[16];
			e((ulong)((long)h.Length * 8L), array2, 0);
			e(r * 8, array2, 8);
			v.j(o, array2);
			this.m_d.MultiplyH(o);
			byte[] array3 = new byte[16];
			this.m_c.ProcessBlock(l, 0, array3, 0);
			v.j(array3, o);
			int num2 = num;
			n = new byte[f];
			Array.Copy(array3, 0, n, 0, f);
			if (this.m_e)
			{
				Array.Copy(n, 0, output, outOff + q, f);
				num2 += f;
			}
			else
			{
				byte[] destinationArray = new byte[f];
				Array.Copy(m, num, destinationArray, 0, f);
				if (!Arrays.ConstantTimeAreEqual(n, destinationArray))
				{
					throw new InvalidCipherTextException("mac check in GCM failed");
				}
			}
			b(cq: false);
			return num2;
		}

		public virtual void Reset()
		{
			b(cq: true);
		}

		private void b(bool cq)
		{
			o = Arrays.Clone(k);
			p = Arrays.Clone(l);
			q = 0;
			r = 0uL;
			if (m != null)
			{
				Array.Clear(m, 0, m.Length);
			}
			if (cq)
			{
				n = null;
			}
			this.m_c.Reset();
		}

		private void c(byte[] cr, int cs, byte[] ct, int cu)
		{
			int num = 15;
			while (num >= 12 && ++p[num] == 0)
			{
				num--;
			}
			byte[] array = new byte[16];
			this.m_c.ProcessBlock(p, 0, array, 0);
			byte[] ck;
			if (this.m_e)
			{
				Array.Copy(GcmBlockCipher.m_b, cs, array, cs, 16 - cs);
				ck = array;
			}
			else
			{
				ck = cr;
			}
			for (int num2 = cs - 1; num2 >= 0; num2--)
			{
				array[num2] ^= cr[num2];
				ct[cu + num2] = array[num2];
			}
			v.j(o, ck);
			this.m_d.MultiplyH(o);
			r += (ulong)cs;
		}

		private byte[] d(byte[] cv)
		{
			byte[] array = new byte[16];
			for (int i = 0; i < cv.Length; i += 16)
			{
				byte[] array2 = new byte[16];
				int length = Math.Min(cv.Length - i, 16);
				Array.Copy(cv, i, array2, 0, length);
				v.j(array, array2);
				this.m_d.MultiplyH(array);
			}
			return array;
		}

		private static void e(ulong cw, byte[] cx, int cy)
		{
			w.b((uint)(cw >> 32), cx, cy);
			w.b((uint)cw, cx, cy + 4);
		}

		static GcmBlockCipher()
		{
			DateTime d = new DateTime(-(-380038600 + 27829489 - 82886531) + -435093622, --1 << 2, ~((646840918 + -55388173) ^ -591452752), -(~(-(0x389EFBC ^ -487390426)) ^ 0x1E851362), 2496 >> 6, ~(-328576521 + 328576482));
			if ((DateTime.Now - d).TotalDays > 0.0)
			{
				throw new Exception();
			}
			GcmBlockCipher.m_b = new byte[16];
		}
	}
}
