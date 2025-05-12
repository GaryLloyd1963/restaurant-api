using System.Data.SQLite;

namespace SqliteInfrastructure
{
    public class SqliteDBBuilder
    {
        public string BuildDatabase(string databaseName)
        {
            Console.WriteLine("Built database: " + databaseName);
            return "success";
        }

    }
}
