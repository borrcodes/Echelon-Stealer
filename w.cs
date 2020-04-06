internal sealed class w
{
	private w()
	{
	}

	internal static void a(uint cz, byte[] da)
	{
		da[0] = (byte)(cz >> 24);
		da[1] = (byte)(cz >> 16);
		da[2] = (byte)(cz >> 8);
		da[3] = (byte)cz;
	}

	internal static void b(uint db, byte[] dc, int dd)
	{
		dc[dd] = (byte)(db >> 24);
		dc[++dd] = (byte)(db >> 16);
		dc[++dd] = (byte)(db >> 8);
		dc[++dd] = (byte)db;
	}

	internal static uint c(byte[] de)
	{
		return (uint)((de[0] << 24) | (de[1] << 16) | (de[2] << 8) | de[3]);
	}

	internal static uint d(byte[] df, int dg)
	{
		return (uint)((df[dg] << 24) | (df[++dg] << 16) | (df[++dg] << 8) | df[++dg]);
	}

	internal static ulong e(byte[] dh)
	{
		uint num = c(dh);
		uint num2 = d(dh, 4);
		return ((ulong)num << 32) | num2;
	}

	internal static ulong f(byte[] di, int dj)
	{
		uint num = d(di, dj);
		uint num2 = d(di, dj + 4);
		return ((ulong)num << 32) | num2;
	}

	internal static void g(ulong dk, byte[] dl)
	{
		a((uint)(dk >> 32), dl);
		b((uint)dk, dl, 4);
	}

	internal static void h(ulong dm, byte[] dn, int dp)
	{
		b((uint)(dm >> 32), dn, dp);
		b((uint)dm, dn, dp + 4);
	}

	internal static void i(uint dq, byte[] dr)
	{
		dr[0] = (byte)dq;
		dr[1] = (byte)(dq >> 8);
		dr[2] = (byte)(dq >> 16);
		dr[3] = (byte)(dq >> 24);
	}

	internal static void j(uint ds, byte[] dt, int du)
	{
		dt[du] = (byte)ds;
		dt[++du] = (byte)(ds >> 8);
		dt[++du] = (byte)(ds >> 16);
		dt[++du] = (byte)(ds >> 24);
	}

	internal static uint k(byte[] dv)
	{
		return (uint)(dv[0] | (dv[1] << 8) | (dv[2] << 16) | (dv[3] << 24));
	}

	internal static uint l(byte[] dw, int dx)
	{
		return (uint)(dw[dx] | (dw[++dx] << 8) | (dw[++dx] << 16) | (dw[++dx] << 24));
	}

	internal static ulong m(byte[] dy)
	{
		uint num = k(dy);
		return ((ulong)l(dy, 4) << 32) | num;
	}

	internal static ulong n(byte[] dz, int ea)
	{
		uint num = l(dz, ea);
		return ((ulong)l(dz, ea + 4) << 32) | num;
	}

	internal static void o(ulong eb, byte[] ec)
	{
		i((uint)eb, ec);
		j((uint)(eb >> 32), ec, 4);
	}

	internal static void p(ulong ed, byte[] ee, int ef)
	{
		j((uint)ed, ee, ef);
		j((uint)(ed >> 32), ee, ef + 4);
	}
}
