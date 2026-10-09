public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        // Init
        string roman = "";

        // Thousands
        int tmp = value / 1000;
        for (int i = 0; i < tmp; i++) roman += "M";

        // Hundreds
        tmp = (value % 1000) / 100;
        if (tmp == 4) roman += "CD";
        else if (tmp == 9) roman += "CM";
        else {
            if (tmp > 4) roman += "D";
            for (int i = 0; i < tmp % 5; i++) roman += "C";
        }

        // Dozens
        tmp = (value % 100) / 10;
        if (tmp == 4) roman += "XL";
        else if (tmp == 9) roman += "XC";
        else {
            if (tmp > 4) roman += "L";
            for (int i = 0; i < tmp % 5; i++) roman += "X";
        }

        // Units
        tmp = (value % 10) / 1;
        if (tmp == 4) roman += "IV";
        else if (tmp == 9) roman += "IX";
        else {
            if (tmp > 4) roman += "V";
            for (int i = 0; i < tmp % 5; i++) roman += "I";
        }
        
        return roman;
    }
}