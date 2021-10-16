using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using LearnLeaderBoardKata.LeaderBoard.Infrastructure.AdapterPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Boards
{
    public class AdapterPatternBoardCalculator<T> : BoardCalculator<T> where T : class
    {
        public AdapterPatternBoardCalculator(List<IScoreSortableItem<T>> scoreableItem, GameRankOrder gameRankOrder) : base(scoreableItem, gameRankOrder)
        {
        }
    }
}
