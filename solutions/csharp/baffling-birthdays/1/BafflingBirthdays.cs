public static class BafflingBirthdays
{
    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        List<DateOnly> birthDates = new List<DateOnly>();

        while (birthDates.Count != numberOfBirthdays) {
            int year = new Random().Next(1950, 2026);
            while (DateTime.IsLeapYear(year)) year = new Random().Next(1950, 2026);
            birthDates.Add(new DateOnly(year, 1, 1).AddDays(new Random().Next(1, 366)));
        }
        
        return birthDates.ToArray();
    }

    public static bool SharedBirthday(DateOnly[] birthdays)
    {
        for (int i = 0; i < birthdays.Length - 1; i++) {
            for (int k = i+1; k < birthdays.Length; k++) {
                if (birthdays[i].Day == birthdays[k].Day && birthdays[i].Month == birthdays[k].Month)
                    return true;
            }
        }

        return false;
    }
    
    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
    {
        double res = 0.0;
        int rep = 1000;
        for (int i = 0; i < rep; i++) {
            if (SharedBirthday(RandomBirthdates(numberOfBirthdays))) res += 100.0;
            Console.WriteLine($"REP {i}: {res}");
        }
        return res / rep;
    }
}
