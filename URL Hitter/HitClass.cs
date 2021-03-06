using System;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace URL_Hitter
{
    public class HitClass //need to be public for XmlSerializer t5o work
    {
        public string url;
        public int time;
        public bool autoStart;
        public bool showOutput;

        public HitClass() // Constructer Without Parameters used by XmlSerializer
        {

        }

        public HitClass(string cUrl, int cTime, bool cAutoStart, bool cOutput) // Constructer With Input
        {
            url = cUrl;
            time = cTime;
            autoStart = cAutoStart;
            showOutput = cOutput;
        }

        public static string Hit(string url, int time, bool showOutput)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent", "C# program URL-Hitter");
                string webResult = client.DownloadString(url); //Load the URL and save the resust in a string

                
                string now = "Last Hit: " + Convert.ToString(DateTime.Now); //  the next couple of lines is for building a nice output with stringbuilder and datetime
                StringBuilder sb = new StringBuilder(now, 500);
                
                string newLine = "\n\n";


                DateTime currentTime = DateTime.Now;  //current datetime
                DateTime nextHit = currentTime.AddHours(time); //current datetime + hours till next hit


                sb.Append(newLine);
                if (showOutput==true)//Show output from webside or not
                {
                    sb.Append(webResult);
                }
                else
                {
                    sb.Append("OK\nOutput hidden");
                }
                sb.Append(newLine);
                sb.Append("Next Hit:" + nextHit);


                var done = sb.ToString();

                return done;
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
