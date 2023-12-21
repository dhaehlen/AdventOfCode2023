using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Metadata;

public class CountColorSet
{
    public string color;
    public int count;

    public CountColorSet(int count, string color)
    {
        this.color = color;
        this.count = count;
    }
}

public class GameRound
{
    public List<CountColorSet> countColorSets;
    public GameRound(string gameRound)
    {
        countColorSets = new List<CountColorSet>();
        foreach(string set in gameRound.Split(','))
        {
            string[] gameSetSplit = set.Trim().Split(' ');
            int setCount = Int32.Parse(gameSetSplit[0]);
            string color = gameSetSplit[1].Trim().ToLower(); 
            countColorSets.Add(new CountColorSet(setCount, color));
        }
    }
    public List<CountColorSet> GetAllCountColorSets(){
        return countColorSets;
    }
}

public class Game
{
    public int gameNo;
    public List<GameRound> gameRounds = new List<GameRound>();
    public Game(int gameNo, string[] gameRoundArray)
    {
        this.gameNo = gameNo;
        foreach(string round in gameRoundArray)
        {
            gameRounds.Add(new GameRound(round));
        }
    }

    public List<CountColorSet> GetAllCountColorSetsOfGame()
    {
        List<CountColorSet> result = new List<CountColorSet>();
        foreach(GameRound round in gameRounds)
        {
            result.AddRange(round.GetAllCountColorSets());
        }
        return result;
    }
}


public static class Day2
{

    public const int noRedCubes = 12;
    public const int noGreenCubes = 13;
    public const int noBlueCubes = 14;
  
    
    public static void Run()
    {
        List<Game> allGames = new List<Game>();
        allGames = ParseData();
        int gameSum = 0;

        foreach (Game game in allGames)
        {
            Console.WriteLine("For Game " + game.gameNo + "-------------------");
            Boolean gamePossible = true;
            foreach(CountColorSet set in game.GetAllCountColorSetsOfGame())
            {
                Console.WriteLine(set.color + " " + set.count);
                switch(set.color)
                {
                    case "red":
                        if(set.count > noRedCubes){ gamePossible = false;};
                        break;
                    case "green":
                        if(set.count > noGreenCubes){ gamePossible = false;};
                        break;
                    case "blue":
                        if(set.count > noBlueCubes){ gamePossible = false;};
                        break;
                }
            }

            if(gamePossible)
            { 
                gameSum = gameSum + game.gameNo;
                Console.WriteLine("Game " + game.gameNo + " is possible.");
            }
            else
            {
                Console.WriteLine("Game " + game.gameNo + " is not possible.");
            }
        }

        Console.WriteLine("Sum of the game numbers that are possible is: " + gameSum);
        
    }

    public static List<Game> ParseData()
    {
        string filePath = "C:\\Users\\dhaeh\\Documents\\AdventOfCode2023\\AOCinputday2.txt";
        List<Game> allGames = new List<Game>();

        foreach(string line in File.ReadLines(filePath))
        {
             string[] lineSplit = SplitLine(line);
             string gameNoString = lineSplit[0].Split(' ')[1];
             gameNoString = gameNoString.Remove(gameNoString.Length);

             int gameNoInt = Int32.Parse(gameNoString);

             allGames.Add(new Game(gameNoInt, lineSplit.Skip(1).Take(lineSplit.Length - 1).ToArray()));
        }

        return allGames;
    }

    public static string[] SplitLine(string line)
    {
        return line.Split(new char[]{ ':', ';'});
    }

    public static void testSplitLine()
    {
        string testLine = "Game 1: 7 blue, 9 red, 1 green; 8 green; 10 green, 5 blue, 3 red; 11 blue, 5 red, 1 green";
        foreach (string item in SplitLine(testLine))
        {
            Debug.Print(item);
        }
    }   
}
