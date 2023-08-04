using System;
using Task3.Data;

namespace Task3
{
    internal class Rules
    {
        public List<Move> Moves { get; private set; } = new();

        public void ConfigureRules(List<string> moves, int movesAmountInSemicircle)
        {
            for (int i = 0; i < moves.Count; i++)
                Moves.Add(new Move
                {
                    Name = moves[i],
                    Strongers = getNextMoves(moves, i, movesAmountInSemicircle),
                    Weakers = getPreviousMoves(moves, i, movesAmountInSemicircle)
                });
        }

        public GameResult GetGameResult(Move playerMove, Move computerMove) => playerMove.GetResult(computerMove);

        private List<string> getNextMoves(List<string> moves, int currentIndex, int amount)
        {
            List<string> nextMoves = new();
            for (int i = 1; i <= amount; i++)
                nextMoves.Add(moves[(currentIndex + i) % moves.Count]);
            return nextMoves;
        }

        private List<string> getPreviousMoves(List<string> moves, int currentIndex, int amount)
        {
            List<string> previousMoves = new();
            for (int i = 1; i <= amount; i++)
            {
                int prevIndex = (currentIndex - i) % moves.Count;
                if (prevIndex < 0) prevIndex += moves.Count;
                previousMoves.Add(moves[prevIndex]);
            }
            return previousMoves;
        }
    }
}