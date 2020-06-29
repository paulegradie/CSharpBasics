using System.IO;

namespace TheGildedRose.Repositories.SQLite
{
    public abstract class DbConnectorBase
    {
        internal static string CurrentWorkingDirectory => Directory.GetCurrentDirectory();
        protected const char Sep = '\\';
    }
}