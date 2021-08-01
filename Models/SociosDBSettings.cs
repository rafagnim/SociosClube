namespace Socios.Models
{
    
    public class SociosDBSettings : ISociosDBSettings
    {
        public string SociosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISociosDBSettings
    {
        string SociosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
