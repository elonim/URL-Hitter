namespace URL_Hitter.Singleton
{
    public sealed class ConfigSingleton
    {
        private static ConfigSingleton fileInstance;// = new ConfigSingleton();  eager 
        private readonly string filepath = "Config.xml";

        private ConfigSingleton()
        {
        }

        public static ConfigSingleton GetConfigInstance()
        {
            if (fileInstance == null)
            {
                fileInstance = new ConfigSingleton();
            }
            return fileInstance;
        }

        public string ConfigLocation()
        {
            return filepath;
        }
    }
}
