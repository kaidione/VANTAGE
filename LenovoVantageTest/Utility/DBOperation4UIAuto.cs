using LenovoVantageTest.LogHelper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace LenovoVantageTest.Utility
{
    class DBOperation4UIAuto
    {
        const string xPathDb = @"TestLib\TangramDB_UI_SZ.db";
        const string xPathDbSZSrc = @"TestLib\Data\DB_SZ\TangramDB.db";

        public static void UseLocalDB()
        {
            try
            {
                if (File.Exists(xPathDbSZSrc))
                {
                    if (File.Exists(xPathDb))
                    {
                        if (Utility.CryptoGraphy.GetMD5Hash(xPathDb).Equals(Utility.CryptoGraphy.GetMD5Hash(xPathDbSZSrc)))
                        {
                            return;
                        }
                    }
                    File.Copy(xPathDbSZSrc, xPathDb, true);
                }
                else
                {
                    Logger.Instance.WriteLog("!!!!NO database file at" + xPathDbSZSrc, LogType.Error);
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }
        }


        public static List<XPath4Vantage3> QueryXPathFromPage(string page, string tableName = "VAN3_x_UIAuto")
        {
            string dbFile = xPathDb;
            if (!File.Exists(dbFile))
            {
                dbFile = xPathDbSZSrc;
            }


            SQLiteHelper sqlhelper = new SQLiteHelper(dbFile, "");
            List<XPath4Vantage3> xpath = new List<XPath4Vantage3>();

            string sql = string.Format("SELECT * FROM \'{0}\' where Page=\'{1}\'", tableName, page);
            using (SQLiteDataReader reader = sqlhelper.ExecuteDataTable(sql))
            {
                while (reader.Read())
                {
                    XPath4Vantage3 xpathItem = new XPath4Vantage3();
                    xpathItem.IdentityName = reader.GetString(1);
                    xpathItem.XPath = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    //xpathItem.OptionalLocators = (reader.IsDBNull(3) || reader.GetString(3).Trim().Equals("")) ? null : JObject.Parse(reader.GetString(3));
                    //xpathItem.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    xpathItem.Page = page;
                    xpath.Add(xpathItem);
                }
                reader.Close();
            }
            if (xpath.Count == 0)
            {
                Logger.Instance.WriteLog(string.Format("XPath is not found in DB , lang={0},entityName={1},page={2}", page), LogType.Error);
            }

            return xpath;
        }


        public static List<XPath4Vantage3> QueryXPath(string _lang, string _identityName, string _page)
        {
            string dbFile = xPathDb;
            if (!File.Exists(dbFile))
            {
                dbFile = Constants.databaseFile;
            }
            SQLiteHelper sqlhelper = new SQLiteHelper(dbFile, "");
            List<XPath4Vantage3> xpath = new List<XPath4Vantage3>();
            string sqlTemplate = (_page.Equals("") || _page == null) ? "SELECT * FROM VAN3_x_UIAuto where Language=\'{0}\' and IdentityName=\'{1}\' and Page is null" : "SELECT * FROM VAN3_x_UIAuto where Language=\'{0}\' and IdentityName=\'{1}\' and Page=\'{2}\'";
            string sql = string.Format(sqlTemplate, _lang, _identityName, _page);
            using (SQLiteDataReader reader = sqlhelper.ExecuteDataTable(sql))
            {
                while (reader.Read())
                {
                    XPath4Vantage3 xpathItem = new XPath4Vantage3();

                    xpathItem.Language = _lang;
                    xpathItem.IdentityName = _identityName;
                    xpathItem.XPath = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    xpathItem.OptionalLocators = (reader.IsDBNull(3) || reader.GetString(3).Trim().Equals("")) ? null : JObject.Parse(reader.GetString(3));
                    xpathItem.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    xpathItem.Page = _page;
                    xpath.Add(xpathItem);
                }
                reader.Close();
            }
            if (xpath.Count == 0)
            {
                Logger.Instance.WriteLog(string.Format("XPath is not found in DB , lang={0},entityName={1},page={2}", _lang, _identityName, _page), LogType.Error);
            }

            return xpath;
        }
        static JObject OriginalVantageUIContent = getVantageOriginalUIContent(CultureInfo.CurrentUICulture.ThreeLetterWindowsLanguageName);
        static JObject getVantageOriginalUIContent(string _winLanguageName)
        {
            return null;
            string lan = "";
            if (_winLanguageName.ToLower().Equals("enu"))
            {
                lan = "en";
            }
            using (StreamReader sr = new StreamReader(Path.Combine(@"\TestLib\Data\TestData\Vantage3.0\UIContent\{0}.json", lan)))
            {
                return JObject.Parse(sr.ReadToEnd());
            }
        }
    }
}
