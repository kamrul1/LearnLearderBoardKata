# Learder Board Kata

This is my go at completing this Kata written by [ardalis/kata-catalog](https://github.com/ardalis/kata-catalog)

Excerise Details - https://github.com/ardalis/kata-catalog/blob/main/katas/Leaderboard.md

## Initial Thoughts

My initial thought was to write a library.  This way it could be later
exposed by Web API.  I would represent the results in Json format.  The 
UI application be it console, web, mobile etc. could decide how to present it.


## Setup

Trying to use ardalis recommendation of Pain Driven Development (PDD), re-factor
it using Unit Test before applying SOLID or other design patterns.

To keep simple I'll start by using folders over projects.

## Coding plan

- Accept player class into list and implement Icomparable\<T> generics by the CompareTo 
function.
```
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
```
- Create PlayerRank to hold position of player in game:
```
public class PlayerRank
{
    public string PlayerName { get; set; }
    public int Rank { get; set; }
    public int Score { get; set; }
}
```
Place player in order of rank based on their score:
```
public IEnumerable<PlayerRank> GetRanking()
{
            
    players.Sort();


    int rankPosition = 1;
    int previousScore = players.FirstOrDefault().Score;
    List<PlayerRank> playerRanks = new();

    for (int i = 0; i < players.Count; i++)
    {
        if (players[i].Score == previousScore)
        {
            playerRanks.Add
                (
                    new PlayerRank { PlayerName = players[i].Name, Score = previousScore, Rank = rankPosition }
                );
            continue;
        }

        previousScore = players[i].Score;
        rankPosition=i+1;

        playerRanks.Add
            (
                new PlayerRank { PlayerName = players[i].Name, Rank = rankPosition, Score = players[i].Score }
            );
    }

    return playerRanks;

}
```

Refactor the BoardCalculator into a abstract class and implement interface:
```
public interface IBoardCalculator
{
    void AddNextScoreValueToNextPlayerRank(out int rankPosition, out int previousScore, int i);
    void AddScoreValueToPlayerRank(int rankPosition, int previousScore, int i);
    void CreateRankByAssendingScore(ref int rankPosition, ref int previousScore);
    void CreateRankByDescendingScore(ref int rankPosition, ref int previousScore);
    int GetInitialPreviousScore();
    IEnumerable<PlayerRank> GetRanking();
}
```

## Design Review Questions

***How do you represent players, scores, and player-score combinations in your design?***

Players are a list, that must implement icomparable so that it can be sorted.  The
sorted order is mapped into ranks based on ranking rules i.e. same scores do not change
rank.

***How do you represent the result of the rank calculation?***

Map the Player class to RankedPlayer class, which adds a Rank property and those field 
that need to be reported in the output i.e. playername-score-rank

***How easily would your design work in different user interfaces (console, web, mobile, etc.)?***

Input put was a concern for mobile.  Once list contracted the source didn't matter where
the output was presented.

***How difficult was it to configure your algorithm to support lowest-to-highest scoring? How much duplicate code, if any, is there in your final solution?***

The concern here is the repeating code i.e. DRY.  Assending and Assending rely on a for loop 
index which are different and I could not refactor it into something that did not reuse code.

It helped that I organised everying into the Domain Driven Development pattern.  I used 
TDD, unit test and my choosen plugin [Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage)
showed 100% coverage for happy paths.

Guard clauses could potentially be added to make sure data is valid.

## Flexibility


***How would you modify your solution to work for any given data type? 
Instead of players and games what if you're calculating book sales rankings?*** 

The key would be mapping, the only fields it requires are name and score.  Potentially Id 
field could be used so that each item is given an unique value.
I could refactor Player class to ScoredItem class with sorting and it would be more abstract.

***Can you design your solution such that its operations are configurable, 
or leverage a design pattern like Adapter to provide a way for it to work 
with arbitrary existing data structures?***

```
Adapter is recognizable by a constructor which takes an instance 
of a different abstract/interface type. When the adapter receives a call to 
any of its methods, it translates parameters to the appropriate format and 
then directs the call to one or several methods of the wrapped object.
````
Adaptor pattern looks like a good fit as Player class could potentially have it's 
interface implement through via the class where Player is being adopted.


