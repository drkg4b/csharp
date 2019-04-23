using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramGeneratorGame.GameModes
{
    public interface IGameplay
    {
        void Run(IUIHandler uiHandler);

        string Description { get; }
    }
}
