using System;
using System.Collections.Generic;
using System.Linq;
using AnagramGeneratorGame.GameModes;

namespace AnagramGeneratorGame.Repositories
{
    public class WordsRepository : IWordsRepository
    {
        readonly List<string> m_words;

	public WordsRepository(IDictionaryLoader loader)
	{
	    m_words = loader.LoadDictionary();
	}

        public List<string> GetAnagrams(string word)
        {
            return m_words.Where(w => w.Length == word.Length &&
				 IsAnagram(w, word)).ToList();
        }

        public bool IsAnagram(string sourceWord, string candidateAnagram)
        {
            if (sourceWord.Equals(candidateAnagram))

                return false;

            if (sourceWord.Length != candidateAnagram.Length)

                return false;

            var lowerSource =
		string.Concat(sourceWord.ToLower().OrderBy(c => c));

            var lowerCandidate =
		string.Concat(candidateAnagram.ToLower().OrderBy(c => c));

        return lowerSource == lowerCandidate;
        }

        public string GetRandomWord(int minimumAnagrams = 1)
        {
	    string word = null;

	    do
	    {
		Random rnd = new Random(DateTime.Now.Millisecond);

		string candidateWord = m_words[rnd.Next(m_words.Count)];

		System.Diagnostics.Debug.WriteLine($"Testing {candidateWord}");

		if(GetAnagrams(candidateWord).Count >= minimumAnagrams)
		{
		    word = candidateWord;
		}

	    } while (string.IsNullOrEmpty(word));

            return word;
        }
    }
}
