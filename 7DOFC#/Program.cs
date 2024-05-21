using _7DOFC_.Controller;
using _7DOFC_.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        PokemonService pokemonService = new();
        var initialPokemons = pokemonService.InitialPokemons;
        foreach (var initialPokemon in initialPokemons) 
        {
            pokemonService.GET(initialPokemon);
        }
        TamagochiController controller = new(pokemonService.Pokemons);
        controller.Start();
    }
}