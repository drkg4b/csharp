using System;
using System.Collections.Generic;

namespace AnagramGeneratorGame.GameModes
{
    public interface IDictionaryLoader
    {
	List<string> LoadDictionary();
    }
}
