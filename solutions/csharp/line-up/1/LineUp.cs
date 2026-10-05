public static class LineUp
{
    public static string Format(string name, int number)
    {
        string append = "";
        switch (number % 10) {
            case 1:
                append = "st";
                break;
            case 2:
                append = "nd";
                break;
            case 3:
                append = "rd";
                break;
            default:
                append = "th";
                break;
        }

        if (number % 100 == 11 || number % 100 == 12 || number % 100 == 13) append = "th";

        return $"{name}, you are the {number}{append} customer we serve today. Thank you!";
    }
}
