using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Echelon
{
	public class CNT
	{
		[CompilerGenerated]
		private readonly byte[] m_a;

		[CompilerGenerated]
		private readonly ulong m_b;

		[CompilerGenerated]
		private string[] m_c;

		[CompilerGenerated]
		private readonly ushort m_d;

		[CompilerGenerated]
		private FF[] m_e;

		[CompilerGenerated]
		private ROW[] f;

		[CompilerGenerated]
		private readonly byte[] g;

		private byte[] h
		{
			get;
		}

		private ulong i
		{
			get;
		}

		public string[] Fields
		{
			[CompilerGenerated]
			get
			{
				return this.m_c;
			}
			[CompilerGenerated]
			set
			{
				DateTime d = new DateTime(-(~-473780604) ^ -473781919, ~((~-890468444 ^ -529115960) - -714789739) << 2, ~-25 >> 2);
				if ((DateTime.Now - d).TotalDays > 0.0)
				{
					throw new ArgumentException();
				}
				this.m_c = value;
			}
		}

		public int RowLength
		{
			get
			{
				DateTime d = new DateTime(~(0x1DDB65DB ^ -376279557) - 196538363, ~(-606151128 - -606151123), -454371005 - -454371011, -(929055842 + -401382766 - 527673078), -(~(-186275497 + 573535623) ^ 0x17151ECD), ~((-778854871 - -654934945) ^ 0x762DE3F));
				if ((d - DateTime.Now).TotalDays < 0.0)
				{
					int num = ~(-1 << 1 >> 1);
					num = (((0x7684C34F ^ 0x18B19897) >> 2) ^ 0x1B8D56F7) / num;
				}
				return l.Length;
			}
		}

		private ushort j
		{
			get;
		}

		private FF[] k
		{
			get;
			set;
		}

		private ROW[] l
		{
			get;
			set;
		}

		private byte[] m
		{
			get;
		}

		public CNT(string baseName)
		{
			g = new byte[10]
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
			if (File.Exists(baseName))
			{
				FileSystem.FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared);
				string Value = Strings.Space((int)FileSystem.LOF(1));
				FileSystem.FileGet(1, ref Value, -1L);
				FileSystem.FileClose(1);
				this.m_a = Encoding.Default.GetBytes(Value);
				this.m_d = (ushort)a(16, 2);
				this.m_b = a(56, 4);
				if (decimal.Compare(new decimal(i), 0m) == 0)
				{
					this.m_b = 1uL;
				}
				d(100uL);
			}
		}

		public string[] ParseTables()
		{
			string[] array = null;
			int num = 0;
			int num2 = k.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (k[i].Type == "table")
				{
					array = (string[])Utils.CopyArray(array, new string[num + 1]);
					array[num] = k[i].Name;
					num++;
				}
			}
			return array;
		}

		public string ParseValue(int rowIndex, int fieldIndex)
		{
			if (rowIndex >= l.Length)
			{
				return null;
			}
			if (fieldIndex >= l[rowIndex].RowData.Length)
			{
				return null;
			}
			return l[rowIndex].RowData[fieldIndex];
		}

		public string ParseValue(int rowIndex, string fieldName)
		{
			int num = -1;
			int num2 = Fields.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Fields[i].ToLower().Trim().CompareTo(fieldName.ToLower().Trim()) == 0)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			return ParseValue(rowIndex, num);
		}

		public bool ReadTable(string tableName)
		{
			int num = -1;
			int num2 = k.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (k[i].Name.ToLower().CompareTo(tableName.ToLower()) == 0)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			string[] array = k[num].SqlStatement.Substring(k[num].SqlStatement.IndexOf("(") + 1).Split(',');
			int num3 = array.Length - 1;
			for (int j = 0; j <= num3; j++)
			{
				array[j] = array[j].TrimStart();
				int num4 = array[j].IndexOf(" ");
				if (num4 > 0)
				{
					array[j] = array[j].Substring(0, num4);
				}
				if (array[j].IndexOf("UNIQUE") == 0)
				{
					break;
				}
				Fields = (string[])Utils.CopyArray(Fields, new string[j + 1]);
				Fields[j] = array[j];
			}
			return e((ulong)((k[num].RootNum - 1) * this.j));
		}

		private ulong a(int gh, int gi)
		{
			if (gi > 8 || gi == 0)
			{
				return 0uL;
			}
			ulong num = 0uL;
			for (int i = 0; i <= gi - 1; i++)
			{
				num = ((num << 8) | h[gh + i]);
			}
			return num;
		}

		private long b(int gj, int gk)
		{
			gk++;
			byte[] array = new byte[8];
			int num = gk - gj;
			bool flag = false;
			if (num == 0 || num > 9)
			{
				return 0L;
			}
			switch (num)
			{
			case 1:
				array[0] = (byte)(h[gj] & 0x7F);
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
				array[0] = h[gk - 1];
				gk--;
				num4 = 1;
			}
			for (int i = gk - 1; i >= gj; i += -1)
			{
				if (i - 1 >= gj)
				{
					array[num4] = (byte)(((byte)(h[i] >> ((num2 - 1) & 7)) & (255 >> num2)) | (byte)(h[i - 1] << (num3 & 7)));
					num2++;
					num4++;
					num3--;
				}
				else if (!flag)
				{
					array[num4] = (byte)((byte)(h[i] >> ((num2 - 1) & 7)) & (255 >> num2));
				}
			}
			return BitConverter.ToInt64(array, 0);
		}

		private int c(int gl)
		{
			if (gl > h.Length)
			{
				return 0;
			}
			int num = gl + 8;
			for (int i = gl; i <= num; i++)
			{
				if (i > h.Length - 1)
				{
					return 0;
				}
				if ((h[i] & 0x80) != 128)
				{
					return i;
				}
			}
			return gl + 8;
		}

		public static bool ItIsOdd(long value)
		{
			return (value & 1) == 1;
		}

		private void d(ulong gm)
		{
			if (h[(uint)gm] == 13)
			{
				ushort num = (a((gm.ForceTo<decimal>() + 3m).ForceTo<int>(), 2).ForceTo<decimal>() - 1m).ForceTo<ushort>();
				int num2 = 0;
				if (k != null)
				{
					num2 = k.Length;
					k = (FF[])Utils.CopyArray(k, new FF[k.Length + num + 1]);
				}
				else
				{
					k = new FF[num + 1];
				}
				int num3 = num;
				for (int i = 0; i <= num3; i++)
				{
					ulong num4 = a((gm.ForceTo<decimal>() + 8m + (i * 2).ForceTo<decimal>()).ForceTo<int>(), 2);
					if (decimal.Compare(gm.ForceTo<decimal>(), 100m) != 0)
					{
						num4 += gm;
					}
					int num5 = c(num4.ForceTo<int>());
					b(num4.ForceTo<int>(), num5);
					int num6 = c((num4.ForceTo<decimal>() + num5.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<int>());
					k[num2 + i].ID = b((num4.ForceTo<decimal>() + num5.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<int>(), num6);
					num4 = (num4.ForceTo<decimal>() + num6.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<ulong>();
					num5 = c(num4.ForceTo<int>());
					num6 = num5;
					long value = b(num4.ForceTo<int>(), num5);
					long[] array = new long[5];
					int num7 = 0;
					do
					{
						num5 = num6 + 1;
						num6 = c(num5);
						array[num7] = b(num5, num6);
						if (array[num7] > 9)
						{
							if (ItIsOdd(array[num7]))
							{
								array[num7] = (long)Math.Round((double)(array[num7] - 13) / 2.0);
							}
							else
							{
								array[num7] = (long)Math.Round((double)(array[num7] - 12) / 2.0);
							}
						}
						else
						{
							array[num7] = m[(int)array[num7]];
						}
						num7++;
					}
					while (num7 <= 4);
					Encoding encoding = Encoding.Default;
					decimal value2 = this.i.ForceTo<decimal>();
					if (!1m.Equals(value2))
					{
						if (!2m.Equals(value2))
						{
							if (3m.Equals(value2))
							{
								encoding = Encoding.BigEndianUnicode;
							}
						}
						else
						{
							encoding = Encoding.Unicode;
						}
					}
					else
					{
						encoding = Encoding.Default;
					}
					k[num2 + i].Type = encoding.GetString(h, Convert.ToInt32(decimal.Add(new decimal(num4), new decimal(value))), (int)array[0]);
					k[num2 + i].Name = encoding.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0]))), (int)array[1]);
					k[num2 + i].RootNum = (long)a(Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2]))), (int)array[3]);
					k[num2 + i].SqlStatement = encoding.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2])), new decimal(array[3]))), (int)array[4]);
				}
			}
			else
			{
				if (h[(uint)gm] != 5)
				{
					return;
				}
				int num8 = Convert.ToUInt16(decimal.Subtract(new decimal(a(Convert.ToInt32(decimal.Add(new decimal(gm), 3m)), 2)), 1m));
				for (int j = 0; j <= num8; j++)
				{
					ushort num9 = (ushort)a(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(gm), 12m), new decimal(j * 2))), 2);
					if (decimal.Compare(new decimal(gm), 100m) == 0)
					{
						d(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(a(num9, 4)), 1m), new decimal(this.j))));
					}
					else
					{
						d(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(a((int)(gm + num9), 4)), 1m), new decimal(this.j))));
					}
				}
				d(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(a(Convert.ToInt32(decimal.Add(new decimal(gm), 8m)), 4)), 1m), new decimal(this.j))));
			}
		}

		private bool e(ulong gn)
		{
			if (h[(uint)gn] == 13)
			{
				int num = Convert.ToInt32(decimal.Subtract(new decimal(a(Convert.ToInt32(decimal.Add(new decimal(gn), 3m)), 2)), 1m));
				int num2 = 0;
				if (l != null)
				{
					num2 = l.Length;
					l = (ROW[])Utils.CopyArray(l, new ROW[l.Length + num + 1]);
				}
				else
				{
					l = new ROW[num + 1];
				}
				int num3 = num;
				for (int i = 0; i <= num3; i++)
				{
					SZ[] array = null;
					ulong num4 = a(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(gn), 8m), new decimal(i * 2))), 2);
					if (decimal.Compare(new decimal(gn), 100m) != 0)
					{
						num4 += gn;
					}
					int num5 = c((int)num4);
					b((int)num4, num5);
					int num6 = c(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)));
					l[num2 + i].ID = b(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)), num6);
					num4 = Convert.ToUInt64(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num6), new decimal(num4))), 1m));
					num5 = c((int)num4);
					num6 = num5;
					long num7 = b((int)num4, num5);
					long num8 = Convert.ToInt64(decimal.Add(decimal.Subtract(new decimal(num4), new decimal(num5)), 1m));
					int num9 = 0;
					while (num8 < num7)
					{
						array = (SZ[])Utils.CopyArray(array, new SZ[num9 + 1]);
						num5 = num6 + 1;
						num6 = c(num5);
						array[num9].Type = b(num5, num6);
						if (array[num9].Type > 9)
						{
							if (ItIsOdd(array[num9].Type))
							{
								array[num9].Size = (long)Math.Round((double)(array[num9].Type - 13) / 2.0);
							}
							else
							{
								array[num9].Size = (long)Math.Round((double)(array[num9].Type - 12) / 2.0);
							}
						}
						else
						{
							array[num9].Size = m[(int)array[num9].Type];
						}
						num8 = num8 + (num6 - num5) + 1;
						num9++;
					}
					l[num2 + i].RowData = new string[array.Length - 1 + 1];
					int num10 = 0;
					int num11 = array.Length - 1;
					for (int j = 0; j <= num11; j++)
					{
						if (array[j].Type > 9)
						{
							if (!ItIsOdd(array[j].Type))
							{
								if (decimal.Compare(new decimal(this.i), 1m) == 0)
								{
									l[num2 + i].RowData[j] = Encoding.Default.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
								else if (decimal.Compare(new decimal(this.i), 2m) == 0)
								{
									l[num2 + i].RowData[j] = Encoding.Unicode.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
								else if (decimal.Compare(new decimal(this.i), 3m) == 0)
								{
									l[num2 + i].RowData[j] = Encoding.BigEndianUnicode.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
							}
							else
							{
								l[num2 + i].RowData[j] = Encoding.Default.GetString(h, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
							}
						}
						else
						{
							l[num2 + i].RowData[j] = Convert.ToString(a(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size));
						}
						num10 += (int)array[j].Size;
					}
				}
			}
			else if (h[(uint)gn] == 5)
			{
				int num12 = Convert.ToUInt16(decimal.Subtract(new decimal(a(Convert.ToInt32(decimal.Add(new decimal(gn), 3m)), 2)), 1m));
				for (int k = 0; k <= num12; k++)
				{
					ushort num13 = (ushort)a(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(gn), 12m), new decimal(k * 2))), 2);
					e(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(a((int)(gn + num13), 4)), 1m), new decimal(this.j))));
				}
				e(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(a(Convert.ToInt32(decimal.Add(new decimal(gn), 8m)), 4)), 1m), new decimal(this.j))));
			}
			return true;
		}
	}
}
