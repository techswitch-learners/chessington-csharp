using Chessington.GameEngine;

namespace Chessington.UI.Notifications
{
    public class CurrentPlayerChanged
    {
        public CurrentPlayerChanged(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
    }
}