using System;
using System.Text;

namespace RPlay.Core.Tools
{
    public sealed class EncodingTool
    {
        #region Encoding
        public static readonly Encoding ASCII = Encoding.ASCII;
        public static readonly Encoding UCS2 = Encoding.Unicode;
        public static readonly Encoding UTF8 = Encoding.UTF8;
        public static readonly Encoding UTF16 = Encoding.Unicode;
        public static readonly Encoding Unicode = Encoding.Unicode;
        #endregion

        public static byte[] Base64Decode(string base64EncodedData, Encoding encoding = null) {
            return Convert.FromBase64String(base64EncodedData);
        }

        public static string Base64Encode(byte[] bytes, Encoding encoding = null) {
            return Convert.ToBase64String(bytes);
        }
    }
}