using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamPoke
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonListPage : ContentPage
    {
        public PokemonUrl PokemonUrl { get; set; }

        public ObservableCollection<Pokemon> Pokemon { get; set; }

        private static HttpClient HttpClient = new HttpClient();
        private const string Url = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonListPage()
        {
            InitializeComponent();

            Pokemon = new ObservableCollection<Pokemon>();

            BindingContext = this;

            GetPokemonsAsync();
        }

        public async Task GetPokemonsAsync()
        {
            var pokemonResponse = await HttpClient.GetAsync(Url);
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            PokemonUrl = JsonConvert.DeserializeObject<PokemonUrl>(responseBody);

            while(PokemonUrl.Next != null)
            {
                foreach (var pok in PokemonUrl.Results)
                {
                    pokemonResponse = await HttpClient.GetAsync(pok.Url);
                    pokemonResponse.EnsureSuccessStatusCode();
                    responseBody = await pokemonResponse.Content.ReadAsStringAsync();
                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody);

                    Pokemon.Add(pokemon);
                }

                pokemonResponse = await HttpClient.GetAsync(PokemonUrl.Next);
                pokemonResponse.EnsureSuccessStatusCode();
                responseBody = await pokemonResponse.Content.ReadAsStringAsync();
                PokemonUrl = JsonConvert.DeserializeObject<PokemonUrl>(responseBody);
            }
        }

        public async void ListView_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var details = e.Item as Pokemon;
                await Navigation.PushModalAsync(new DetailPage(details));
            }
        }
    }
}
