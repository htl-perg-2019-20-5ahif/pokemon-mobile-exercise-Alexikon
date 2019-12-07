using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonImportTesting
{
    // Pokemon from https://pokeapi.co/api/v2/pokemon/
    class PokemonUrl
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Results> Results { get; set; }
    }

    // Pokemon results with name and url
    public class Results
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    // real pokemon data from https://pokeapi.co/api/v2/pokemon/{id}/
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<Abilities> Abilities { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites SpritesUrls { get; set; }
    }

    // real pokemon data abilities
    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }
    }

    // real pokemon data ability
    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    
    // real pokemon data sprites
    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefaultUrl { get; set; }

        //public Image FrontDefault { get; set; }

        [JsonPropertyName("back_default")]
        public string BackSpriteUrl { get; set; }

        //public Image BackDefault { get; set; }
    }
}
