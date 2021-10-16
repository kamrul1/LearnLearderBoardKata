using LearnLeaderBoardKata.LeaderBoard.Core.Boards;
using LearnLeaderBoardKata.LeaderBoard.Core.Interfaces;
using LearnLeaderBoardKata.LeaderBoard.Core.Model;
using System;
using System.Collections.Generic;


namespace LearnLeaderBoardKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerList = new List<IScoreSortableItem<Player>>
            {
                new Player{Name="Chrissy", Score=8},
                new Player{Name="Ardalis", Score=10},
                new Player{Name="Doris", Score=7},
                new Player{Name="Bob", Score=8}
            };

            var sut = new TennisBoardCalculator<Player>(playerList, GameRankOrder.Assending);
            var rankedList = sut.GetRanking();

            System.Console.WriteLine($"Rank\tName\t\tScore");

            foreach (var playerRank in rankedList)
            {
                System.Console.WriteLine($"{playerRank.Rank}\t{playerRank.Name}\t\t{playerRank.Score}");
            }
        }
    }
}
