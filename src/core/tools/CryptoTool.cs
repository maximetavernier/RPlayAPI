using System;
using System.Security.Cryptography;
using RPlay.Core.Extensions;

namespace RPlay.Core.Tools
{
    public sealed class CryptoTool
    {
        #region MD5
        /// <summary>
        /// Compute MD5 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A MD5 encrypted string</returns>
        public static string EncryptMD5(string input)
        {
            try
            {
                var crypt = new MD5CryptoServiceProvider();

                // byte[]
                var hashBytes = crypt.ComputeHash(EncodingTool.UTF8.GetBytes(input), 0, EncodingTool.UTF8.GetByteCount(input));
                return hashBytes.FromBytesToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Compute MD5 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A MD5 encrypted string</returns>
        public static byte[] EncryptMD5(byte[] input)
        {
            try
            {
                var crypt = new MD5CryptoServiceProvider();
                // byte[]
                var hashBytes = crypt.ComputeHash(input, 0, input.Length);

                return hashBytes;
            }
            catch
            {
                return default(byte[]);
            }
        }
        #endregion

        #region SHA
        /// <summary>
        /// Compute SHA1 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A SHA1 encrypted string</returns>
        public static string EncryptSha1(string input)
        {
            try
            {
                var crypt = new SHA1Managed();

                // byte[]
                var hashBytes = crypt.ComputeHash(EncodingTool.UTF8.GetBytes(input), 0, EncodingTool.UTF8.GetByteCount(input));
                return hashBytes.FromBytesToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Compute SHA1 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A SHA1 encrypted string</returns>
        public static byte[] EncryptSha1(byte[] input)
        {
            try
            {
                var crypt = new SHA1Managed();
                // byte[]
                var hashBytes = crypt.ComputeHash(input, 0, input.Length);

                return hashBytes;
            }
            catch
            {
                return default(byte[]);
            }
        }

        /// <summary>
        /// Compute SHA256 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A SHA256 encrypted string</returns>
        public static string EncryptSha256(string input)
        {
            try
            {
                var crypt = new SHA256Managed();
                // byte[]
                var hashBytes = crypt.ComputeHash(EncodingTool.UTF8.GetBytes(input), 0, EncodingTool.UTF8.GetByteCount(input));

                return hashBytes.FromBytesToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Compute SHA256 encryption from an input string
        /// </summary>
        /// <param name="input">Source input string</param>
        /// <returns>A SHA256 encrypted string</returns>
        public static byte[] EncryptSha256(byte[] input)
        {
            try
            {
                var crypt = new SHA256Managed();
                // byte[]
                var hashBytes = crypt.ComputeHash(input, 0, input.Length);

                return hashBytes;
            }
            catch
            {
                return default(byte[]);
            }
        }
        #endregion
    }
}