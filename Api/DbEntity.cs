using System;

namespace ApiLibrary
{
    public class DbEntity
    {
        private DbTable table;
        private string[] columns;

        public DbTable Table
        {
            get { return table; }
        }

        public string[] Columns
        {
            get { return columns; }
        }

        public DbEntity(DbTable table, params string[] columns)
        {
            this.table = table;
            this.columns = columns;
        }
    }
}