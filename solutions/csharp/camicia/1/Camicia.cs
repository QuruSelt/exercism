using System;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }
    
    private static HashSet<(string A, string B)> states = new();
    private static List<string> pile;
    private static int tricks;
    private static int cards;
    private static int play;

    private static bool SaveState(Queue<string>[] players) {
        var saved = new List<string>();
        foreach (var player in players) {
            string p = "";
            foreach (var str in player.ToArray()) {
                if (Char.IsDigit(str[0])) p += "N";
                else p += str;
            }
            saved.Add(p);
        }
        // PrintStates();
        // Console.WriteLine($"  New added state -- A: {saved[0]} | B: {saved[1]}");
        return states.Add((saved[0], saved[1]));
    }

    private static Queue<string> Trick(Queue<string> player) {
        cards += pile.Count;
        tricks++;
        var newPlayer = new Queue<string>([..player.ToArray(), ..pile.ToArray()]);
        pile = new();
        return newPlayer;
    }

    private static Queue<string>[] Pay(Queue<string>[] players, int pay) {
        while (pay > 0) {
            string c = players[play % 2].Dequeue();
            PrintDraw(c, (play%2 == 0 ? 'A' : 'B'));
            pile.Add(c);
            switch (c) {
                case "J":
                    pay = 1;
                    play++;
                    break;
                case "Q":
                    pay = 2;
                    play++;
                    break;
                case "K":
                    pay = 3;
                    play++;
                    break;
                case "A":
                    pay = 4;
                    play++;
                    break;
                default:
                    pay--;
                    break;
            }
            if (pay == 0) players[++play % 2] = Trick(players[play % 2]);
        }
        return players;
    }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    private static void PrintDraw(string c, char p) {
        // Console.WriteLine($"Player {p} drew {c}.");
    }
    
    private static void PrintStates() {
        Console.WriteLine($"States seen after {states.Count} rounds:");
        foreach (var (playerA, playerB) in states) {
            Console.WriteLine($"    A: {playerA} | B: {playerB}");
        }
    }

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        tricks = 0;
        cards = 0;
        int total = playerA.Length + playerB.Length;
        
        states = new();
        pile = new();
        var players = new Queue<string>[] { new(playerA), new(playerB) };
        play = 0;
        int save = 0;

        while (true) {
            if (save++ % 2 == 0) if (!SaveState(players)) return new GameResult(GameStatus.Loop, tricks, cards);
            try {
                string c = players[play++ % 2].Dequeue();
                PrintDraw(c, (play%2 == 0 ? 'B' : 'A'));
                pile.Add(c);
                switch (c) {
                    case "J":
                        players = Pay(players, 1);
                        break;
                    case "Q":
                        players = Pay(players, 2);
                        break;
                    case "K":
                        players = Pay(players, 3);
                        break;
                    case "A":
                        players = Pay(players, 4);
                        break;
                    default:
                        break;
                }
                if (players[0].Count == total || players[1].Count == total)
                    return new GameResult(GameStatus.Finished, tricks, cards);
            } catch (InvalidOperationException e) {
                return new GameResult(GameStatus.Finished, tricks+(pile.Count == 0 ? 0 : 1), cards + pile.Count);
            }
        }

        return new GameResult(GameStatus.Loop, tricks, cards);
    }
}
