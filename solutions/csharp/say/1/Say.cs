public static class Say
{
    private static string[] _numberGroups = new string[] {
        "",
        " thousand ",
        " million ",
        " billion "
    };

    private static string DigitToString(long digit) {
        switch (digit) {
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            default:    // 0
                return "";
        }
    }

    private static string DozenToString(long number) {
        switch (number / 10) {
            case 1:
                switch (number % 10) {
                    case 1:
                        return "eleven";
                    case 2:
                        return "twelve";
                    case 3:
                        return "thirteen";
                    case 4:
                        return "fourteen";
                    case 5:
                        return "fiften";
                    case 6:
                        return "sixteen";
                    case 7:
                        return "seventeen";
                    case 8:
                        return "eighteen";
                    case 9:
                        return "nineteen";
                    default:    // 10
                        return "ten";
                }
            case 2:
                return $"twenty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 3:
                return $"thirty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 4:
                return $"forty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 5:
                return $"fifty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 6:
                return $"sixty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 7:
                return $"seventy{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 8:
                return $"eighty{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            case 9:
                return $"ninety{(number % 10 != 0 ? "-" : "")}{DigitToString(number % 10)}";
            default:    // 0
                return $"{DigitToString(number % 10)}";
        }
    }

    private static string HundredToString(long number) => $"{DigitToString(number / 100)}{(number < 100 ? "" : " hundred")}";

    private static string SectionToString(long number) => $"{HundredToString(number)}{(number % 100 != 0 && number > 100 ? " " : "")}{DozenToString(number % 100)}";
    
    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999_999_999_999) throw new ArgumentOutOfRangeException();
        
        string spell = " ";
        if (number == 0) spell = "zero ";

        int gp = 0;
        while (number > 0) {
            spell = $"{SectionToString(number % 1_000)}{(number % 1_000 != 0 ? _numberGroups[gp] : "")}{spell}";
            number /= 1_000;
            gp++;
        }

        return spell.TrimEnd();
    }
}