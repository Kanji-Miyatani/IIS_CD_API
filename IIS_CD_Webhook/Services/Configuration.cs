namespace IIS_CD_Webhook.Services
{
    public class Configuration
    {
        readonly IConfigurationRoot _config;
        public Configuration()
        {
            var environmentName = Environment.GetEnvironmentVariable("APPLICATION_ENVIRONMENT");

            //appsetting.jsonから読み込み
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: "appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .Build();
            _config = configuration;
        }
        public string ProjectFileName { get => _config["Deployment:ProjectFileName"]; }
        public string CloneURL { get => _config["Deployment:CloneURL"]; }
        public string WorkingDir { get=>_config["Deployment:WorkingDir"]; }
        public string RootPath { get => _config["Deployment:RootPath"]; }
        public string AccessToken { get => _config["Deployment:AccessToken"]; }
    }
}
