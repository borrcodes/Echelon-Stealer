using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Echelon
{
	public class JsonPrimitive : JsonValue
	{
		private object c;

		private static readonly byte[] d = Encoding.UTF8.GetBytes("true");

		private static readonly byte[] e = Encoding.UTF8.GetBytes("false");

		public object Value => c;

		public override JsonType JsonType
		{
			get
			{
				if (c == null)
				{
					return JsonType.String;
				}
				switch (Type.GetTypeCode(c.GetType()))
				{
				case TypeCode.Boolean:
					return JsonType.Boolean;
				case TypeCode.Object:
				case TypeCode.Char:
				case TypeCode.DateTime:
				case TypeCode.String:
					return JsonType.String;
				default:
					return JsonType.Number;
				}
			}
		}

		public JsonPrimitive(bool value)
		{
			c = value;
		}

		public JsonPrimitive(byte value)
		{
			c = value;
		}

		public JsonPrimitive(char value)
		{
			c = value;
		}

		public JsonPrimitive(decimal value)
		{
			c = value;
		}

		public JsonPrimitive(double value)
		{
			c = value;
		}

		public JsonPrimitive(float value)
		{
			c = value;
		}

		public JsonPrimitive(int value)
		{
			c = value;
		}

		public JsonPrimitive(long value)
		{
			c = value;
		}

		public JsonPrimitive(sbyte value)
		{
			c = value;
		}

		public JsonPrimitive(short value)
		{
			c = value;
		}

		public JsonPrimitive(string value)
		{
			c = value;
		}

		public JsonPrimitive(DateTime value)
		{
			c = value;
		}

		public JsonPrimitive(uint value)
		{
			c = value;
		}

		public JsonPrimitive(ulong value)
		{
			c = value;
		}

		public JsonPrimitive(ushort value)
		{
			c = value;
		}

		public JsonPrimitive(DateTimeOffset value)
		{
			c = value;
		}

		public JsonPrimitive(Guid value)
		{
			c = value;
		}

		public JsonPrimitive(TimeSpan value)
		{
			c = value;
		}

		public JsonPrimitive(Uri value)
		{
			c = value;
		}

		public JsonPrimitive(object value)
		{
			c = value;
		}

		public override void Save(Stream stream, bool parsing)
		{
			switch (JsonType)
			{
			case JsonType.Boolean:
				if ((bool)c)
				{
					stream.Write(d, 0, 4);
				}
				else
				{
					stream.Write(e, 0, 5);
				}
				break;
			case JsonType.String:
			{
				stream.WriteByte(34);
				byte[] bytes2 = Encoding.UTF8.GetBytes(EscapeString(c.ToString()));
				stream.Write(bytes2, 0, bytes2.Length);
				stream.WriteByte(34);
				break;
			}
			default:
			{
				byte[] bytes = Encoding.UTF8.GetBytes(GetFormattedString());
				stream.Write(bytes, 0, bytes.Length);
				break;
			}
			}
		}

		public string GetFormattedString()
		{
			switch (JsonType)
			{
			case JsonType.String:
				if (c is string || c == null)
				{
					string text2 = c as string;
					if (string.IsNullOrEmpty(text2))
					{
						return "null";
					}
					return text2.Trim('"');
				}
				if (c is char)
				{
					return c.ToString();
				}
				throw new NotImplementedException("GetFormattedString from value type " + c.GetType());
			case JsonType.Number:
			{
				string text = (!(c is float) && !(c is double)) ? ((IFormattable)c).ToString("G", NumberFormatInfo.InvariantInfo) : ((IFormattable)c).ToString("R", NumberFormatInfo.InvariantInfo);
				switch (text)
				{
				case "NaN":
				case "Infinity":
				case "-Infinity":
					return "\"" + text + "\"";
				default:
					return text;
				}
			}
			default:
				throw new InvalidOperationException();
			}
		}
	}
}
