using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class GolfBoardCalculator<T> : BoardCalculator<T> where T:class
    {
        public GolfBoardCalculator(List<IScoreSortableItem<T>> players, GameRankOrder gameRankOrder) : base(players, gameRankOrder)
        {
        }

    }
}
