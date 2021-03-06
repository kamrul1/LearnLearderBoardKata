using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class TennisBoardCalculator<T> : BoardCalculator<T> where T:class
    {
        public TennisBoardCalculator(List<IScoreSortableItem<T>> players, GameRankOrder gameRankOrder) : base(players, gameRankOrder)
        {
        }
    }
}
