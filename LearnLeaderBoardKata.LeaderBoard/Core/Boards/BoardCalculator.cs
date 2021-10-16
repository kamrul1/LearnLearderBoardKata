
using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    /// <summary>
    /// Base class that accepts a player list with IComparable implemented for sorting
    /// </summary>
    public abstract class BoardCalculator<T> : IBoardCalculator<T> where T : class
    {
        protected const int RANK_MIN = 1;
        protected readonly List<IScoreSortableItem<T>> scoreableItem;
        protected readonly GameRankOrder gameRankOrder;
        protected List<ScoreableItemRank> scoreableItemsRank;

        public BoardCalculator(List<IScoreSortableItem<T>> scoreableItem, GameRankOrder gameRankOrder)
        {
            this.scoreableItem = scoreableItem;
            this.gameRankOrder = gameRankOrder;
        }

        public virtual IEnumerable<ScoreableItemRank> GetRanking()
        {

            scoreableItem.Sort();

            int rankPosition = RANK_MIN;
            int previousScore = GetInitialPreviousScore();

            scoreableItemsRank = new();


            if (gameRankOrder == GameRankOrder.Assending)
            {
                CreateRankByAssendingScore(ref rankPosition, ref previousScore);
            }

            if (gameRankOrder == GameRankOrder.Desending)
            {
                CreateRankByDescendingScore(ref rankPosition, ref previousScore);
            }

            return scoreableItemsRank;

        }

        public virtual void CreateRankByAssendingScore(ref int rankPosition, ref int previousScore)
        {
            for (int i = 0; i < scoreableItem.Count; i++)
            {
                if (scoreableItem[i].Score == previousScore)
                {
                    AddScoreValueToPlayerRank(rankPosition, previousScore, i);
                    continue;
                }

                AddNextScoreValueToNextPlayerRank(out rankPosition, out previousScore, i);
            }
        }

        public virtual void CreateRankByDescendingScore(ref int rankPosition, ref int previousScore)
        {
            for (int i = scoreableItem.Count - 1; i >= 0; i--)
            {
                if (scoreableItem[i].Score == previousScore)
                {
                    AddScoreValueToPlayerRank(rankPosition, previousScore, i);
                    continue;
                }

                AddNextScoreValueToNextPlayerRank(out rankPosition, out previousScore, i);
            }
        }


        public virtual void AddScoreValueToPlayerRank(int rankPosition, int previousScore, int i)
        {
            scoreableItemsRank.Add
                (
                    new ScoreableItemRank { Name = scoreableItem[i].Name, Score = previousScore, Rank = rankPosition }
                );
        }

        public virtual void AddNextScoreValueToNextPlayerRank(out int rankPosition, out int previousScore, int i)
        {
            previousScore = scoreableItem[i].Score;
            rankPosition = i+1;

            scoreableItemsRank.Add
                (
                    new ScoreableItemRank { Name = scoreableItem[i].Name, Rank = rankPosition, Score = scoreableItem[i].Score }
                );
        }

        public int GetInitialPreviousScore()
        {
            if (gameRankOrder == GameRankOrder.Assending)
            {
                return scoreableItem.FirstOrDefault().Score;
            }

            return scoreableItem.FirstOrDefault(x => x.Score == scoreableItem.Min(y => y.Score)).Score;
        }
    }
}
