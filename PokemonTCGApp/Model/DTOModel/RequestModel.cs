namespace PokemonTCGApp.Model.DTOModel
{
    public class RequestVueTable
    {
        public Params @params { get; set; }
    }

    public class Params
    {
        public string sort { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Dictionary<string, object> filterQuery { get; set; }
    }

    public class RequestCreateSet
    {
        public string? SeriesId { get; set; }

        public string? Name { get; set; }

        public string? Series { get; set; }

        public string? Image { get; set; }

        public DateTime? ReleaseTime { get; set; } = DateTime.Now;
    }
}
