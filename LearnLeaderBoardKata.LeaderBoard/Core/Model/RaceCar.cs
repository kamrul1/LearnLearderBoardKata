using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Model
{
    public class RaceCar : IScoreSortableItem<RaceCar>
    {
        public string Name { get; set;}
        public int Score { get; set;}

        public int CompareTo(object other)
        {
            RaceCar otherPlayer = other as RaceCar;

            if (this.Score == otherPlayer.Score)
            {
                //sort alaphabetic order
                return this.Name.CompareTo(otherPlayer.Name);
            }

            return this.Score > otherPlayer.Score ? -1 : 1;
        }
    }
}
