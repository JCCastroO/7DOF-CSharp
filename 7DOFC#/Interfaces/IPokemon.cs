using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DOFC_.Interfaces;

internal class IPokemon
{
    public List<Ability> abilities { get; set; }
    public int base_experience { get; set; }
    public object cries { get; set; }
    public List<object> forms { get; set; }
    public List<object> game_indices { get; set; }
    public int height { get; set; }
    public List<object> held_items { get; set; }
    public int id { get; set; }
    public bool is_default { get; set; }
    public string location_area_encountes { get; set; }
    public List<object> moves { get; set; }
    public string name { get; set; }
    public int order { get; set; }
    public List<object> past_abilities { get; set; }
    public List<object> past_types { get; set; }
    public object species { get; set; }
    public object sprites { get; set; }
    public List<object> stats { get; set; }
    public List<object> types { get; set; }
    public int weight { get; set; }
}

internal class Ability
{
    public AbilityStatus ability { get; set; }
    public bool is_hidden { get; set; }
    public int slot { get; set; }
}

internal class AbilityStatus
{
    public string name { get; set; }
    public string url { get; set; }
}