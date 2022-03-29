namespace PokemonTCGApp.Model
{
    public class PokemonTCGDatabaseSettings : IPokemonTCGDatabaseSettings
    {
        public string PokemonTCGCollectionName { get ; set ; }= String.Empty;
        public string ConnectionStrings { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
