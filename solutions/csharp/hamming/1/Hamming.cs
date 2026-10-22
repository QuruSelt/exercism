public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException();
        int hamming = 0;
        for (int i = 0; i < firstStrand.Length; i++) if (firstStrand[i] != secondStrand[i]) hamming++;
        return hamming;
    }
}