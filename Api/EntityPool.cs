namespace ApiLibrary
{
    public class EntityPool
    {
        private int length;
        private Entity[][] entities;
        private bool[] isfree;


        public EntityPool(int length)
        {
            this.length = length;
            isfree = new bool[length];
            entities = new Entity[length][];
        }

        public Entity[] GetFree()
        {
            lock (isfree)
            {
                for (int i = 0; i < length; i++)
                    if (isfree[i])
                    {
                        isfree[i] = false;
                        return entities[i];
                    }   
            }
            // entity count not in threads count
            return null;
        }

        public void SetFree(Entity[] entity)
        {
            lock (isfree)
            {
                for (int i = 0; i < length; i++)
                    if (entities[i] == entity)
                    {
                        isfree[i] = true;
                        return;
                    }
            }
        }
    }
}

