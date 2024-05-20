using _7DOFC_.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Json;

namespace _7DOFC_.Services;

internal class API()
{
    public List<string> InitialPokemons = ["bulbasaur", "charmander", "squirtle"];
    public Dictionary<string, IPokemon> Pokemons = new();
    private RestClientOptions BaseUrl = new RestClientOptions("https://pokeapi.co/api/v2/pokemon/");

    public void GET(string endpoint)
    {
        var client = new RestClient(BaseUrl, configureSerialization: s => s.UseSystemTextJson());
        var request = new RestRequest(endpoint, Method.Get);
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {

            IPokemon pokemon = JsonConvert.DeserializeObject<IPokemon>(response.Content!)!;
            Pokemons.Add(endpoint, pokemon!);
        }
        else
        {
            Console.WriteLine(response.ErrorMessage);
        }
    }
}
