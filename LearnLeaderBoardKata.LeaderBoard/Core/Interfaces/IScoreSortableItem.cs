using System;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Interfaces
{
    public interface IScoreSortableItem<T>:IComparable where T:class
    {
        string Name { get; set; }
        int Score { get; set; }

    }
}