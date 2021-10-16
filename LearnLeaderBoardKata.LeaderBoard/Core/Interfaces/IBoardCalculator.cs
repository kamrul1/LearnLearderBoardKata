using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System.Collections.Generic;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public interface IBoardCalculator<T> where T:class
    {
        void AddNextScoreValueToNextPlayerRank(out int rankPosition, out int previousScore, int i);
        void AddScoreValueToPlayerRank(int rankPosition, int previousScore, int i);
        void CreateRankByAssendingScore(ref int rankPosition, ref int previousScore);
        void CreateRankByDescendingScore(ref int rankPosition, ref int previousScore);
        int GetInitialPreviousScore();
        IEnumerable<ScoreableItemRank> GetRanking();
    }
}