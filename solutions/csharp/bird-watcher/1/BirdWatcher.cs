class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[6];

    public void IncrementTodaysCount() => birdsPerDay[6] += 1;

    public bool HasDayWithoutBirds() => (from birds in birdsPerDay where birds == 0 select true).Any();

    public int CountForFirstDays(int numberOfDays) => (from birds in birdsPerDay select birds).Take(numberOfDays).Sum();

    public int BusyDays() => (from birds in birdsPerDay where birds >= 5 select true).Count();
}
