public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        switch (category) {
            case YachtCategory.Ones:
                return dice.Where(n => (n == 1)).Sum();
            case YachtCategory.Twos:
                return dice.Where(n => (n == 2)).Sum();
            case YachtCategory.Threes:
                return dice.Where(n => (n == 3)).Sum();
            case YachtCategory.Fours:
                return dice.Where(n => (n == 4)).Sum();
            case YachtCategory.Fives:
                return dice.Where(n => (n == 5)).Sum();
            case YachtCategory.Sixes:
                return dice.Where(n => (n == 6)).Sum();
            case YachtCategory.FullHouse:
                int[] scores = new int[] {0, 0, 0, 0, 0, 0, 0};
                foreach (int n in dice) scores[n]++;
                int twice = 0;
                int thrice = 0;
                for (int i = 1; i < 7; i++) {
                    if (scores[i] == 2) twice = i;
                    if (scores[i] == 3) thrice = i;
                }
                return (twice == 0 || thrice == 0) ? 0 : dice.Sum();
            case YachtCategory.FourOfAKind:
                if (dice.Where(n => n == dice[0]).ToArray().Length >= 4) return 4 * dice[0];
                if (dice.Where(n => n == dice[1]).ToArray().Length >= 4) return 4 * dice[1];
                return 0;
            case YachtCategory.LittleStraight:
                dice.Sort();
                for (int i = 1; i < 6; i++) if (i != dice[i-1]) return 0;
                return 30;
            case YachtCategory.BigStraight:
                dice.Sort();
                int c = 1;
                for (int i = 1; i < 6; i++) if (i+1 != dice[i-1]) return 0;
                return 30;
            case YachtCategory.Choice:
                return dice.Sum();
            case YachtCategory.Yacht:
                if (dice.Where(n => n == dice[0]).ToArray().Length == dice.Length) return 50;
                else return 0;
            default:
                return 0;
        }
    }
}

