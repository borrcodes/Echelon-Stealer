using System;
using System.Runtime.InteropServices;

internal class m
{
	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	internal static extern IntPtr a(string ah);

	[DllImport("Kernel32.dll", EntryPoint = "CheckRemoteDebuggerPresent", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool b(IntPtr ai, [MarshalAs(UnmanagedType.Bool)] ref bool aj);

	[DllImport("user32.dll", EntryPoint = "GetClipboardData")]
	internal static extern IntPtr c(uint ak);

	[DllImport("user32.dll", EntryPoint = "IsClipboardFormatAvailable")]
	public static extern bool d(uint al);

	[DllImport("user32.dll", EntryPoint = "OpenClipboard", SetLastError = true)]
	internal static extern bool e(IntPtr am);

	[DllImport("user32.dll", EntryPoint = "CloseClipboard", SetLastError = true)]
	internal static extern bool f();

	[DllImport("user32.dll", EntryPoint = "EmptyClipboard")]
	internal static extern bool g();

	[DllImport("kernel32.dll", EntryPoint = "GlobalLock")]
	internal static extern IntPtr h(IntPtr an);

	[DllImport("kernel32.dll", EntryPoint = "GlobalUnlock")]
	internal static extern bool i(IntPtr ao);
}
