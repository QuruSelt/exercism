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
    
    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10) throw new ArgumentException();
        
        if (rolls.Count() == 10) {
            if (rolls[^1].type == FrameType.Spare && bonusRolls.first == null) bonusRolls.first = pins;
            else if (rolls[^1].type == FrameType.Strike) {
                if (bonusRolls.first == null) bonusRolls.first = pins;
                else if (bonusRolls.second == null) {
                    if (bonusRolls.first + pins > 10 && bonusRolls.first != 10) throw new ArgumentException();
                    bonusRolls.second = pins;
                }
                else throw new ArgumentException();
            } else if (rolls[^1].type == FrameType.Open) {
                if (!rolls[^1].TryClose(pins)) throw new ArgumentException();
            }
            else throw new ArgumentException();
        } else if (rolls.Count() == 0) rolls.Add(new Frame(pins));
        else if (!rolls[^1].TryClose(pins)) rolls.Add(new Frame(pins));
    }

    public int? Score()
    {
        if (rolls.Count() != 10) throw new ArgumentException();
        if (rolls[^1].type == FrameType.Strike && (bonusRolls.first == null || bonusRolls.second == null))  throw new ArgumentException();
        if (rolls[^1].type == FrameType.Spare && bonusRolls.first == null)  throw new ArgumentException();
        int score = 0;
        for (int i = 0; i < 10; i++) {
            Frame frame = rolls[i];
            switch (frame.type) {
                case FrameType.Strike:
                    score += 10;
                    if (i < 8) {
                        Frame nextFrame = rolls[i+1];
                        score += nextFrame.score1??0;
                        if (nextFrame.type == FrameType.Strike) {
                            Frame nextNextFrame = rolls[i+2];
                            score += nextNextFrame.score1??0;
                        }
                        else score += nextFrame.score2??0;
                    } else if (i == 8) {
                        Frame nextFrame = rolls[i+1];
                        score += nextFrame.score1??0;
                        if (nextFrame.type == FrameType.Strike) score += bonusRolls.first??0;
                        else score += nextFrame.score2??0;
                    } else {
                        score += bonusRolls.first??0;
                        score += bonusRolls.second??0;
                    }
                    
                    break;
                case FrameType.Spare:
                    score += frame.score1??0;
                    score += frame.score2??0;
                    if (i == 9) {
                        score += bonusRolls.first??0;
                    } else {
                        Frame nextFrame = rolls[i+1];
                        score += nextFrame.score1??0;
                    }
                    break;
                default:
                    score += frame.score1??0;
                    score += frame.score2??0;
                    break;
            }
        }
        return score;
    }
}