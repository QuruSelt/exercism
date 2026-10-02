static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        switch (speed) {
            case 0:
                return 0.0;
            case (<5):
                return 1.0;
            case (<9):
                return 0.9;
            case 9:
                return 0.8;
            case 10:
                return 0.77;
        }
        throw new ArgumentException("Please input a speed btween 0 and 10 included");
    }
    
    public static double ProductionRatePerHour(int speed) => 221.0 * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / 60);
}
