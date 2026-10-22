public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);
    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    private static (double x, double y) _pos;
    private static double _angle = 0;

    private static void UpdateAngle(double addedAngle) {
        _angle += addedAngle;
        if (_angle > 180) _angle -= 360;
        if (_angle < -180) _angle += 360;
    }

    private static void UpdatePos(double X, double Y) {
        _pos.x = X;
        _pos.y = Y;
    }

    private static bool IsInCorrectQuadrant(PrismInfo prism) {
        switch (_angle) {
            case (< -90):
                return prism.X <= _pos.x && prism.Y <= _pos.y;
            case (< 0):
                return prism.X >= _pos.x && prism.Y <= _pos.y;
            case (< 90):
                return prism.X >= _pos.x && prism.Y >= _pos.y;
            default: // >= 90
                return prism.X <= _pos.x && prism.Y >= _pos.y;
        }
    }

    private static double ComputeAngle(PrismInfo prism, double d) {
        switch (_angle) {
            case (< -90):
                return -180 + Double.Acos((_pos.x - prism.X) / d) * 180 / Math.PI;
            case (< 0):
                return -Double.Acos((prism.X - _pos.x) / d) * 180 / Math.PI;
            case (< 90):
                return Double.Acos((prism.X - _pos.x) / d) * 180 / Math.PI;
            default: // >= 90
                return 180 - Double.Acos((_pos.x - prism.X) / d) * 180 / Math.PI;
        }
    }

    private static void PrintCurrentState() => Console.WriteLine($"Current position: ({_pos.x}, {_pos.y}). Angle: {_angle}°.");
    private static void PrintPrismState(PrismInfo p) {
        Console.WriteLine($"Prism #{p.Id}:");
        Console.WriteLine($"        - position: ({p.X}, {p.Y})");
        Console.WriteLine($"        - Angle: {p.Angle}°");
    }
    private static double Distance(double X, double Y) => Double.Sqrt((X - _pos.x) * (X - _pos.x) + (Y - _pos.y) * (Y - _pos.y));
    
    private static PrismInfo[] FirstHit(IEnumerable<PrismInfo> prisms) {
        // PrintCurrentState();
        double minDist = Double.MaxValue;
        PrismInfo closest = new(0, 0, 0, 0);

        foreach (PrismInfo prism in prisms) {
            // PrintPrismState(prism);
            
            if (!IsInCorrectQuadrant(prism)) continue;
            // Console.WriteLine($"Prism #{prism.Id} is in the correct Quadrant.");
            
            double d = Distance(prism.X, prism.Y);
            // Console.WriteLine($"Prism #{prism.Id} is at a distance {d} from the current point.");
            if (d >= minDist) continue;
            
            double potAngle = ComputeAngle(prism, d);
            // Console.WriteLine($"Calculated angle is {potAngle}°.");
            // Console.WriteLine($"{_angle} == {potAngle} is {Math.Abs(_angle - potAngle) < 0.01}");

            if (Math.Abs(_angle - potAngle) < 0.01) {
                minDist = d;
                closest = prism;
            }
        }

        if (minDist == Double.MaxValue) return new PrismInfo[0];
        return new PrismInfo[] { closest };
    }
    
    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        List<int> sequence = new List<int>();     
        UpdatePos(laser.X, laser.Y);
        _angle = laser.Angle;

        PrismInfo[] target = FirstHit(prisms);
        while (target.Length != 0) {
            sequence.Add(target[0].Id); 
            UpdatePos(target[0].X, target[0].Y);
            UpdateAngle(target[0].Angle);
            target = FirstHit(prisms);
        }

        return sequence.ToArray();
    }
}
