public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        int eggs = 0;
        while (encodedCount > 0) {
            eggs += encodedCount & 1;
            encodedCount >>= 1;
        }

        return eggs;
    }
}
