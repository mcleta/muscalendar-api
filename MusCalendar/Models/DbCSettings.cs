using System;

namespace MusCalendar.Models
{
    public class DbCSettings : IDbCSettings
    {
        public string CollectionName { get; set; } = Environment.GetEnvironmentVariable("DbConfig:CollectionName");
        public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("DbConfig:ConnectionString");
        public string DbName { get; set; } = Environment.GetEnvironmentVariable("DbConfig:DbName");
    }

    public interface IDbCSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DbName { get; set; }
    }
}
