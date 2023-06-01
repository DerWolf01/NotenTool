using NotenTool.DatabaseService;

namespace NotenTool
{




    class Program
    {
        static void Main(string[] args)
        {


            SQLite db = new SQLite();
            db.initTables();
            Console.WriteLine("Herzlich Willkommen zum Notentool!");
            Console.ReadKey(true);
        }
    }
}