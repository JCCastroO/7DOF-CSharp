using _7DOFC_.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        API api = new();
        var initialPokemons = api.InitialPokemons;
        var pokemons = api.Pokemons;
        Console.WriteLine("Aperte qualquer tecla para visualizar os pokemons cadastrados: ");
        foreach (var initialPokemon in initialPokemons) 
        {
            api.GET(initialPokemon);
            Console.WriteLine(pokemons[initialPokemon].name);
        }
    }
}