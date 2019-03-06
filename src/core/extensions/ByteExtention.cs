using System.Text;

namespace RPlay.Core.Extensions
{
    public static class ByteExtension
    {
        public static string FromBytesToString(this byte[] input, Encoding encoding = null)
        {
            return (encoding ?? Encoding.UTF8).GetString(input);
        }

        public static byte[] Concat(this byte[] src, byte[] input)
        {
            byte[] all = new byte[src.Length + input.Length];

            System.Buffer.BlockCopy(src, 0, all, 0, src.Length);
            System.Buffer.BlockCopy(input, 0, all, src.Length, input.Length);
            return (src = all);
        }
    }
}