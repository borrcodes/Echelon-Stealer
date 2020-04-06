using System;
using System.Runtime.InteropServices;

internal class ac
{
	private const uint m_a = 13u;

	public static string a()
	{
		if (m.d(13u) && m.e(IntPtr.Zero))
		{
			string result = string.Empty;
			IntPtr an = m.c(13u);
			if (!an.Equals(IntPtr.Zero))
			{
				IntPtr intPtr = m.h(an);
				if (!intPtr.Equals(IntPtr.Zero))
				{
					try
					{
						result = Marshal.PtrToStringUni(intPtr);
						m.i(intPtr);
					}
					catch
					{
					}
				}
			}
			m.f();
			return result;
		}
		return null;
	}
}
