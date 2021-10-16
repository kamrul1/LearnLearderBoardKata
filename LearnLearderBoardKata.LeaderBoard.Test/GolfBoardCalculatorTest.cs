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
    public class GolfBoardCalculatorTest
    {
        [Fact]
        public void ShouldReturnPlayerNameInOrderOfRankByReverseScoreOrder()
        {
            //Arrange
            var playerList = new List<IScoreSortableItem<Player>>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new GolfBoardCalculator<Player>(playerList,GameRankOrder.Desending);

            //Act
            var result = sut.GetRanking();

            //Assert
            Assert.Equal("Ardalis", result.ElementAt(3).Name);
            Assert.Equal("Bob", result.ElementAt(2).Name);
            Assert.Equal("Chrissy", result.ElementAt(1).Name);
            Assert.Equal("Doris", result.ElementAt(0).Name);
        }
    }
}
