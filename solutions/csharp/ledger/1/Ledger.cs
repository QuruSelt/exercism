using System.Globalization;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, decimal chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public DateTime Date { get; }
    public string Desc { get; }
    public decimal Chg { get; }
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int chng)
    {
        return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
    }

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        if ((cur != "USD" && cur != "EUR") || (loc != "nl-NL" && loc != "en-US"))
            throw new ArgumentException("Invalid currency");
        
        string curSymb = cur == "USD" ? "$" : "€";
        int curNeg = loc == "en-US" ? 0 : 12;
        string datPat = loc == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";;

        var culture = new CultureInfo(loc, false);
        culture.NumberFormat.CurrencySymbol = curSymb!;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat!;
        return culture;
    }

    private static string PrintHead(string loc) => loc switch {
            "en-US" => "Date       | Description               | Change       ",
            "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
            _ => throw new ArgumentException("Invalid locale"),
    };

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Description(string desc) => desc.Length > 25 ? desc.Substring(0, 22) + "..." : desc;

    private static string Change(IFormatProvider culture, decimal cgh) {
        string label = cgh.ToString("C", culture);
        if (cgh >= 0.0m || label.Contains("-")) label += " ";
        return label;
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        var formatted = "";
        var date = Date(culture, entry.Date);
        var description = Description(entry.Desc);
        var change = Change(culture, entry.Chg);

        formatted += date;
        formatted += " | ";
        formatted += string.Format("{0,-25}", description);
        formatted += " | ";
        formatted += string.Format("{0,13}", change);

        return formatted;
    }


    private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
    {
        var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
        var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

        var result = new List<LedgerEntry>();
        result.AddRange(neg);
        result.AddRange(post);

        return result;
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var formatted = PrintHead(locale);
        var culture = CreateCulture(currency, locale);

        if (entries.Length > 0)
        {
            var entriesForOutput = sort(entries);
            foreach (var e in entriesForOutput) formatted += "\n" + PrintEntry(culture, e);
        }

        return formatted;
    }
}
