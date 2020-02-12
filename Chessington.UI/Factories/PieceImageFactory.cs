﻿using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Chessington.GameEngine.Pieces;

namespace Chessington.UI.Factories
{
    /// <summary>
    /// Given a piece, returns in image for that piece. Change things here if you want new icons.
    /// </summary>
    public static class PieceImageFactory
    {
        private static readonly Dictionary<Type, string> PieceSuffixes = new Dictionary<Type, string>
        {
            { typeof(Pawn), "pawn" },
            { typeof(Rook), "rook" },
            { typeof(Knight), "knight" },
            { typeof(Bishop), "bishop" },
            { typeof(King), "king" },
            { typeof(Queen), "queen" },
        };

        public static BitmapImage GetImage(Piece piece)
        {
            return new BitmapImage(new Uri(string.Format($"{InterfaceSettings.IconRoot}{piece.Player}-{PieceSuffixes[piece.GetType()]}.ico")));
        }
    }
}