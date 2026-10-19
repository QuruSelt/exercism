public static class TelemetryBuffer
{
    private static byte[] FillBuffer(ushort v) {
        byte[] buffer = new byte[9];
        byte size = 2;
        buffer[0] = 0x02;
        for (byte i = 1; i <= size; i++) {
            buffer[i] = (byte) (v & 0xff);
            v >>= 8;
        }
        return buffer;
    }
    
    private static byte[] FillBuffer(short v) {
        byte[] buffer = new byte[9];
        byte size = 2;
        buffer[0] = (byte) (0xff - 0x01);
        for (byte i = 1; i <= size; i++) {
            buffer[i] = (byte) (v & 0xff);
            v >>= 8;
        }
        return buffer;
    }
    
    private static byte[] FillBuffer(uint v) {
        byte[] buffer = new byte[9];
        byte size = 4;
        buffer[0] = 0x04;
        for (byte i = 1; i <= size; i++) {
            buffer[i] = (byte) (v & 0xff);
            v >>= 8;
        }
        return buffer;
    }
    
    private static byte[] FillBuffer(int v) {
        byte[] buffer = new byte[9];
        byte size = 4;
        buffer[0] = (byte) (0xff - 0x03);
        for (byte i = 1; i <= size; i++) {
            buffer[i] = (byte) (v & 0xff);
            v >>= 8;
        }
        return buffer;
    }
    
    private static byte[] FillBuffer(long v) {
        byte[] buffer = new byte[9];
        byte size = 8;
        buffer[0] = (byte) (0xff - 0x07);
        for (byte i = 1; i <= size; i++) {
            buffer[i] = (byte) (v & 0xff);
            v >>= 8;
        }
        return buffer;
    }
    
    public static byte[] ToBuffer(long reading)
    {
        switch (reading) {
            case (>= 4_294_967_296):
                return FillBuffer((long) reading);
            case (>= 2_147_483_648):
                return FillBuffer((uint) reading);
            case (>= 65_536):
                return FillBuffer((int) reading);
            case (>= 0):
                return FillBuffer((ushort) reading);
            case (>= -32_768):
                return FillBuffer((short) reading);
            case (>= -2_147_483_648):
                return FillBuffer((int) reading);
            default:
                return FillBuffer((long) reading);
        }
    }

    public static long FromBuffer(byte[] buffer)
    {
        long res = 0;
        byte size = (byte) (buffer[0] < 0xf0 ? buffer[0] : 0xff - buffer[0] + 0x01);

        if (size > 0x08) return res;

        for (byte i = size; i > 0; i--) {
            res <<= 8;
            res += buffer[i];
        }

        switch (res) {
            case (>= 4_294_967_296):
                return res;
            case (>= 65_536):
                if (buffer[0] < 0xf0)
                    return (uint) res;
                else
                    return (int) res;
            case (>= 0):
                if (buffer[0] < 0xf0)
                    return (ushort)res;
                else
                    return (short) res;
            case (>= -2_147_483_648):
                return (int) res;
            default:
                return res;
        }
    }
}
