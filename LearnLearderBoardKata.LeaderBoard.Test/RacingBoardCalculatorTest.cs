using LearnLeaderBoardKata.LeaderBoard.Core.Boards;
using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnLearderBoardKata.LeaderBoard.Test
{
    public class RacingBoardCalculatorTest
    {
        [Fact]
        public void ShouldRankByRacingCarName()
        {
            //Arrange
            var racingScoreList = new List<IScoreSortableItem<RaceCar>>()
            {
                new RaceCar{Name="Ford", Score=40},
                new RaceCar{Name="Toyota", Score=20}
            };
            
            //Act
            var sut = new RacingBoardCalculator<RaceCar>(racingScoreList, GameRankOrder.Assending);
            var results = sut.GetRanking();

            //Assort
            Assert.Equal("Toyota", results.LastOrDefault().Name);


        }
    }
}
