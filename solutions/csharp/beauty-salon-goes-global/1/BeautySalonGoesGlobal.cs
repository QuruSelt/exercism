using System.Runtime.InteropServices;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static TimeZoneInfo GetTimeZone(Location location) {
        string tzId = location switch {
                Location.NewYork => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Eastern Standard Time" : "America/New_York",
                Location.London => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "GMT Standard Time" : "Europe/London",
                Location.Paris => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "W. Europe Standard Time" : "Europe/Paris",
                _ => throw new ArgumentOutOfRangeException()
        };

        return TimeZoneInfo.FindSystemTimeZoneById(tzId);
    }
    
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToUniversalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) =>
        TimeZoneInfo.ConvertTimeToUtc(
            DateTime.SpecifyKind(
                DateTime.Parse(appointmentDateDescription),
                DateTimeKind.Unspecified),
            GetTimeZone(location)
    );

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel) {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddHours(-1.75);
            default: // Late
                return appointment.AddMinutes(-30);
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) => GetTimeZone(location).IsDaylightSavingTime(dt) != GetTimeZone(location).IsDaylightSavingTime(dt.AddDays(-7));

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        DateTime time;
        CultureInfo culture = location switch {
                Location.NewYork => new CultureInfo("en-US"),
                Location.London => new CultureInfo("en-GB"),
                Location.Paris => new CultureInfo("fr-FR"),
                _ => throw new ArgumentOutOfRangeException()
        };
        DateTime.TryParse(dtStr, culture, out time);
        return time;
    }
}
