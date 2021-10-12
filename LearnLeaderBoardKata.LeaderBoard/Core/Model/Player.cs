using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Core.Model
{
    public class Player:IComparable<Player>
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public int CompareTo(Player other)
        {
            if (this.Score == other.Score)
            {
                //sort alaphabetic order
                return this.Name.CompareTo(other.Name);
            }

            return this.Score > other.Score ? -1 : 1;
        }
    }
}
