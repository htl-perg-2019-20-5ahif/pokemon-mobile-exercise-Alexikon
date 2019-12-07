using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonImportTesting
{
    class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string Url = "https://pokeapi.co/api/v2/pokemon/";
        public static PokemonUrl PokemonUrl { get; set; }
        public static List<Pokemon> Pokemon { get; set; }

        static async Task Main(string[] args)
        {
            Pokemon = new List<Pokemon>();

            var pokemonResponse = await HttpClient.GetAsync(Url);
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            PokemonUrl = JsonSerializer.Deserialize<PokemonUrl>(responseBody);

            foreach(var pok in PokemonUrl.Results)
            {
                pokemonResponse = await HttpClient.GetAsync(pok.Url);
                pokemonResponse.EnsureSuccessStatusCode();
                responseBody = await pokemonResponse.Content.ReadAsStringAsync();
                var pokemon = JsonSerializer.Deserialize<Pokemon>(responseBody);

                Console.WriteLine(pokemon.Name + "\t\t" + pokemon.Weight + "\t" + pokemon.Abilities[0].Ability.Name);

                Pokemon.Add(pokemon);
            }
        }
    }
}
