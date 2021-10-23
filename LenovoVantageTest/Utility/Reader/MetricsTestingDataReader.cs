using LiteDB;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace LenovoVantageTest.Utility.Readers
{
    /*Author: Marcus
     * Desc: http://www.litedb.org/ LiteDB is a convenient document database like MongoDB , while it's like Sqlite , it's small and serverless and single file database without requiring installation.
     * As a document database it supports querying too , unlike Key-Value database , such as LevelDB, developed by google.
     * LiteDB Studio is GUI client for operating on LiteDB.  https://github.com/mbdavid/LiteDB.Studio
     * This database could help us store testing data without designing a united data structure such as what we did in Sqlite.
     */
    class MetricsTestingDataReader
    {
        static MetricsTestingDataReader instance;
        MetricsTestingDataReader() { }

        internal static MetricsTestingDataReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MetricsTestingDataReader();
                }
                return instance;
            }

        }
        public List<JObject> getMetricTestingData(string _name = "", string _caseID = "")
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"VantageDB");
            if (!File.Exists(dbPath)) //local DB file not found, try to read the DB on shared server
            {
                Console.WriteLine("Local DB file(" + dbPath + ") not found! Try to read the DB on shared server.");
                dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TestData\VantageDB");
                if (!File.Exists(dbPath))
                {
                    Console.WriteLine("DB file(" + dbPath + ") on shared server also not found! Can't get any expected Metric!");
                    return null;
                }
                else
                {
                    Console.WriteLine("We use remote shared DB file(" + dbPath + ") as expected metrics data.");
                }
            }
            else
            {
                Console.WriteLine("We use Local DB file(" + dbPath + ") as expected metrics data.");
            }

            using (var db = new LiteDatabase(dbPath))
            {
                var col = db.GetCollection<BsonDocument>("metrics");
                var allData = col.Find(x => x["CaseID"] == _caseID && x["Name"] == _name);
                // allData = col.Find($"$.Name='{_name}' and $.CaseID='{_caseID}'"); // a sample to user Expressions as the and logical operator is not talked.
                //allData = col.Find(Query.And(Query.EQ("Name",_name), Query.EQ("CaseID", _caseID))); //a sample to use query . github.com/mbdavid/LiteDB/wiki/Queries
                List<JObject> result = new List<JObject>();
                foreach (var item in allData)
                {
                    string val = item["value"].ToString();
                    if (result.Equals(""))
                    {
                        continue;
                    }
                    result.Add(JObject.Parse(val));
                }

                return result;
            }
        }
    }
}
