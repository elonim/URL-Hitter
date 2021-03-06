using System;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace URL_Hitter
{
    public class HitClass //need to be public for XmlSerializer t5o work
    {
        public string url;
        public int time;
        public bool autoStart;

        public HitClass() // Constructer Without Parameters used by XmlSerializer
        {

        }

        public HitClass(string cUrl, int cTime, bool cAutoStart) // Constructer With Input
        {
            url = cUrl;
            time = cTime;
            autoStart = cAutoStart;
        }

        public static string Hit(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent", "C# program");
                string result = client.DownloadString(url);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SaveConfig<T>(string filePath, T objectToWrite)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath);
                serializer.Serialize(writer, objectToWrite);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadConfig<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

    }
}
