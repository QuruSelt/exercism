public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int _month;
    private int _year;
    
    public Meetup(int month, int year)
    {
        this._month = month;
        this._year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime meetup;
        int day = 1;
        switch (schedule) {
            case Schedule.Second:
                day = 8;
                break;
            case Schedule.Third:
                day = 15;
                break;
            case Schedule.Fourth:
                day = 22;
                break;
            case Schedule.Last:
                day = DateTime.DaysInMonth(_year, _month) - 6;
                break;
            case Schedule.Teenth:
                day = 13;
                break;
        }
        
        while (!DateTime.TryParse($"{dayOfWeek} {_month}/{day}/{_year}", out meetup)) {
            day++;
        }

        return meetup;
    }
}