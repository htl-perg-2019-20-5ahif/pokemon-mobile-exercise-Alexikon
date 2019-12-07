using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace XamPoke
{
    // Pokemon from https://pokeapi.co/api/v2/pokemon/
    public class PokemonUrl
    {
        public string Next { get; set; }

        public List<Results> Results { get; set; }
    }

    // Pokemon results with name and url
    public class Results
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    // real pokemon data from https://pokeapi.co/api/v2/pokemon/{id}/
    public class Pokemon : INotifyPropertyChanged
    {
        private string NameValue;
        public string Name
        {
            get => NameValue;
            set
            {
                NameValue = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int WeightValue;
        public int Weight
        {
            get => WeightValue;
            set
            {
                WeightValue = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public ObservableCollection<Abilities> Abilities { get; set; }

        private Sprites SpritesValue;
        public Sprites Sprites
        {
            get => SpritesValue;
            set
            {
                SpritesValue = value;
                OnPropertyChanged(nameof(Sprites));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }

    // real pokemon data abilities
    public class Abilities : INotifyPropertyChanged
    {
        private Ability AbilityValue;
        public Ability Ability
        {
            get => AbilityValue;
            set
            {
                AbilityValue = value;
                OnPropertyChanged(nameof(Ability));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }

    // real pokemon data ability
    public class Ability : INotifyPropertyChanged
    {
        private string NameValue;
        public string Name
        {
            get => NameValue;
            set
            {
                NameValue = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }

    // real pokemon data sprites
    public class Sprites : INotifyPropertyChanged
    {
        private string Front_DefaultValue;
        public string Front_Default
        {
            get => Front_DefaultValue;
            set
            {
                Front_DefaultValue = value;
                OnPropertyChanged(nameof(Front_Default));
            }
        }

        private string Back_DefaultValue;
        public string Back_Default
        {
            get => Back_DefaultValue;
            set
            {
                Back_DefaultValue = value;
                OnPropertyChanged(nameof(Back_Default));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
