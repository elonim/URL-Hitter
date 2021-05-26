using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace URL_Hitter2
{

    public class HitClass //need to be public for XmlSerializer t5o work
    {
        public const string Filepath = "Config.xml";

        public string url;
        public int time;
        public string timeType;
        public bool showOutput;

        #region Constructors

        public HitClass(string cUrl,   // Constructer
                        int cTime,
                        string cTimeType,
                        bool cOutput)
        {
            url = cUrl;
            time = cTime;
            timeType = cTimeType;
            showOutput = cOutput;
        }
        public HitClass() // Constructer Without Parameters used by XmlSerializer
        { }
        #endregion

        #region Hit Method
        public static string Hit(string url, int time, bool showOutput)
        {
            try
            {
                var client = new WebClient();
                client.Headers.Add("User-Agent", "C# program URL-Hitter");
                string webResult = client.DownloadString(url); //Load the URL and save the resust in a string


                string now = $"Last Hit: {Convert.ToString(DateTime.Now)}"; //  the next couple of lines is for building a nice output with stringbuilder and datetime
                var sb = new StringBuilder(now, 500);

                string newLine = "\n";

                sb.Append(newLine);
                if (showOutput == true)//Show output from webside or not
                {
                    sb.Append(webResult);
                }
                else
                {
                    sb.Append("OK\nOutput hidden");
                }
                sb.Append(newLine);
                sb.Append($"Next Hit: {Convert.ToString(DateTime.Now.AddMilliseconds(time))}"); //current datetime + hours till next hit

                var done = sb.ToString();

                return done;
            }
            catch (Exception)
            {

                return "\nError: Wrong or Unreachable URL";
            }

        }


        public static int TimeInterval(int time, string intervalType)  //set the time between hits at the URL
        {
            int result;
            if (intervalType == "Hours") //get milliseconds in hours
            {
                result = 3600000 * time;
                return result;
            }
            else if (intervalType == "Minutes") //Get milliseconds in minutes
            {
                result = 60000 * time;
                return result;
            }
            else if (intervalType == "Seconds") // get milliseconds in seconds
            {
                result = 1000 * time;
                return result;
            }
            else
            {
                result = 86400000; //default 24 hours if the user have entered something else
                return result;
            }
        }
        #endregion

        #region Save and Read to xml file
        public static void SaveConfig<T>(string filePath,
                                         T objectToWrite)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));  //initialize XML seriealizer
                writer = new StreamWriter(filePath);            //initialize steamwriter
                serializer.Serialize(writer, objectToWrite);    //Seriealizes the object and writes it to a .XML tile
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close(); //Close the writer
            }
        }

        public static T ReadConfig<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));  //initialize XML seriealizer
                reader = new StreamReader(filePath);            //initialize steamreader
                return (T)serializer.Deserialize(reader);       //Deseriealize the XML file and and creates an object
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close(); //Close the reader
            }
        }
        #endregion
        
        public static void TestURL(string URL)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = URL
                };
                Process.Start(psi);
            }
            catch (Exception)
            {
                MessageBox.Show("Input missing\nURL needs to be filled in to test",
                caption: "No URL");
            }
        }
    }
}
