
using Newtonsoft.Json;
using System.IO;

namespace zadanie1.Logic
{
    class DataManager
    {
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
