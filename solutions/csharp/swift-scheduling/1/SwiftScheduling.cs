public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description)
    {
        switch (description) {
            case "NOW":
                return meetingStart.AddHours(2);
            case "ASAP":
                return meetingStart.Date.AddHours(meetingStart.Hour < 13 ? 17 : 37);
            case "EOW":
                return meetingStart.Date
                    .AddDays(((int)meetingStart.DayOfWeek < 4 ? 5 : 7) - (int)meetingStart.DayOfWeek)
                    .AddHours((int)meetingStart.DayOfWeek < 4 ? 17 : 20);
            default:
                if (description[0] == 'Q') {
                    int q = description[1] - '0';
                    DateTime workday = new DateTime(meetingStart.Year + (meetingStart.Month <= 3*q ? 0 : 1), 3*q, 1, 8, 0, 0)
                        .AddMonths(1).AddDays(-1);
                    while (workday.DayOfWeek == DayOfWeek.Sunday || workday.DayOfWeek == DayOfWeek.Saturday)
                        workday = workday.AddDays(-1);
                    return workday;
                } else {
                    int m = description[0] - '0';
                    if (m == 1 && description[1] != 'M') m = m*10 + description[1] - '0';
                    DateTime workday = new DateTime(meetingStart.Year + (meetingStart.Month < m ? 0 : 1), m, 1, 8, 0, 0);
                    while (workday.DayOfWeek == DayOfWeek.Sunday || workday.DayOfWeek == DayOfWeek.Saturday)
                        workday = workday.AddDays(1);
                    return workday;
                }
        };
    }
}
