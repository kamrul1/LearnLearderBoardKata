
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
    public abstract class BoardCalculator : IBoardCalculator
    {
        protected const int RANK_MIN = 1;
        protected readonly List<Player> players;
        protected readonly GameRankOrder gameRankOrder;
        protected List<PlayerRank> playerRanks;

        public BoardCalculator(List<Player> players, GameRankOrder gameRankOrder)
        {
            this.players = players;
            this.gameRankOrder = gameRankOrder;
        }

        public virtual IEnumerable<PlayerRank> GetRanking()
        {

            players.Sort();

            int rankPosition = RANK_MIN;
            int previousScore = GetInitialPreviousScore();

            playerRanks = new();


            if (gameRankOrder == GameRankOrder.Assending)
            {
                CreateRankByAssendingScore(ref rankPosition, ref previousScore);
            }

            if (gameRankOrder == GameRankOrder.Desending)
            {
                CreateRankByDescendingScore(ref rankPosition, ref previousScore);
            }

            return playerRanks;

        }

        public virtual void CreateRankByAssendingScore(ref int rankPosition, ref int previousScore)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Score == previousScore)
                {
                    AddScoreValueToPlayerRank(rankPosition, previousScore, i);
                    continue;
                }

                AddNextScoreValueToNextPlayerRank(out rankPosition, out previousScore, i);
            }
        }

        public virtual void CreateRankByDescendingScore(ref int rankPosition, ref int previousScore)
        {
            for (int i = players.Count - 1; i >= 0; i--)
            {
                if (players[i].Score == previousScore)
                {
                    AddScoreValueToPlayerRank(rankPosition, previousScore, i);
                    continue;
                }

                AddNextScoreValueToNextPlayerRank(out rankPosition, out previousScore, i);
            }
        }


        public virtual void AddScoreValueToPlayerRank(int rankPosition, int previousScore, int i)
        {
            playerRanks.Add
                (
                    new PlayerRank { PlayerName = players[i].Name, Score = previousScore, Rank = rankPosition }
                );
        }

        public virtual void AddNextScoreValueToNextPlayerRank(out int rankPosition, out int previousScore, int i)
        {
            previousScore = players[i].Score;
            rankPosition = i + 1;

            playerRanks.Add
                (
                    new PlayerRank { PlayerName = players[i].Name, Rank = rankPosition, Score = players[i].Score }
                );
        }

        public int GetInitialPreviousScore()
        {
            if (gameRankOrder == GameRankOrder.Assending)
            {
                return players.FirstOrDefault().Score;
            }

            return players.FirstOrDefault(x => x.Score == players.Min(y => y.Score)).Score;
        }
    }
}
