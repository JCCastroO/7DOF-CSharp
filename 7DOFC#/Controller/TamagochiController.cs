using _7DOFC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DOFC_.Controller;

internal class TamagochiController(Dictionary<string, Pokemon> pokemons)
{
    public string Player { get; set; } = "";
    public Dictionary<string, Pokemon> Pokemons = pokemons;
    public Pokemon? AdoptedPokemon { get; set; }

    public void Start()
    {
        Logo();
        Console.WriteLine("Como deseja ser chamado?");
        Player = Console.ReadLine()!;

        if(Player != "")
        {
            Menu();
        }
    }

    private void Logo()
    {
        Console.WriteLine("\n   #####   ##   #    #   ##    ####   ####   ####  #    #  #");
        Console.WriteLine("     #    #  #  ##  ##  #  #  #    # #    # #    # #    #  #");
        Console.WriteLine("     #   #    # # ## # #    # #      #    # #      ######  #");
        Console.WriteLine("     #   ###### #    # ###### #  ### #    # #      #    #  #");
        Console.WriteLine("     #   #    # #    # #    # #    # #    # #    # #    #  #");
        Console.WriteLine("     #   #    # #    # #    #  ####   ####   ####  #    #  #\n");
    }

    private void Title(string title)
    {
        Console.WriteLine($"\n---------------{title}---------------\n");
    }

    private void Menu()
    {
        Console.Clear();
        Logo();
        Title(" MENU ");
        Console.WriteLine($"{Player} você deseja: ");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
        int choise = int.Parse(Console.ReadLine()!);
        switch(choise)
        {
            case 1: Adoption();
                break;
            case 2: Mascots(); break;
            case 3:
                Console.WriteLine("\nAté logo!");
                break;
            default: Console.WriteLine("\nEscolha inválida!");
                break;
        }
    }

    private void Mascots()
    {
        Console.Clear();
        Logo();
        Title(" SEUS MASCOTES ");
        Console.WriteLine($"{Player} Verifique seu mascote ou tecle ENTER para voltar: ");
        Console.WriteLine($"{AdoptedPokemon?.name.ToUpper()}");
        string choice = Console.ReadLine()!;
        if (choice == "")
        {
            Back(1000);
            Menu();
        }
        else if (Pokemons.ContainsKey(choice.ToLower()))
        {
            MoreOptions(Pokemons[choice.ToLower()], "mascots");
        }
        else
        {
            Console.WriteLine("... Você não possui esse mascote ...");
            Console.ReadKey();
            Back(1500);
            Menu();
        }
    }

    private void Adoption()
    {
        Console.Clear();
        Logo();
        Title(" ADOTAR UM MASCOTE ");
        Console.WriteLine($"{Player} Escolha uma espécie ou tecle ENTER para voltar: ");
        foreach(KeyValuePair<string, Pokemon> pokemon in Pokemons)
        {
            Console.WriteLine(pokemon.Key.ToUpper());
        }
        string choice = Console.ReadLine()!;
        if (choice == "")
        {
            Back(1000);
            Menu();
        }
        else if (Pokemons.ContainsKey(choice.ToLower()))
        {
            Options(choice);
        }
        else
        {
            Console.WriteLine("... Mascote não existe ...");
            Console.ReadKey();
            Back(1500);
            Menu();
        }
    }

    private void Options(string pokemon)
    {
        Title("----------");
        Console.WriteLine($"{Player} você deseja: ");
        Console.WriteLine($"1 - Saber mais sobre {pokemon.ToUpper()}");
        Console.WriteLine($"2 - Adotar {pokemon.ToUpper()}");
        Console.WriteLine($"3 - Voltar");
        int choise = int.Parse(Console.ReadLine()!);
        switch (choise)
        {
            case 1:
                MoreOptions(Pokemons[pokemon.ToLower()], "options");
                break;
            case 2:
                Adopted(Pokemons[pokemon.ToLower()]);
                break;
            case 3:
                Back(1000);
                Adoption();
                break;
            default:
                Console.WriteLine("Escolha inválida!");
                Back(1500);
                Menu();
                break;
        }
    }

    private void MoreOptions(Pokemon pokemon, string screen)
    {
        Title("----------");
        Console.WriteLine($"Nome do Pokemon: {pokemon.name.ToUpper()}");
        Console.WriteLine($"Altura: {pokemon.height}");
        Console.WriteLine($"Peso: {pokemon.weight}");
        Console.WriteLine("Habilidades: ");
        var abilities = pokemon.abilities;
        foreach (var ability in abilities)
        {
            Console.WriteLine(ability.ability.name.ToUpper());
        }
        Console.ReadKey();
        Back(1000);
        if(screen == "options")
        {
            Options(pokemon.name);
        } else if (screen == "mascots"){
            Mascots();
        }
        else
        {
            Menu();
        }
    }

    private void Adopted(Pokemon pokemon)
    {
        Console.Clear();
        Logo();
        AdoptedPokemon = pokemon;
        Console.WriteLine($"{Player.ToUpper()} VOCÊ ADOTOU UM NOVO POKEMON!!!");
        Back(2000);
        Menu();
    }
    private void Back(int time)
    {
        Console.WriteLine("\nVoltando ...\n");
        Thread.Sleep(time);
    }
}


