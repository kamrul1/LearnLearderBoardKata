using LearnLeaderBoardKata.LeaderBoard.Core.Boards;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace LearnLearderBoardKata.LeaderBoard.Test
{
    public class BoardCalculatorTest
    {
        [Fact]
        public void ShouldReturnPlayerNameInOrderOfRank()
        {
            //Arrange
            var playerList = new List<Player>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new TennisBoardCalculator(playerList, GameRankOrder.Assending);

            //Act
            var result = sut.GetRanking();

            //Assert
            Assert.Equal("Ardalis", result.ElementAt(0).PlayerName);
            Assert.Equal("Bob", result.ElementAt(1).PlayerName);
            Assert.Equal("Chrissy", result.ElementAt(2).PlayerName);
            Assert.Equal("Doris", result.ElementAt(3).PlayerName);
        }

        [Fact]
        public void ShouldReturnPlayerRankedByScore()
        {
            //Arrange
            var playerList = new List<Player>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new TennisBoardCalculator(playerList, GameRankOrder.Assending);

            //Act
            var result = sut.GetRanking();

            Assert.Equal(1, result.Where(x => x.Score == 10).FirstOrDefault().Rank);
            Assert.Equal(2, result.Where(x => x.Score == 8).FirstOrDefault().Rank);
            Assert.Equal(4, result.Where(x => x.Score == 7).FirstOrDefault().Rank);

        }
    }


}
