namespace EsportsCmsInfrastructure.Services
{
    public class PandaScoreMatchRaw
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? Begin_At { get; set; }
        public string Status { get; set; }

        public Videogame Videogame { get; set; }
        public List<Stream> Streams_List { get; set; }
    }

    public class Videogame
    {
        public string Name { get; set; }
    }

    public class Stream
    {
        public bool Main { get; set; }
        public string Raw_Url { get; set; }
    }
}