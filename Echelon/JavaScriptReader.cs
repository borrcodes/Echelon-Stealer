using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Echelon
{
	public class JavaScriptReader
	{
		private readonly StringBuilder m_a;

		private readonly TextReader m_b;

		private int m_c = 1;

		private int m_d;

		private int m_e;

		private bool m_f;

		private bool m_g;

		public JavaScriptReader(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.m_b = reader;
			this.m_a = new StringBuilder();
		}

		public object Read()
		{
			object result = a();
			d();
			if (c() >= 0)
			{
				throw i("extra characters in JSON input");
			}
			return result;
		}

		private object a()
		{
			d();
			int num = b();
			if (num < 0)
			{
				throw i("Incomplete JSON input");
			}
			switch (num)
			{
			case 91:
			{
				c();
				List<object> list = new List<object>();
				d();
				if (b() == 93)
				{
					c();
					return list;
				}
				while (true)
				{
					object item = a();
					list.Add(item);
					d();
					num = b();
					if (num != 44)
					{
						break;
					}
					c();
				}
				if (c() != 93)
				{
					throw i("JSON array must end with ']'");
				}
				return list.ToArray();
			}
			case 123:
			{
				c();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				d();
				if (b() == 125)
				{
					c();
					return dictionary;
				}
				do
				{
					d();
					if (b() == 125)
					{
						c();
						break;
					}
					string key = f();
					d();
					g(':');
					d();
					dictionary[key] = a();
					d();
					num = c();
				}
				while (num == 44 || num != 125);
				int num2 = 0;
				KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[dictionary.Count];
				{
					foreach (KeyValuePair<string, object> item2 in dictionary)
					{
						array[num2++] = item2;
					}
					return array;
				}
			}
			case 116:
				h("true");
				return true;
			case 102:
				h("false");
				return false;
			case 110:
				h("null");
				return null;
			case 34:
				return f();
			default:
				if ((48 <= num && num <= 57) || num == 45)
				{
					return e();
				}
				throw i($"Unexpected character '{(char)num}'");
			}
		}

		private int b()
		{
			if (!this.m_f)
			{
				this.m_e = this.m_b.Read();
				this.m_f = true;
			}
			return this.m_e;
		}

		private int c()
		{
			int num = this.m_f ? this.m_e : this.m_b.Read();
			this.m_f = false;
			if (this.m_g)
			{
				this.m_c++;
				this.m_d = 0;
				this.m_g = false;
			}
			if (num == 10)
			{
				this.m_g = true;
			}
			this.m_d++;
			return num;
		}

		private void d()
		{
			while (true)
			{
				int num = b();
				if ((uint)(num - 9) > 1u && num != 13 && num != 32)
				{
					break;
				}
				c();
			}
		}

		private object e()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (b() == 45)
			{
				stringBuilder.Append((char)c());
			}
			int num = 0;
			bool flag = b() == 48;
			int num2;
			while (true)
			{
				num2 = b();
				if (num2 < 48 || 57 < num2)
				{
					break;
				}
				stringBuilder.Append((char)c());
				if (flag && num == 1)
				{
					throw i("leading zeros are not allowed");
				}
				num++;
			}
			if (num == 0)
			{
				throw i("Invalid JSON numeric literal; no digit found");
			}
			bool flag2 = false;
			int num3 = 0;
			if (b() == 46)
			{
				flag2 = true;
				stringBuilder.Append((char)c());
				if (b() < 0)
				{
					throw i("Invalid JSON numeric literal; extra dot");
				}
				while (true)
				{
					num2 = b();
					if (num2 < 48 || 57 < num2)
					{
						break;
					}
					stringBuilder.Append((char)c());
					num3++;
				}
				if (num3 == 0)
				{
					throw i("Invalid JSON numeric literal; extra dot");
				}
			}
			num2 = b();
			if (num2 != 101 && num2 != 69)
			{
				if (!flag2)
				{
					if (int.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out int result))
					{
						return result;
					}
					if (long.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out long result2))
					{
						return result2;
					}
					if (ulong.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out ulong result3))
					{
						return result3;
					}
				}
				if (decimal.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result4) && result4 != 0m)
				{
					return result4;
				}
			}
			else
			{
				stringBuilder.Append((char)c());
				if (b() < 0)
				{
					throw new ArgumentException("Invalid JSON numeric literal; incomplete exponent");
				}
				switch (b())
				{
				case 45:
					stringBuilder.Append((char)c());
					break;
				case 43:
					stringBuilder.Append((char)c());
					break;
				}
				if (b() < 0)
				{
					throw i("Invalid JSON numeric literal; incomplete exponent");
				}
				while (true)
				{
					num2 = b();
					if (num2 < 48 || 57 < num2)
					{
						break;
					}
					stringBuilder.Append((char)c());
				}
			}
			return double.Parse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		private string f()
		{
			if (b() != 34)
			{
				throw this.i("Invalid JSON string literal format");
			}
			c();
			this.m_a.Length = 0;
			while (true)
			{
				int num = c();
				if (num < 0)
				{
					break;
				}
				switch (num)
				{
				case 34:
					return this.m_a.ToString();
				default:
					this.m_a.Append((char)num);
					break;
				case 92:
					num = c();
					if (num < 0)
					{
						throw this.i("Invalid JSON string literal; incomplete escape sequence");
					}
					switch (num)
					{
					case 34:
					case 47:
					case 92:
						this.m_a.Append((char)num);
						break;
					case 98:
						this.m_a.Append('\b');
						break;
					case 102:
						this.m_a.Append('\f');
						break;
					case 110:
						this.m_a.Append('\n');
						break;
					case 114:
						this.m_a.Append('\r');
						break;
					case 116:
						this.m_a.Append('\t');
						break;
					case 117:
					{
						ushort num2 = 0;
						for (int i = 0; i < 4; i++)
						{
							num2 = (ushort)(num2 << 4);
							if ((num = c()) < 0)
							{
								throw this.i("Incomplete unicode character escape literal");
							}
							if (48 <= num && num <= 57)
							{
								num2 = (ushort)(num2 + (ushort)(num - 48));
							}
							if (65 <= num && num <= 70)
							{
								num2 = (ushort)(num2 + (ushort)(num - 65 + 10));
							}
							if (97 <= num && num <= 102)
							{
								num2 = (ushort)(num2 + (ushort)(num - 97 + 10));
							}
						}
						this.m_a.Append((char)num2);
						break;
					}
					default:
						throw this.i("Invalid JSON string literal; unexpected escape character");
					}
					break;
				}
			}
			throw this.i("JSON string is not closed");
		}

		private void g(char go)
		{
			int num;
			if ((num = c()) != go)
			{
				throw i($"Expected '{go}', got '{(char)num}'");
			}
		}

		private void h(string gp)
		{
			int num = 0;
			while (true)
			{
				if (num < gp.Length)
				{
					if (c() != gp[num])
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			throw i($"Expected '{gp}', differed at {num}");
		}

		private Exception i(string gq)
		{
			return new ArgumentException($"{gq}. At line {this.m_c}, column {this.m_d}");
		}
	}
}
