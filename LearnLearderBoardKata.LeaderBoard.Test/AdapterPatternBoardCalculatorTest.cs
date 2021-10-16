using LearnLeaderBoardKata.LeaderBoard.Core.Boards;
using LearnLeaderBoardKata.LeaderBoard.Infrastructure.AdapterPattern;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;

namespace LearnLearderBoardKata.LeaderBoard.Test
{
    public class AdapterPatternBoardCalculatorTest
    {
        [Fact]
        public void ShouldRankSuperHeroByPowerScore()
        {
            //Arrange
            var superHeroAdapters = new List<IScoreSortableItem<Adapter>>
            {
                new Adapter(new Adaptee{SuperHeroName="Hulk", PowerScore=1000}),
                new Adapter(new Adaptee{SuperHeroName="Banana man", PowerScore=3000}),
                new Adapter(new Adaptee{SuperHeroName="Swiftman", PowerScore=1})
            };

            //Act
            var sut = new AdapterPatternBoardCalculator<Adapter>(superHeroAdapters, GameRankOrder.Assending);
            var results = sut.GetRanking();

            //Assert
            Assert.Equal("Swiftman", results.LastOrDefault().Name);
        }
    }
}
