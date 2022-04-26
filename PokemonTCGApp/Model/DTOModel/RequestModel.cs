

using PokemonTCGApp.Model.DataModel;
using System.ComponentModel.DataAnnotations;

namespace PokemonTCGApp.Model.DTOModel
{
    public class RequestVueTable
    {
        public Params @params { get; set; }
    }

    public class Params
    {
        public string Sort { get; set; }
        public int Page { get; set; }
        public int Per_page { get; set; }
        public Dictionary<string, object> FilterQuery { get; set; }
    }

    public class  RequestUpsertSet
    {
        public string? Id { get; set; } = null;

        [Required]
        public string? SeriesId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Series { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ReleaseTime { get; set; }

        public string File { get; set; }
    }

    public class RequestUpsertCard
    {
        public string? Id { get; set; } = null;

        [Required]
        public string SetId { get; set; }

        /// <summary>
        /// 某些限定卡未必有編號
        /// </summary>
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Supertype { get; set; }

        [Required]
        public List<string>? Subtypes { get; set; }

        [Required]
        public string Rarity { get; set; }

        [Required]
        public string Enviroment { get; set; }

        public List<string>? Types { get; set; }

        public int? Hp { get; set; } = null;

        public string EvolvesFrom { get; set; } = "";

        public List<string>? EvolvesTo { get; set; }

        public string FlavorText { get; set; } = "";

        public List<Ability>? Abilities { get; set; }

        public List<Attack>? Attacks { get; set; }

        public List<Weakness>? Weaknesses { get; set; }

        public List<Resistance>? Resistances { get; set; }

        public string TrainerEffect { get; set; } = "";

        public DateTime CreateTime { get; set; }

        public string File { get; set; } = "";
    }
}
