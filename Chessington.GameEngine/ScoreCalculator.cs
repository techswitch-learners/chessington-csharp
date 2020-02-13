namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private Board _board;

        public ScoreCalculator(Board board)
        {
            _board = board;
        }

        public int GetWhiteScore()
        {
            // Should add up the value of all of the pieces that white has taken.
            return 0;
        }

        public int GetBlackScore()
        {
            // Should add up the value of all of the pieces that black has taken.
            return 0;
        }
    }
}