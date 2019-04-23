using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGeneratorGame.GameModes
{
    public class Training : IGameplay
    {
        readonly IWordsRepository m_words;

        public Training(IWordsRepository wordsRepository)
        {
            m_words = wordsRepository;
        }

        public string Description => "Training mode: Insert a word and get the" +
            " anagrams";

        public void Run(IUIHandler uiHandler)
        {
            do
            {
                uiHandler.Clear();

                string word = uiHandler.AskForString("Insert a word you want to know the"
                               + "anagrams of");

		var anagrams = m_words.GetAnagrams(word);

		uiHandler.WriteMessage("Found anagrams:");

		foreach (var anagram in anagrams)
		{
		    uiHandler.WriteMessage($"\t{anagram}");
		}

            } while (AnotherMatch(uiHandler));

	    uiHandler.WriteMessage("Game Over!");
        }

        private bool AnotherMatch(IUIHandler uiHandler)
        {
            string choice = uiHandler.AskForString("Play another game? (Y/N)");

            return "Y".Equals(choice, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
