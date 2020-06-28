using System;
using System.IO;

namespace ItemRepository.SQLite
{
    public abstract class DbConnectorBase
    {
        internal static string CurrentWorkingDirectory => Directory.GetCurrentDirectory();
        protected const char Sep = '\\';

        protected abstract string GetConnectionString(string dbFileName);
    }
}