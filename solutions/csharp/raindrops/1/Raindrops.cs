public static class Raindrops
{
    public static string Convert(int number)
    {
        string txt = "";

        if (number % 3 == 0) txt += "Pling";
        if (number % 5 == 0) txt += "Plang";
        if (number % 7 == 0) txt += "Plong";

        if (txt == "") txt = number.ToString();
        return txt;
    }
}