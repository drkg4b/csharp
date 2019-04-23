using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using AnagramGeneratorGame.GameModes;

namespace AnagramGeneratorGame.Repositories
{
    public class DictionaryLoader : IDictionaryLoader
    {
	readonly string _dictionaryPath =
	    string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
			  Path.DirectorySeparatorChar, "Repositories",
			  Path.DirectorySeparatorChar, "660000_parole_italiane.txt");

	public List<string> LoadDictionary()
	{
	    try
	    {
		return File.ReadAllLines(_dictionaryPath).ToList();
	    }
	    catch (Exception e)
	    {
		throw new Exception($"Error reading file { _dictionaryPath }", e);
	    }
	}
    }
}
