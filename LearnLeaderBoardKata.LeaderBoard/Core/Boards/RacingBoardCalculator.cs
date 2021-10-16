using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class RacingBoardCalculator<T> : BoardCalculator<T> where T : RaceCar
    {
        public RacingBoardCalculator(List<IScoreSortableItem<T>> scoreableItem, GameRankOrder gameRankOrder) : base(scoreableItem, gameRankOrder)
        {
        }
    }
}
