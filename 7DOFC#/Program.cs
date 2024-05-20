using _7DOFC_.Models;
using _7DOFC_.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        API api = new();
        var initialPokemons = api.InitialPokemons;
        foreach (var initialPokemon in initialPokemons) 
        {
            api.GET(initialPokemon);
        }
        Menus menu = new(api.Pokemons);
        menu.Start();
    }
}