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
}
