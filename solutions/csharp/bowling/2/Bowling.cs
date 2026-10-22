public class BowlingGame
{
    public enum FrameType {
        Strike,
        Open,
        Spare
    };
    private List<Frame> rolls = new List<Frame>();
    private (int? first, int? second) bonusRolls = (null, null);

    private class Frame {
        public FrameType type;
        public int? score1 = null;
        public int? score2 = null;
        
        public Frame(int pins) {
            score1 = pins;
            type = pins == 10 ? FrameType.Strike : FrameType.Open;
        }

        public bool TryClose(int pins) {
            if (score2 != null || type == FrameType.Strike) return false;
            score2 = pins;
            if (score2 + score1 > 10) throw new ArgumentException();
            if (score2 + score1 == 10) type = FrameType.Spare;
            return true;
        }
    }

    private bool StrikeBonus(int pins) {
        if (bonusRolls.first != null) {
            if (bonusRolls.second != null) throw new ArgumentException();
            if (bonusRolls.first != 10 && bonusRolls.first + pins > 10) throw new ArgumentException();
            bonusRolls.second = pins;
        }
        if (bonusRolls.first == null) {
            bonusRolls.first = pins;
        }
        return true;
    }

    private bool SpareBonus(int pins) {
        if (bonusRolls.first != null) throw new ArgumentException();
        bonusRolls.first = pins;
        return true;
    }

    private bool BonusRoll(int pins) {
        if (rolls.Count() == 10) {
            switch (rolls[^1].type) {
                case FrameType.Strike:
                    return StrikeBonus(pins);
                case FrameType.Spare:
                    return SpareBonus(pins);
                case FrameType.Open:
                    if (!rolls[^1].TryClose(pins)) throw new ArgumentException();
                    return true;
                default:
                    throw new ArgumentException();
            }
        } else return false;
    }
    
    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10) throw new ArgumentException();

        if (!BonusRoll(pins)) {
            if (rolls.Count() == 0) rolls.Add(new Frame(pins));
            else if (!rolls[^1].TryClose(pins)) rolls.Add(new Frame(pins));
        }
    }

    public void CanScore() {
        if (rolls.Count() != 10) throw new ArgumentException();
        if (rolls[^1].type == FrameType.Strike && (bonusRolls.first == null || bonusRolls.second == null))  throw new ArgumentException();
        if (rolls[^1].type == FrameType.Spare && bonusRolls.first == null)  throw new ArgumentException();
    }

    private int? ScoreStrike(int i) => i switch {
        9 => bonusRolls.first + bonusRolls.second,
        8 => bonusRolls.first + rolls[i+1].score1,
        _ =>  rolls[i+1].score1 + ( rolls[i+1].type == FrameType.Strike ? rolls[i+2].score1 :  rolls[i+1].score2)
        } + 10;

    private int? ScoreSpare(int i) => rolls[i].score1 + rolls[i].score2 + (i == 9 ? bonusRolls.first : rolls[i+1].score1);

    private int? ScoreOpen(int i) => rolls[i].score1 + rolls[i].score2;

    public int? Score()
    {
        CanScore();
        int? score = 0;
        for (int i = 0; i < 10; i++) {
            Frame frame = rolls[i];
            switch (frame.type) {
                case FrameType.Strike:
                    score += ScoreStrike(i);
                    break;
                case FrameType.Spare:
                    score += ScoreSpare(i);
                    break;
                default:
                    score += ScoreOpen(i);
                    break;
            }
        }
        return score;
    }
}