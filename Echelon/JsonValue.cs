using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Echelon
{
	public abstract class JsonValue : IEnumerable
	{
		public virtual int Count
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		public abstract JsonType JsonType
		{
			get;
		}

		public virtual JsonValue this[int index]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public virtual JsonValue this[string key]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public static JsonValue Load(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			return Load(new StreamReader(stream, detectEncodingFromByteOrderMarks: true));
		}

		public static JsonValue Load(TextReader textReader)
		{
			if (textReader == null)
			{
				throw new ArgumentNullException("textReader");
			}
			return ToJsonValue(new JavaScriptReader(textReader).Read());
		}

		private static IEnumerable<KeyValuePair<string, JsonValue>> a(IEnumerable<KeyValuePair<string, object>> gr)
		{
			foreach (KeyValuePair<string, object> item in gr)
			{
				yield return new KeyValuePair<string, JsonValue>(item.Key, ToJsonValue(item.Value));
			}
		}

		private static IEnumerable<JsonValue> b(IEnumerable gs)
		{
			foreach (object g in gs)
			{
				yield return ToJsonValue(g);
			}
		}

		public static JsonValue ToJsonValue<T>(T ret)
		{
			if (ret == null)
			{
				return null;
			}
			T val;
			if ((val = ret) is bool)
			{
				return new JsonPrimitive((bool)(object)val);
			}
			if ((val = ret) is byte)
			{
				return new JsonPrimitive((byte)(object)val);
			}
			if ((val = ret) is char)
			{
				return new JsonPrimitive((char)(object)val);
			}
			if ((val = ret) is decimal)
			{
				return new JsonPrimitive((decimal)(object)val);
			}
			if ((val = ret) is double)
			{
				return new JsonPrimitive((double)(object)val);
			}
			if ((val = ret) is float)
			{
				return new JsonPrimitive((float)(object)val);
			}
			if ((val = ret) is int)
			{
				return new JsonPrimitive((int)(object)val);
			}
			if ((val = ret) is long)
			{
				return new JsonPrimitive((long)(object)val);
			}
			if ((val = ret) is sbyte)
			{
				return new JsonPrimitive((sbyte)(object)val);
			}
			if ((val = ret) is short)
			{
				return new JsonPrimitive((short)(object)val);
			}
			string value;
			if ((value = (ret as string)) != null)
			{
				return new JsonPrimitive(value);
			}
			if ((val = ret) is uint)
			{
				return new JsonPrimitive((uint)(object)val);
			}
			if ((val = ret) is ulong)
			{
				return new JsonPrimitive((ulong)(object)val);
			}
			if ((val = ret) is ushort)
			{
				return new JsonPrimitive((ushort)(object)val);
			}
			if ((val = ret) is DateTime)
			{
				return new JsonPrimitive((DateTime)(object)val);
			}
			if ((val = ret) is DateTimeOffset)
			{
				return new JsonPrimitive((DateTimeOffset)(object)val);
			}
			if ((val = ret) is Guid)
			{
				return new JsonPrimitive((Guid)(object)val);
			}
			if ((val = ret) is TimeSpan)
			{
				return new JsonPrimitive((TimeSpan)(object)val);
			}
			Uri value2;
			if ((object)(value2 = (ret as Uri)) != null)
			{
				return new JsonPrimitive(value2);
			}
			IEnumerable<KeyValuePair<string, object>> enumerable = ret as IEnumerable<KeyValuePair<string, object>>;
			if (enumerable != null)
			{
				return new JsonObject(a(enumerable));
			}
			IEnumerable enumerable2 = ret as IEnumerable;
			if (enumerable2 != null)
			{
				return new JsonArray(b(enumerable2));
			}
			if (!(ret is IEnumerable))
			{
				PropertyInfo[] properties = ret.GetType().GetProperties();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(ret, null).IsNull("null"));
				}
				if (dictionary.Count > 0)
				{
					return new JsonObject(a(dictionary));
				}
			}
			throw new NotSupportedException($"Unexpected parser return type: {ret.GetType()}");
		}

		public static JsonValue Parse(string jsonString)
		{
			if (jsonString == null)
			{
				throw new ArgumentNullException("jsonString");
			}
			return Load(new StringReader(jsonString));
		}

		public virtual bool ContainsKey(string key)
		{
			throw new InvalidOperationException();
		}

		public virtual void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			Save(new StreamWriter(stream), parsing);
		}

		public virtual void Save(TextWriter textWriter, bool parsing)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			c(textWriter, parsing);
		}

		private void c(TextWriter gt, bool gu)
		{
			switch (JsonType)
			{
			case JsonType.Object:
			{
				gt.Write('{');
				bool flag2 = false;
				foreach (KeyValuePair<string, JsonValue> item in (JsonObject)this)
				{
					if (flag2)
					{
						gt.Write(", ");
					}
					gt.Write('"');
					gt.Write(EscapeString(item.Key));
					gt.Write("\": ");
					if (item.Value == null)
					{
						gt.Write("null");
					}
					else
					{
						item.Value.c(gt, gu);
					}
					flag2 = true;
				}
				gt.Write('}');
				break;
			}
			case JsonType.Array:
			{
				gt.Write('[');
				bool flag = false;
				foreach (JsonValue item2 in (IEnumerable<JsonValue>)(JsonArray)this)
				{
					if (flag)
					{
						gt.Write(", ");
					}
					if (item2 != null)
					{
						item2.c(gt, gu);
					}
					else
					{
						gt.Write("null");
					}
					flag = true;
				}
				gt.Write(']');
				break;
			}
			case JsonType.Boolean:
				gt.Write(this ? "true" : "false");
				break;
			case JsonType.String:
				if (gu)
				{
					gt.Write('"');
				}
				gt.Write(EscapeString(((JsonPrimitive)this).GetFormattedString()));
				if (gu)
				{
					gt.Write('"');
				}
				break;
			default:
				gt.Write(((JsonPrimitive)this).GetFormattedString());
				break;
			}
		}

		public string ToString(bool saving = true)
		{
			StringWriter stringWriter = new StringWriter();
			Save(stringWriter, saving);
			return stringWriter.ToString();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new InvalidOperationException();
		}

		private bool d(string gv, int gw)
		{
			char c = gv[gw];
			if (c >= ' ' && c != '"' && c != '\\' && (c < '\ud800' || c > '\udbff' || (gw != gv.Length - 1 && gv[gw + 1] >= '\udc00' && gv[gw + 1] <= '\udfff')) && (c < '\udc00' || c > '\udfff' || (gw != 0 && gv[gw - 1] >= '\ud800' && gv[gw - 1] <= '\udbff')) && c != '\u2028' && c != '\u2029')
			{
				if (c == '/' && gw > 0)
				{
					return gv[gw - 1] == '<';
				}
				return false;
			}
			return true;
		}

		public string EscapeString(string src)
		{
			if (src == null)
			{
				return null;
			}
			for (int i = 0; i < src.Length; i++)
			{
				if (d(src, i))
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (i > 0)
					{
						stringBuilder.Append(src, 0, i);
					}
					return e(stringBuilder, src, i);
				}
			}
			return src;
		}

		private string e(StringBuilder gx, string gy, int gz)
		{
			int num = gz;
			for (int i = gz; i < gy.Length; i++)
			{
				if (d(gy, i))
				{
					gx.Append(gy, num, i - num);
					switch (gy[i])
					{
					case '\b':
						gx.Append("\\b");
						break;
					case '\f':
						gx.Append("\\f");
						break;
					case '\n':
						gx.Append("\\n");
						break;
					case '\r':
						gx.Append("\\r");
						break;
					case '\t':
						gx.Append("\\t");
						break;
					case '"':
						gx.Append("\\\"");
						break;
					case '\\':
						gx.Append("\\\\");
						break;
					case '/':
						gx.Append("\\/");
						break;
					default:
						gx.Append("\\u");
						gx.Append(((int)gy[i]).ToString("x04"));
						break;
					}
					num = i + 1;
				}
			}
			gx.Append(gy, num, gy.Length - num);
			return gx.ToString();
		}

		public static implicit operator JsonValue(bool value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(byte value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(char value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(decimal value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(double value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(float value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(int value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(long value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(sbyte value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(short value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(string value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(uint value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(ulong value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(ushort value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(DateTime value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(DateTimeOffset value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(Guid value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(TimeSpan value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator JsonValue(Uri value)
		{
			return new JsonPrimitive(value);
		}

		public static implicit operator bool(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToBoolean(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator byte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator char(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToChar(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator decimal(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDecimal(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator double(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDouble(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator float(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSingle(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator int(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator long(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator sbyte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator short(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator string(JsonValue value)
		{
			return value?.ToString();
		}

		public static implicit operator uint(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator ulong(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator ushort(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		public static implicit operator DateTime(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTime)((JsonPrimitive)value).Value;
		}

		public static implicit operator DateTimeOffset(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTimeOffset)((JsonPrimitive)value).Value;
		}

		public static implicit operator TimeSpan(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (TimeSpan)((JsonPrimitive)value).Value;
		}

		public static implicit operator Guid(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Guid)((JsonPrimitive)value).Value;
		}

		public static implicit operator Uri(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Uri)((JsonPrimitive)value).Value;
		}
	}
}
