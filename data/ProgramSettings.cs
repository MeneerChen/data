using data.Models;
using Microsoft.Extensions.Configuration;

namespace data
{
    public class ProgramSettings : ISqliteSettings
    {
        private readonly IConfiguration _configuration;

        public ProgramSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string ConnectionString =>
            _configuration["DigitalAngel:Devices:DataGenerator:WebApp:Sqlite:ConnectionString"];
    }
}