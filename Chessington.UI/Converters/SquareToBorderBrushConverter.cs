using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Chessington.UI.ViewModels;

namespace Chessington.UI.Converters
{
    /// <summary>
    /// Given a ChessSquare object, returns a Brush which can be used to colour that square's border.
    /// </summary>
    public class SquareToBorderBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = value as SquareViewModel;

            if (square == null)
                throw new ArgumentException("This converter is only valid for ChessSquare objects.", "value");

            if (square.Selected)
                return new SolidColorBrush(InterfaceSettings.SelectedSquareColor);

            if (square.ValidMovementTarget)
                return new SolidColorBrush(InterfaceSettings.ValidMovementTargetColor);

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}