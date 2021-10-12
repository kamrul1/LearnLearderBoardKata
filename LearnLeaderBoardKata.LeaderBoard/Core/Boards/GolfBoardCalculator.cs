using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class GolfBoardCalculator : BoardCalculator
    {
        public GolfBoardCalculator(List<Player> players, GameRankOrder gameRankOrder) : base(players, gameRankOrder)
        {
        }

    }
}
