using LearnLeaderBoardKata.LeaderBoard.Core.Boards;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;

namespace LearnLearderBoardKata.LeaderBoard.Test
{
    public class BoardCalculatorTest
    {
        [Fact]
        public void ShouldReturnPlayerNameInOrderOfRank()
        {
            //Arrange
            var playerList = new List<IScoreSortableItem<Player>>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new TennisBoardCalculator<Player>(playerList, GameRankOrder.Assending);

            //Act
            var result = sut.GetRanking();

            //Assert
            Assert.Equal("Ardalis", result.ElementAt(0).Name);
            Assert.Equal("Bob", result.ElementAt(1).Name);
            Assert.Equal("Chrissy", result.ElementAt(2).Name);
            Assert.Equal("Doris", result.ElementAt(3).Name);
        }

        [Fact]
        public void ShouldReturnPlayerRankedByScore()
        {
            //Arrange
            var playerList = new List<IScoreSortableItem<Player>>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new TennisBoardCalculator<Player>(playerList, GameRankOrder.Assending);

            //Act
            var result = sut.GetRanking();

            Assert.Equal(1, result.Where(x => x.Score == 10).FirstOrDefault().Rank);
            Assert.Equal(2, result.Where(x => x.Score == 8).FirstOrDefault().Rank);
            Assert.Equal(4, result.Where(x => x.Score == 7).FirstOrDefault().Rank);

        }
    }


}
