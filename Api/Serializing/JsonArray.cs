using System;
using System.Collections;
using System.Collections.Generic;

namespace ApiLibrary.Serializing
{
    public class JsonArray : JsonValue, ICollection<JsonValue>
    {
        private List<JsonValue> elements { get; set; }

        private string serialize()
        {
            string json = "[";
            if (elements.Count > 0)
            {
                int i = 1;
                foreach (JsonValue element in elements)
                {
                    json += element.Value.ToString(); 
                    if (i != elements.Count)
                        json += ",";
                    i++;
                }
            }
            json += "]";
            return json;
        }

        public JsonArray()
            : this(0) { }

        public JsonArray(int elementsCount) : base(String.Empty)
        {
            elements = new List<JsonValue>(elementsCount);
        }

        public override string Value
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            return serialize();
        }

        #region ICollection implementation

        public void Add(JsonValue item)
        {
            elements.Add(item);
        }

        public void Clear()
        {
            elements.Clear();
        }

        public bool Contains(JsonValue item)
        {
            return elements.Contains(item);
        }

        public void CopyTo(JsonValue[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        public bool Remove(JsonValue item)
        {
            return elements.Remove(item);
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<JsonValue>)elements).IsReadOnly; }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<JsonValue> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        #endregion

        #region IEnumerable implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        #endregion
    }
}