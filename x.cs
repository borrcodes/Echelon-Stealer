using System;
using System.IO;
using System.Text;

internal class x
{
	private struct a
	{
		public long a;

		public long Type;
	}

	private struct b
	{
		public string[] a;
	}

	private struct c
	{
		public string a;

		public long b;

		public string c;
	}

	private readonly byte[] m_a = new byte[10]
	{
		0,
		1,
		2,
		3,
		4,
		6,
		8,
		8,
		0,
		0
	};

	private readonly ulong m_b;

	private readonly byte[] m_c;

	private readonly ulong m_d;

	private string[] m_e;

	private c[] m_f;

	private b[] m_g;

	public x(string eo)
	{
		this.m_c = File.ReadAllBytes(eo);
		this.m_d = f(16, 2);
		this.m_b = f(56, 4);
		d(100L);
	}

	public string a(int ep, int eq)
	{
		try
		{
			if (ep >= this.m_g.Length)
			{
				return null;
			}
			return (eq >= this.m_g[ep].a.Length) ? null : this.m_g[ep].a[eq];
		}
		catch
		{
			return null;
		}
	}

	public int b()
	{
		DateTime t = default(DateTime).AddYears((1315308567 - -4853897 >> 1) + -90373203 - 569706010).AddMonths(257494988 + -257494985).AddDays(5.42361111111111);
		if (DateTime.Now > t || 1 == 0)
		{
			int num = (~(828671371 - 375069418) ^ 0x167B10C4) - -225606246;
			num = ((-1036261019 + -74867389 >> 3) ^ -138891052) / num;
		}
		return this.m_g.Length;
	}

