using System;
using System.IO;
using UnityEngine;

public class MSHost : MonoBehaviour
{
	public static string[] LoadConfig(string confFileName)
	{
		if (confFileName.Contains(".."))
		{
			return null;
		}
		if (!Directory.Exists(ItemLoader.Dir + "/Configs/" + confFileName))
		{
			Directory.CreateDirectory(ItemLoader.Dir + "/Configs/" + confFileName);
		}
		if (!File.Exists(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		})))
		{
			File.Create(string.Concat(new string[]
			{
				ItemLoader.Dir,
				"/Configs/",
				confFileName,
				"/",
				confFileName
			}));
		}
		return File.ReadAllLines(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		}));
	}

	public static string LoadConfigLine(string confFileName, int linePos)
	{
		if (confFileName.Contains(".."))
		{
			return "";
		}
		if (!Directory.Exists(ItemLoader.Dir + "/Configs/" + confFileName))
		{
			Directory.CreateDirectory(ItemLoader.Dir + "/Configs/" + confFileName);
		}
		if (!File.Exists(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		})))
		{
			File.Create(string.Concat(new string[]
			{
				ItemLoader.Dir,
				"/Configs/",
				confFileName,
				"/",
				confFileName
			}));
		}
		string[] array = File.ReadAllLines(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		}));
		if (array.Length - 1 < linePos)
		{
			return null;
		}
		return array[linePos];
	}

	public static void WriteFullConfig(string confFileName, string[] newFullConf)
	{
		if (confFileName.Contains(".."))
		{
			return;
		}
		if (!Directory.Exists(ItemLoader.Dir + "/Configs/" + confFileName))
		{
			Directory.CreateDirectory(ItemLoader.Dir + "/Configs/" + confFileName);
		}
		File.WriteAllLines(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		}), newFullConf);
	}

	public static void WriteConfigLine(string confFileName, string newConfLine, int linePos)
	{
		if (confFileName.Contains(".."))
		{
			return;
		}
		if (!Directory.Exists(ItemLoader.Dir + "/Configs/" + confFileName))
		{
			Directory.CreateDirectory(ItemLoader.Dir + "/Configs/" + confFileName);
		}
		if (!File.Exists(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		})))
		{
			File.Create(string.Concat(new string[]
			{
				ItemLoader.Dir,
				"/Configs/",
				confFileName,
				"/",
				confFileName
			}));
		}
		string[] array = File.ReadAllLines(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		}));
		if (array.Length - 1 < linePos)
		{
			return;
		}
		array[linePos] = newConfLine;
		File.WriteAllLines(string.Concat(new string[]
		{
			ItemLoader.Dir,
			"/Configs/",
			confFileName,
			"/",
			confFileName
		}), array);
	}

	public static bool FileExists(string FileName)
	{
		return File.Exists(ItemLoader.Dir + FileName);
	}

	public static bool DirectoryExists(string DirName)
	{
		return Directory.Exists(ItemLoader.Dir + DirName);
	}

	public static string[] LoadRecipeArray(string RecipeName)
	{
		if (RecipeName.Contains(".."))
		{
			return null;
		}
		return File.ReadAllLines(ItemLoader.Dir + "/Recipes/Special/" + RecipeName);
	}
}
