using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NameAttribute : Attribute
    {
        private string name;
        public string Name { get; set; }

        public NameAttribute(string name)
        {
            this.name = name;
        }
    }
}
