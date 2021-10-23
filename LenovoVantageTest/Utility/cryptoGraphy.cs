using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace LenovoVantageTest.Utility
{
    class CryptoGraphy
    {
        public static string GetCrc(string fileName)
        {
            if (fileName == null)
            {
                throw new NullReferenceException("The file name is null");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Can not find the file to compute CRC.");
            }
            FileStream fs;
            string sha1Result = null;
            byte[] sha1;
            using (SHA1CryptoServiceProvider sha1Service = new SHA1CryptoServiceProvider())
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                sha1 = sha1Service.ComputeHash(fs);
                fs.Close();
                sha1Result = BitConverter.ToString(sha1);
                sha1Result = sha1Result.Replace("-", "");
                return sha1Result;
            }
        }

        public static string GetSHA256Hash(string fileName) //@ken_7394
        {
            if (fileName == null)
            {
                throw new NullReferenceException("The file name is null");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Can not find the file to compute SHA256 Hash.");
            }

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read); //@gordenye_2015
            SHA256 shaM = new SHA256Managed();
            byte[] result = shaM.ComputeHash(fs);
            fs.Close();
            return BitConverter.ToString(result).Replace("-", "");
        }
        public static string GetMD5Hash(string _fileName)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream));
                }
            }
        }

        public static String HashData(String input) // SN Input
        {
            String output = String.Empty;
            String salt = "f977c2863591a9691a18000af370c519";

            if (!String.IsNullOrEmpty(input))
            {
                using (SHA256 hash = SHA256.Create())
                {
                    String valueToHash = salt + input;

                    byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(valueToHash));

                    // Create a new Stringbuilder to collect the bytes
                    // and create a string.
                    StringBuilder sBuilder = new StringBuilder();

                    // Loop through each byte of the hashed data
                    // and format each one as a hexadecimal string.
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    output = sBuilder.ToString();
                }
            }
            return output;
        }
    }
}
