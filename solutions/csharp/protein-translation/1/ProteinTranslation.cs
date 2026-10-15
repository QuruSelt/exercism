public static class ProteinTranslation
{
    public static string AminoAcid(string codon) {
        switch (codon) {
            case "AUG":
                return "Methionine";
            case "UUU":
                return "Phenylalanine";
            case "UUC":
                return "Phenylalanine";
            case "UUA":
                return "Leucine";
            case "UUG":
                return "Leucine";
            case "UCU":
                return "Serine";
            case "UCC":
                return "Serine";
            case "UCA":
                return "Serine";
            case "UCG":
                return "Serine";
            case "UAU":
                return "Tyrosine";
            case "UAC":
                return "Tyrosine";
            case "UGU":
                return "Cysteine";
            case "UGC":
                return "Cysteine";
            case "UGG":
                return "Tryptophan";
        }
        return "";
    }
        
    public static string[] Proteins(string strand)
    {
        List<string> protein = new List<string>();
        if (strand.Length < 3) return protein.ToArray();
        int i = 0;
        string codon = strand.Substring(i, 3);
        while (codon != "UAA" && codon != "UAG" & codon != "UGA") {
            protein.Add(AminoAcid(codon));
            i += 3;
            try {codon = strand.Substring(i, 3);} catch {break;}
        }

        return protein.ToArray();
    }
}