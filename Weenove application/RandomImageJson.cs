
namespace Weenove_application
{
    public class Urls
    {
        public string raw { get; set; }
        public string full { get; set; }
        public string regular { get; set; }
        public string small { get; set; }
        public string thumb { get; set; }
    }
    public class RandomImageJson
    {
        public string id { get; set; }
        public int width { get; set; } 
        public int height { get; set; }
        public Urls urls { get; set; }
    }
}