	private bool c(ulong er)
	{
		DateTime t = new DateTime(~(~(8277984 >> 5) >> 7), -(-159164406 + 159164402), ~(-(~-8)), -(((1375972969 + -643529286) ^ 0xC29B64E) - 662798963), ~(-(616618075 - 616618044)), ~(-(93240041 + 162276647) ^ 0xF3AE014));
		if (DateTime.Now > t || 1 == 0)
		{
			int num = (0x23A8E707 ^ 0x929A3AC) - 713114795;
			num = ~((-906042868 ^ -714883979) - 480075387) / num;
		}
		try
		{
			if (this.m_c[er] == 13)
			{
				uint num2 = (uint)(f((int)er + 3, 2) - 1);
				int num3 = 0;
				if (this.m_g != null)
				{
					num3 = this.m_g.Length;
					Array.Resize(ref this.m_g, this.m_g.Length + (int)num2 + 1);
				}
				else
				{
					this.m_g = new b[num2 + 1];
				}
				for (uint num4 = 0u; (int)num4 <= (int)num2; num4++)
				{
					ulong num5 = f((int)er + 8 + (int)(num4 * 2), 2);
					if (er != 100)
					{
						num5 += er;
					}
					int num6 = g((int)num5);
					h((int)num5, num6);
					int num7 = g((int)((long)num5 + ((long)num6 - (long)num5) + 1));
					h((int)((long)num5 + ((long)num6 - (long)num5) + 1), num7);
					ulong num8 = (ulong)((long)num5 + ((long)num7 - (long)num5 + 1));
					int num9 = g((int)num8);
					int num10 = num9;
					long num11 = h((int)num8, num9);
					a[] array = null;
					long num12 = (long)num8 - (long)num9 + 1;
					int num13 = 0;
					while (num12 < num11)
					{
						Array.Resize(ref array, num13 + 1);
						int num14 = num10 + 1;
						num10 = g(num14);
						array[num13].Type = h(num14, num10);
						array[num13].a = ((array[num13].Type <= 9) ? this.m_a[array[num13].Type] : ((!x.i(array[num13].Type)) ? ((array[num13].Type - 12) / 2) : ((array[num13].Type - 13) / 2)));
						num12 = num12 + (num10 - num14) + 1;
						num13++;
					}
					if (array != null)
					{
						this.m_g[num3 + (int)num4].a = new string[array.Length];
						int num15 = 0;
						for (int i = 0; i <= array.Length - 1; i++)
						{
							if (array[i].Type > 9)
							{
								if (!x.i(array[i].Type))
								{
									if (this.m_b == 1)
									{
										this.m_g[num3 + (int)num4].a[i] = Encoding.Default.GetString(this.m_c, (int)((long)num8 + num11 + num15), (int)array[i].a);
									}
									else if (this.m_b == 2)
									{
										this.m_g[num3 + (int)num4].a[i] = Encoding.Unicode.GetString(this.m_c, (int)((long)num8 + num11 + num15), (int)array[i].a);
									}
									else if (this.m_b == 3)
									{
										this.m_g[num3 + (int)num4].a[i] = Encoding.BigEndianUnicode.GetString(this.m_c, (int)((long)num8 + num11 + num15), (int)array[i].a);
									}
								}
								else
								{
									this.m_g[num3 + (int)num4].a[i] = Encoding.Default.GetString(this.m_c, (int)((long)num8 + num11 + num15), (int)array[i].a);
								}
							}
							else
							{
								this.m_g[num3 + (int)num4].a[i] = Convert.ToString(f((int)((long)num8 + num11 + num15), (int)array[i].a));
							}
							num15 += (int)array[i].a;
						}
					}
				}
			}
			else if (this.m_c[er] == 5)
			{
				uint num16 = (uint)(f((int)(er + 3), 2) - 1);
				for (uint num17 = 0u; (int)num17 <= (int)num16; num17++)
				{
					uint num18 = (uint)f((int)er + 12 + (int)(num17 * 2), 2);
					c((f((int)(er + num18), 4) - 1) * this.m_d);
				}
				c((f((int)(er + 8), 4) - 1) * this.m_d);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void d(long es)
	{
		try
		{
			switch (this.m_c[es])
			{
			case 5:
			{
				uint num12 = (uint)(f((int)es + 3, 2) - 1);
				for (int j = 0; j <= (int)num12; j++)
				{
					uint num13 = (uint)f((int)es + 12 + j * 2, 2);
					if (es == 100)
					{
						d((long)((f((int)num13, 4) - 1) * this.m_d));
					}
					else
					{
						d((long)((f((int)(es + num13), 4) - 1) * this.m_d));
					}
				}
				d((long)((f((int)es + 8, 4) - 1) * this.m_d));
				break;
			}
			case 13:
			{
				ulong num = f((int)es + 3, 2) - 1;
				int num2 = 0;
				if (this.m_f != null)
				{
					num2 = this.m_f.Length;
					Array.Resize(ref this.m_f, this.m_f.Length + (int)num + 1);
				}
				else
				{
					checked
					{
						this.m_f = new c[(ulong)unchecked((long)(num + 1))];
					}
				}
				for (ulong num3 = 0uL; num3 <= num; num3++)
				{
					ulong num4 = f((int)es + 8 + (int)num3 * 2, 2);
					if (es != 100)
					{
						num4 = (ulong)((long)num4 + es);
					}
					int num5 = g((int)num4);
					h((int)num4, num5);
					int num6 = g((int)((long)num4 + ((long)num5 - (long)num4) + 1));
					h((int)((long)num4 + ((long)num5 - (long)num4) + 1), num6);
					ulong num7 = (ulong)((long)num4 + ((long)num6 - (long)num4 + 1));
					int num8 = g((int)num7);
					int num9 = num8;
					long num10 = h((int)num7, num8);
					long[] array = new long[5];
					for (int i = 0; i <= 4; i++)
					{
						int num11 = num9 + 1;
						num9 = g(num11);
						array[i] = h(num11, num9);
						array[i] = ((array[i] <= 9) ? this.m_a[array[i]] : ((!x.i(array[i])) ? ((array[i] - 12) / 2) : ((array[i] - 13) / 2)));
					}
					if (this.m_b == 1 || this.m_b == 2)
					{
						if (this.m_b == 1)
						{
							this.m_f[num2 + (int)num3].a = Encoding.Default.GetString(this.m_c, (int)((long)num7 + num10 + array[0]), (int)array[1]);
						}
						else if (this.m_b == 2)
						{
							this.m_f[num2 + (int)num3].a = Encoding.Unicode.GetString(this.m_c, (int)((long)num7 + num10 + array[0]), (int)array[1]);
						}
						else if (this.m_b == 3)
						{
							this.m_f[num2 + (int)num3].a = Encoding.BigEndianUnicode.GetString(this.m_c, (int)((long)num7 + num10 + array[0]), (int)array[1]);
						}
					}
					this.m_f[num2 + (int)num3].b = (long)f((int)((long)num7 + num10 + array[0] + array[1] + array[2]), (int)array[3]);
					if (this.m_b == 1)
					{
						this.m_f[num2 + (int)num3].c = Encoding.Default.GetString(this.m_c, (int)((long)num7 + num10 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
					}
					else if (this.m_b == 2)
					{
						this.m_f[num2 + (int)num3].c = Encoding.Unicode.GetString(this.m_c, (int)((long)num7 + num10 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
					}
					else if (this.m_b == 3)
					{
						this.m_f[num2 + (int)num3].c = Encoding.BigEndianUnicode.GetString(this.m_c, (int)((long)num7 + num10 + array[0] + array[1] + array[2] + array[3]), (int)array[4]);
					}
				}
				break;
			}
			}
		}
		catch
		{
		}
	}

	public bool e(string et)
	{
		try
		{
			int num = -1;
			for (int i = 0; i <= this.m_f.Length; i++)
			{
				if (string.Compare(this.m_f[i].a.ToLower(), et.ToLower(), StringComparison.Ordinal) == 0)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			string[] array = this.m_f[num].c.Substring(this.m_f[num].c.IndexOf("(", StringComparison.Ordinal) + 1).Split(',');
			for (int j = 0; j <= array.Length - 1; j++)
			{
				array[j] = array[j].TrimStart();
				int num2 = array[j].IndexOf(' ');
				if (num2 > 0)
				{
					array[j] = array[j].Substring(0, num2);
				}
				if (array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
				{
					Array.Resize(ref this.m_e, j + 1);
					this.m_e[j] = array[j];
				}
			}
			return c((ulong)((this.m_f[num].b - 1) * (long)this.m_d));
		}
		catch
		{
			return false;
		}
	}

	private ulong f(int eu, int ev)
	{
		try
		{
			if (ev > 8 || ev == 0)
			{
				return 0uL;
			}
			ulong num = 0uL;
			for (int i = 0; i <= ev - 1; i++)
			{
				num = ((num << 8) | this.m_c[eu + i]);
			}
			return num;
		}
		catch
		{
			return 0uL;
		}
	}

	private int g(int ew)
	{
		try
		{
			if (ew > this.m_c.Length)
			{
				return 0;
			}
			for (int i = ew; i <= ew + 8; i++)
			{
				if (i > this.m_c.Length - 1)
				{
					return 0;
				}
				if ((this.m_c[i] & 0x80) != 128)
				{
					return i;
				}
			}
			return ew + 8;
		}
		catch
		{
			return 0;
		}
	}

	private long h(int ex, int ey)
	{
		try
		{
			ey++;
			byte[] array = new byte[8];
			int num = ey - ex;
			bool flag = false;
			if (num == 0 || num > 9)
			{
				return 0L;
			}
			switch (num)
			{
			case 1:
				array[0] = (byte)(this.m_c[ex] & 0x7F);
				return BitConverter.ToInt64(array, 0);
			case 9:
				flag = true;
				break;
			}
			int num2 = 1;
			int num3 = 7;
			int num4 = 0;
			if (flag)
			{
				array[0] = this.m_c[ey - 1];
				ey--;
				num4 = 1;
			}
			for (int i = ey - 1; i >= ex; i += -1)
			{
				if (i - 1 >= ex)
				{
					array[num4] = (byte)(((this.m_c[i] >> num2 - 1) & (255 >> num2)) | (this.m_c[i - 1] << num3));
					num2++;
					num4++;
					num3--;
				}
				else if (!flag)
				{
					array[num4] = (byte)((this.m_c[i] >> num2 - 1) & (255 >> num2));
				}
			}
			return BitConverter.ToInt64(array, 0);
		}
		catch
		{
			return 0L;
		}
	}

	private static bool i(long ez)
	{
		return (ez & 1) == 1;
	}
}
