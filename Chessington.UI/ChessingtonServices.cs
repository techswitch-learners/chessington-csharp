using Chessington.UI.Caliburn.Micro;

namespace Chessington.UI
{
    /// <summary>
    /// Simple Singleton wrapper for any common application services.
    /// 
    /// We should use this until we transition to Dependency Injection.
    /// </summary>
    public static class ChessingtonServices
    {
        private static IEventAggregator eventAggregator;

        public static IEventAggregator EventAggregator => eventAggregator ?? (eventAggregator = new EventAggregator());
    }
}