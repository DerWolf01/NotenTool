
using System.Data.SQLite;
namespace NotenTool.DatabaseService
{
    interface IDatabase
    {
        string rawQuery(string query);
        List<Dictionary<string, dynamic?>> rawSelect(string query);
        // Used to insert Data
        int rawInsert(string query);
        // Get Database version
        string? getVersion();
        SQLiteConnection initConnection();
        void closeConnection();
        SQLiteCommand getCommand(string query);
        // Init standard tables
        public int initTables();
    }


    public class SQLite : IDatabase
    {

        public SQLite()
        {
            connection = initConnection();
            openConnection();
        }
        private SQLiteConnection connection;
        public void closeConnection()
        {
            throw new NotImplementedException();
        }
        public string? getVersion()
        {
            throw new NotImplementedException();
        }
        public int initTables()
        {
            throw new NotImplementedException();
        }
        public SQLiteConnection initConnection()
        {
            return new SQLiteConnection("Data Source=:memory");
        }
        public void openConnection()
        {
            connection.Open();
        }
        public int rawInsert(string stm)
        {
            throw new NotImplementedException();
        }
        public string rawQuery(string query)
        {

            return getCommand(query).ExecuteNonQuery().ToString();
        }
        public Dictionary<string, dynamic?> rawSelect(string query)
        {


            var cmd = getCommand(query);
            var reader = cmd.ExecuteReader();
            Dictionary<string, dynamic?> raw = new Dictionary<string, dynamic?>();

            // Extract and save data in List
            while (reader.Read())
            {
                var rows = reader.GetValues();

                for (int i = 0; i < rows.AllKeys.Length; i++)
                {

                    raw.Add(rows.AllKeys[i]!, rows.GetValues(i));




                }
            }
            return raw;
        }
        List<Dictionary<string, dynamic?>> IDatabase.rawSelect(string query)
        {
            throw new NotImplementedException();
        }


        public SQLiteCommand getCommand(string query)
        {
            return new SQLiteCommand(query);
        }

    }
}