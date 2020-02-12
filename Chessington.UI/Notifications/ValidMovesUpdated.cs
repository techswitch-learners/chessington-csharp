﻿using System.Collections.Generic;
using Chessington.GameEngine;

namespace Chessington.UI.Notifications
{
    public class ValidMovesUpdated
    {
        public IReadOnlyCollection<Square> Moves { get; private set; }

        public ValidMovesUpdated(IReadOnlyCollection<Square> moves)
        {
            Moves = moves;
        }
    }
}