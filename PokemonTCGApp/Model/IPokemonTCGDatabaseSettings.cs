namespace PokemonTCGApp.Model
{
    public interface IPokemonTCGDatabaseSettings
    {
        string PokemonTCGCollectionName { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
