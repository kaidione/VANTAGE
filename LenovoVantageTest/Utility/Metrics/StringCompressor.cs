using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace LenovoVantageTest.Metrics
{
    public sealed class StringCompressor
    {
        /// <summary>
        /// Compress a stringd
        /// </summary>
        /// <param name="text">String to compress</param>
        /// <returns>Array of bytes representing compressed string</returns>

        public static byte[] Compress(string text)
        {
            if (null == text)
            {
                throw new ArgumentNullException("text");
            }

            byte[] result = null;

            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, false))
                {
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    gzip.Write(data, 0, data.Length);
                    gzip.Flush();
                    gzip.Close();

                    result = memory.ToArray();
                }
            }

            return result;
        }

        /// <summary>
        /// Decompress an array of bytes representing a compressed string
        /// </summary>
        /// <param name="data">Array of bytes representing compressed string</param>
        /// <returns>Decompressed string</returns>

        public static string Decompress(byte[] data)
        {
            if (null == data)
            {
                throw new ArgumentNullException("data");
            }

            string result = null;

            using (MemoryStream memory = new MemoryStream(data, false))
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Decompress, false))
                {
                    using (StreamReader reader = new StreamReader(gzip, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                    }

                    gzip.Close();
                }
            }

            return result;
        }
    }
}
