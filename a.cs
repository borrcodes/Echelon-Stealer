using SimpleJSON;
using System.Text;

internal class a : JSONNode
{
	private JSONNode g;

	private string h;

	public override JSONNodeType Tag => JSONNodeType.None;

	public override JSONNode this[int aIndex]
	{
		get
		{
			return new a(this);
		}
		set
		{
			JSONArray jSONArray = new JSONArray();
			jSONArray.Add(value);
			a(jSONArray);
		}
	}

	public override JSONNode this[string aKey]
	{
		get
		{
			return new a(this, aKey);
		}
		set
		{
			JSONObject jSONObject = new JSONObject();
			jSONObject.Add(aKey, value);
			a(jSONObject);
		}
	}

	public override int AsInt
	{
		get
		{
			JSONNumber p = new JSONNumber(0.0);
			a(p);
			return 0;
		}
		set
		{
			JSONNumber p = new JSONNumber(value);
			a(p);
		}
	}

	public override float AsFloat
	{
		get
		{
			JSONNumber p = new JSONNumber(0.0);
			a(p);
			return 0f;
		}
		set
		{
			JSONNumber p = new JSONNumber(value);
			a(p);
		}
	}

	public override double AsDouble
	{
		get
		{
			JSONNumber p = new JSONNumber(0.0);
			a(p);
			return 0.0;
		}
		set
		{
			JSONNumber p = new JSONNumber(value);
			a(p);
		}
	}

	public override bool AsBool
	{
		get
		{
			JSONBool p = new JSONBool(aData: false);
			a(p);
			return false;
		}
		set
		{
			JSONBool p = new JSONBool(value);
			a(p);
		}
	}

	public override JSONArray AsArray
	{
		get
		{
			JSONArray jSONArray = new JSONArray();
			a(jSONArray);
			return jSONArray;
		}
	}

	public override JSONObject AsObject
	{
		get
		{
			JSONObject jSONObject = new JSONObject();
			a(jSONObject);
			return jSONObject;
		}
	}

	public override Enumerator GetEnumerator()
	{
		return default(Enumerator);
	}

	public a(JSONNode m)
	{
		g = m;
		h = null;
	}

	public a(JSONNode n, string o)
	{
		g = n;
		h = o;
	}

	private void a(JSONNode p)
	{
		if (h == null)
		{
			g.Add(p);
		}
		else
		{
			g.Add(h, p);
		}
		g = null;
	}

	public override void Add(JSONNode aItem)
	{
		JSONArray jSONArray = new JSONArray();
		jSONArray.Add(aItem);
		a(jSONArray);
	}

	public override void Add(string aKey, JSONNode aItem)
	{
		JSONObject jSONObject = new JSONObject();
		jSONObject.Add(aKey, aItem);
		a(jSONObject);
	}

	public static bool operator ==(a a, object b)
	{
		if (b == null)
		{
			return true;
		}
		return (object)a == b;
	}

	public static bool operator !=(a a, object b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return true;
		}
		return (object)this == obj;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	internal override void c(StringBuilder ls, int lt, int lu, JSONTextMode lv)
	{
		ls.Append("null");
	}
}
