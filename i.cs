using System.IO.Compression;

internal class i
{
	public static void a(string ab, string ac)
	{
		try
		{
			ZipFile.CreateFromDirectory(ab, ac, CompressionLevel.Optimal, includeBaseDirectory: false);
		}
		catch
		{
		}
	}
}
