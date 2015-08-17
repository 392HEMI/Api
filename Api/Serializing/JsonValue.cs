using System;
using System.Collections;

namespace ApiLibrary.Serializing
{
    public class JsonValue
    {
        private string value { get; set; }

        public static JsonValueType GetPrimitiveType(Type type)
        {
            if (type == typeof(Int32) || type == typeof(Int64) || type == typeof(Int16) ||
                type == typeof(UInt32) || type == typeof(UInt64) || type == typeof(UInt16))
                return JsonValueType.Integer;
            else if (type == typeof(Double) || type == typeof(float) || type == typeof(Decimal))
                return JsonValueType.Float;
            else if (type == typeof(Boolean))
                return JsonValueType.Boolean;
            else if (typeof(IEnumerable).IsAssignableFrom(type))
                return JsonValueType.Array;
            else if (!type.IsPrimitive)
                return JsonValueType.Object;
            else
                return JsonValueType.String;
        }

        public virtual string Value
        {
            get { return value; }
        }

        public JsonValue(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}