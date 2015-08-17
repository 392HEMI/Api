using System;
using System.Collections;
using System.Reflection;

namespace ApiLibrary.Serializing
{
    public class JsonSerializer
    {
        private static JsonArray serializeArray(IEnumerable arr)
        {
            Type elType;
            JsonArray array = new JsonArray();
            foreach (var el in arr)
            {
                elType = el.GetType();
                JsonValueType valueType = JsonValue.GetPrimitiveType(elType);
                if (valueType == JsonValueType.Object)
                    array.Add(serializeObject(el));
                else if (valueType == JsonValueType.Array)
                    array.Add(serializeArray((IEnumerable)el));
                else
                    array.Add(new JsonPrimitive(el.ToString(), valueType));
            }
            return array;
        }

        private static JsonObject serializeObject(object obj)
        {
            PropertyInfo[] propInfo = obj.GetType().GetProperties();
            string propertyName;
            object propertyValue;
            JsonValueType type;

            JsonObject o = new JsonObject(propInfo.Length);
            foreach (var p in propInfo)
            {
                propertyName = p.Name;
                propertyValue = p.GetValue(obj);
                type = JsonValue.GetPrimitiveType(p.PropertyType);
                if (type == JsonValueType.Object)
                {
                    JsonObject o2 = serializeObject(propertyValue);
                    o.Add(propertyName, o2);
                    continue;
                }
                else if (type == JsonValueType.Array)
                {
                    JsonArray a = serializeArray((IEnumerable)propertyValue);
                    o.Add(propertyName, a);
                    continue;
                }
                else
                {
                    string value = propertyValue.ToString();
                    JsonPrimitive primitive = new JsonPrimitive(value, type);
                    o.Add(propertyName, primitive);
                }
            }
            return o;
        }

        public static JsonObject SerializeObject(object obj)
        {
            return serializeObject(obj);
        }

        public static JsonArray SerializeArray(IEnumerable arr)
        {
            return serializeArray(arr);
        }
    }
}

