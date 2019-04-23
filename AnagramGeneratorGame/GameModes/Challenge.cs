using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGeneratorGame.GameModes
{
    public class Challenge : IGameplay
    {
	static readonly TimeSpan TIMEOUT = TimeSpan.FromSeconds(10);

	private readonly IWordsRepository m_wordsRepository;

	public Challenge(IWordsRepository wordsRepository)
	{
	    m_wordsRepository = wordsRepository;
	}

	public string Description => "Find the anagram of the proposed word"
	    + " within the time limit.";

	public void Run(IUIHandler uiHandler)
	{
	    string word = m_wordsRepository.GetRandomWord(7);

	    uiHandler.WriteMessage($"The selected word is {word.ToUpper()}");
	    uiHandler.WriteMessage("You have 10 seconds, ready? GO!!!");

	    DateTime startTime = DateTime.Now;

	    do
	    {
		string guess = uiHandler.AskForString("Insert your guess...");

		if(m_wordsRepository.IsAnagram(word, guess))
		{
		    uiHandler.WriteMessage("Great!!! You got it!");

		    break;
		}
		else
		{
		    uiHandler.WriteMessage($"Wrong!! You have" +
					   $" {TimeLeft(startTime)} seconds left!");
		}

	    } while (!IsTimeUp(startTime));
	}

	private double TimeLeft(DateTime startTime)
	{
	    var timeLeft = (TIMEOUT - (DateTime.Now - startTime)).TotalSeconds;

	    return timeLeft < 0 ? 0 : timeLeft;
	}

	private bool IsTimeUp(DateTime startTime)
	{
	    return DateTime.Now - startTime > TIMEOUT;
	}
    }
}
