using System;
using System.Numerics;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP) {
        Span<byte> rnd = new Span<byte>(new byte[16]);
        new Random().NextBytes(rnd);
        return (new BigInteger(rnd, true) % (primeP - 2)) + 2;
    }

    public static BigInteger QuickExpo(BigInteger a, BigInteger b, BigInteger c) {
        // Returns v = (a ^ b) % c
        BigInteger[] powers = new BigInteger[128];
        powers[0] = a;
        BigInteger tmp = b;;
        int i = 1;
        while (tmp != 0) {
            powers[i] = (powers[i-1] * powers[i-1]) % c; 
            tmp >>= 1;
            i++;
        }
        i = 0;
        BigInteger v = 1;
        while (b != 0) {
            if (b % 2 == 1) v = (v * powers[i]) % c;
            b >>= 1;
            i++;
        }

        return v;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) => QuickExpo(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) => QuickExpo(publicKey, privateKey, primeP);
}