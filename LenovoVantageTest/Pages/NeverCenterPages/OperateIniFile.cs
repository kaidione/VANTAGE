using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LenovoVantageTest.Pages
{
    class OperateIniFile
    {

        #region API函数声明

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);
        //需要调用GetPrivateProfileString的重载
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, Byte[] retVal, int size, string filePath);

        public string filePath;
        public OperateIniFile(string path)
        {
            this.filePath = path;
        }

        #endregion
        public List<string> ReadSections()
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, this.filePath);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }

        public List<string> ReadKeys(string SectionName)
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            uint len = GetPrivateProfileStringA(SectionName, null, null, buf, buf.Length, this.filePath);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }
        //public static void SetFilePath(String filepath)
        //{
        //    filePath = filepath;
        //}
        #region 读Ini文件

        //public string ReadIniData(string Section, string Key, string NoText)
        //{
        //    return ReadIniData(Section, Key, NoText);
        //}
        public string ReadIniData(string Section, string Key, string NoText)
        {
            if (File.Exists(this.filePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, this.filePath);
                return temp.ToString();
            }
            else
                return String.Empty;
        }

        #endregion

        #region 写Ini文件

        //public bool WriteIniData(string Section, string Key, string Value)
        //{
        //    return WriteIniData(Section, Key, Value, filePath);
        //}
        public bool WriteIniData(string Section, string Key, string Value)
        {
            if (File.Exists(this.filePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, this.filePath);
                if (OpStation == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        #endregion
    }
}