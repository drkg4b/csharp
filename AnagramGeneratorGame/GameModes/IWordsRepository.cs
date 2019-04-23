using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGeneratorGame.GameModes
{
    public interface IWordsRepository
    {
	List<string> GetAnagrams(string word);

	bool IsAnagram(string sourceWord, string candidateAnagram);

	string GetRandomWord(int minimumAnagrams = 1);
    }
}
