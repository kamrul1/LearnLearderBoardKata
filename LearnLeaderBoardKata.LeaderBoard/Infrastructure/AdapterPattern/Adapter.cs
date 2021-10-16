using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLeaderBoardKata.LeaderBoard.Infrastructure.AdapterPattern
{
    public class Adapter : IScoreSortableItem<Adapter>
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        public string Name { get => adaptee.SuperHeroName; set => adaptee.SuperHeroName=value; }
        public int Score { get => adaptee.PowerScore; set => adaptee.PowerScore=value; }

        public int CompareTo(object obj)
        {
            Adapter other = obj as Adapter;

            if (this.Score == other.Score)
            {
                //sort alaphabetic order
                return this.Name.CompareTo(other.Name);
            }

            return this.Score > other.Score ? -1 : 1;
        }
    }
}
