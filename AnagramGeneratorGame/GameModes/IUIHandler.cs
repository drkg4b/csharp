using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGeneratorGame.GameModes
{
    public interface IUIHandler
    {
	string AskForString (string message = "");

	int AskForInt (string message = "");

	void WriteMessage(string message = "");

	void Clear();
    }
}
