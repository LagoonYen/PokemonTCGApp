namespace PokemonTCGApp.Model
{
    public interface IPokemonTCGDatabaseSettings
    {
        string PokemonTCGCollectionName { get; set; }
        string CardCollectionName { get; set; }
        string SetCollectionName { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
