using System.Collections.Generic;

namespace ApiLibrary
{
    public abstract class Entity
    {
        private DbEntity entity;
        private string name;
        private IEnumerable<ApiMethod> methods;

        public DbEntity DEntity
        {
            get { return entity; }
        }

        public string Name
        {
            get { return name; }
        }

        public IEnumerable<ApiMethod> Methods
        {
            get { return methods; }
        }

        public Entity(string name, DbEntity entity)
        {
            this.entity = entity;
            this.name = name;
        }
    }
}

