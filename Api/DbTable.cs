using System;

namespace ApiLibrary
{
    public class DbTable
    {
        private string tableName;
        private string schema;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public string Schema
        {
            get { return schema; }
            set { schema = value; }
        }

        public DbTable(string tableName)
        {
            this.tableName = tableName;
            this.schema = "public";
        }

        public DbTable(string tableName, string schema)
        {
            this.tableName = tableName;
            this.schema = schema;
        }
    }
}

