using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class TennisBoardCalculator : BoardCalculator
    {
        public TennisBoardCalculator(List<Player> players, GameRankOrder gameRankOrder) : base(players, gameRankOrder)
        {
        }
    }
}
