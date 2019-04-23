using System;
using System.Collections.Generic;
using AnagramGeneratorGame.GameModes;
using AnagramGeneratorGame.Repositories;

namespace AnagramGenerator
{
    class Program : IUIHandler
    {
        static void Main(string[] args)
        {
            new Program().Run();

            Console.ReadKey(true);
        }

        public string AskForString(string message = "")
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            return Console.ReadLine();
        }

        public int AskForInt(string message = "")
        {
            int? selection = null;

            do
            {
                string input = AskForString(message);

                try
                {
                    selection = int.Parse(input);

                    if (selection <= 0)
                    {

                        WriteMessage("Sorry the value must be positive!");
                    }
                }
                catch (Exception)
                {
                    WriteMessage("Selection not valid");
                }

            } while (!selection.HasValue);

            return selection.Value;
        }

        public void WriteMessage(string message = "")
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        private IGameplay SelectGame(List<IGameplay> games)
        {
            IGameplay game = null;

            do
            {
                WriteMessage("Please select a game");

                for (int i = 1; i <= games.Count; ++i)
                {

                    WriteMessage($"{i} - {games[i - 1].Description}");
                }

                int gameSelected = AskForInt();

                try
                {
                    game = games[gameSelected - 1];
                }
                catch (Exception)
                {
                    WriteMessage("Invalid game! Press ENTER to continue");

                    Console.ReadLine();
                    Console.Clear();
                }

            } while (game == null);

            return game;
        }

        private void Run()
        {
	    IWordsRepository repo = new WordsRepository(new DictionaryLoader());

	    List<IGameplay> games = new List<IGameplay>
	    {
		new Training(repo),
		new Challenge(repo)
	    };

            IGameplay game = SelectGame(games);

            game.Run(this);
        }
    }
}
