using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
namespace LenovoVantageTest.Utility
{
    class SQLiteHelper
    {
        static string DBFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TangramDB.db");
        private SQLiteConnection connection = null;

        //----创建连接串并连接数据库----
        //调用示例：
        //SQLiteHelper helper = new SQLiteHelper("D:\\mysqlite.db","123456");     //连接到D盘下的mysqlite.db数据库,连接密码为123456
        public SQLiteHelper(string path, string password)
        {
            string conn_str = "data source=" + path + ";password=" + password;
            Connection = new SQLiteConnection(conn_str);
            Connection.Open();
        }

        //----修改数据库密码----
        //调用示例：
        //bool ch = helper.ChangePassword("654321");                            //将密码修改为：654321
        public bool ChangePassword(string newPassword)
        {
            bool ret = false;
            try
            {
                //Connection.ChangePassword(newPassword);
                ret = true;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(@"ChangeDBPwd occurs exceptions：" + ex.Message);
            }
            return ret;
        }

        //----关闭数据库连接----
        public void CloseConnection()
        {
            Connection.Close();
            Connection = null;
        }
        static SQLiteHelper sqlliteHelper;

        public SQLiteConnection Connection { get { return connection; } set { connection = value; } }

        public static SQLiteHelper getSingleton()
        {
            if (sqlliteHelper == null)
            {
                sqlliteHelper = new SQLiteHelper(DBFile, "");
            }
            return sqlliteHelper;
        }
        // <summary> 
        // 执行一个查询语句，返回一个包含查询结果的DataTable 
        // </summary> 
        // <param name="sql">要执行的查询语句</param> 
        // <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        // <returns></returns> 
        // 调用示例：
        // string select_sql = "select * from student";                            //查询的SQL语句
        // DataTable dt = helper.ExecuteDataTable(select_sql, null);               //执行查询操作,结果存放在dt中
        public DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters)
        {
            try
            {
                using (SQLiteCommand Command = new SQLiteCommand(sql, Connection))
                {
                    if (parameters != null)
                    {
                        Command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(Command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (SQLiteException ex)
            {
                System.Exception exc = ex;
                throw (exc);
            }
        }
        public SQLiteDataReader ExecuteDataTable(string _yourQuery)
        {
            SQLiteCommand cmd = new SQLiteCommand(Connection); //实例化SQL命令
            cmd.CommandText = _yourQuery;
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;

        }
        // <summary> 
        // 对SQLite数据库执行增删改操作，返回受影响的行数。 
        // </summary> 
        // <param name="sql">要执行的增删改的SQL语句</param> 
        // <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        // <returns></returns> 
        // 调用示例：
        //  向数据库中student表中插入了一条(name = "马兆瑞"，sex = "男"，telephone = "15550008990")的记录
        // string insert_sql = "insert into student(name,sex,telephone) values(?,?,?)";        //插入的SQL语句(带参数)
        // SQLiteParameter[] para = new SQLiteParameter[3];                        //构造并绑定参数
        // string[] tag = { "name", "sex", "telephone" };
        // string[] value = { "马兆瑞", "男", "15550008990" };
        // for (int i = 0; i< 3; i++)
        // {
        //      para[i] = new SQLiteParameter(tag[i], value[i]);
        //  }
        // int ret = helper.ExecuteNonQuery(insert_sql, para);                     //执行插入操作

        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
        {
            int affectRows = 0;

            try
            {
                using (SQLiteTransaction Transaction = Connection.BeginTransaction())
                {
                    using (SQLiteCommand Command = new SQLiteCommand(sql, Connection, Transaction))
                    {
                        if (parameters != null)
                        {
                            Command.Parameters.AddRange(parameters);
                        }
                        affectRows = Command.ExecuteNonQuery();
                    }
                    Transaction.Commit();
                }
            }
            catch (SQLiteException ex)
            {
                affectRows = -1;
                Console.WriteLine(@"ExecuteNonQuery occurs exception：" + ex.Message);
            }
            return affectRows;
        }



    }
}
