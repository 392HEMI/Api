using System;

namespace ApiLibrary.Serializing
{
    public class JsonPrimitive : JsonValue
    {
        private string getValue()
        {
            if (((Type == JsonValueType.Array || Type == JsonValueType.Object)) && Value == null)
                return "null";
            if (String.IsNullOrEmpty(Value))
                return "null";
            if ((Type == JsonValueType.Boolean || Type == JsonValueType.Integer || Type == JsonValueType.Float) &&
                Value == String.Empty)
                return "null";
            return Value;
        }

        public JsonValueType Type { get; set; }

        public JsonPrimitive(string value, JsonValueType type) : base(value)
        {
            Type = type;
        }

        public override string ToString()
        {
            string value = getValue();

            if (Type == JsonValueType.String)
                return "\"" + value + "\"";

            return value;
        }
    }
}