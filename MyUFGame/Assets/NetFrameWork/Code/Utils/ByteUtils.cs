public class ByteUtils
{
    public static byte[] CupByte(byte[] b,int start,int length)
    {
        byte[] temp = new byte[length];
        int k = 0;
        for (int i = start; i < start + length; i++)
        {
            temp[k] = b[i];
            k++;
        }

        return temp;
    }
}