using System;
using System.Configuration;
using System.Web;

namespace ApiLibrary
{
    public class ApiApplication : HttpApplication
    {
        private EntityPool entityPool;

        public EntityPool EntityPool
        {
            get { return entityPool; }
        }

        public ApiApplication()
        {
            string size = ConfigurationManager.AppSettings["entityPoolSize"];
            uint poolSize;
            if (String.IsNullOrEmpty(size))
                poolSize = 10;
            else if (!UInt32.TryParse(size, out poolSize) && poolSize != 0)
                poolSize = 10;
            entityPool = new EntityPool((int)poolSize);
        }
    }
}