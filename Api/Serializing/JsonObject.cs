using System;
using System.Collections;
using System.Collections.Generic;

namespace ApiLibrary.Serializing
{
    public class JsonObject : JsonValue, IDictionary<string, JsonValue>
    {
        private Dictionary<string, JsonValue> fields { get; set; }

        private ICollection<KeyValuePair<string, JsonValue>> asCollection()
        {
            return (ICollection<KeyValuePair<string, JsonValue>>)fields;
        }

        private string serialize()
        {
            string json = "{";
            if (fields.Count > 0)
            {
                int i = 1;
                foreach (KeyValuePair<string, JsonValue> field in fields)
                {
                    json += "\"" + field.Key + "\":" + field.Value.ToString(); 
                    if (i != fields.Count)
                        json += ",";
                    i++;
                }
            }
            json += "}";
            return json;
        }

        public JsonObject()
            : this(0) { }

        public JsonObject(int fieldsCount) : base(String.Empty)
        {
            fields = new Dictionary<string, JsonValue>(fieldsCount);
        }
            
        public JsonValue this[string fieldName]
        {
            get { return fields[fieldName]; }
            set { fields[fieldName] = value; }
        }

        public override string Value
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            return serialize();
        }

        public void Add(string key, JsonValue value)
        {
            fields.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return fields.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return fields.Remove(key);
        }

        public bool TryGetValue(string key, out JsonValue value)
        {
            return fields.TryGetValue(key, out value);
        }

        public ICollection<string> Keys
        {
            get { return fields.Keys; }
        }

        public ICollection<JsonValue> Values
        {
            get { return fields.Values; }
        }

        public void Add(KeyValuePair<string, JsonValue> item)
        {
            asCollection().Add(item);
        }

        public void Clear()
        {
            fields.Clear();
        }

        public bool Contains(KeyValuePair<string, JsonValue> item)
        {
            return asCollection().Contains(item);
        }

        public void CopyTo(KeyValuePair<string, JsonValue>[] array, int arrayIndex)
        {
            asCollection().CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, JsonValue> item)
        {
            return asCollection().Remove(item);
        }

        public int Count
        {
            get { return fields.Count; }
        }

        public bool IsReadOnly
        {
            get { return asCollection().IsReadOnly; }
        }

        public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
        {
            return fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return fields.GetEnumerator();
        }
    }
}