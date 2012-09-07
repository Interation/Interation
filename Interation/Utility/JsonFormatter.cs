using System.Collections;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace Interation.Utility
{
    public class JsonFormatter
    {
        public static string Serialize<T>(T obj)
        {
            return Serialize(obj, Encoding.UTF8);
        }

        public static string Serialize<T>(T obj, Encoding encoding)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));

            using (var memoryStream = new MemoryStream())
            {
                jsonFormatter.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;
                using (var streamReader = new StreamReader(memoryStream, encoding))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static T Deserialize<T>(string json)
        {
            return Deserialize<T>(json, Encoding.UTF8);
        }

        public static T Deserialize<T>(string json, Encoding encoding)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            var buffer = encoding.GetBytes(json);

            using (var memoryStream = new MemoryStream(buffer))
            {
                memoryStream.Position = 0;
                return (T)jsonFormatter.ReadObject(memoryStream);
            }
        }

        public static IDictionary Deserialize(string json)
        {
            var jsonFormater = new JavaScriptSerializer();
            return jsonFormater.DeserializeObject(json) as IDictionary;
        }
    }
}
