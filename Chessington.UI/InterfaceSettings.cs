using System.Windows.Media;

namespace Chessington.UI
{
    /// <summary>
    /// Holds application-level settings for the user interface.
    /// </summary>
    public static class InterfaceSettings
    {
        public const int SquareSize = 50;
        public const string IconRoot = "pack://application:,,,/Icons/";

        public static readonly Color SelectedSquareColor = Colors.BlueViolet;
        public static readonly Color ValidMovementTargetColor = Colors.YellowGreen;
    }
}