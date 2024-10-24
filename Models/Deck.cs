using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    public partial class Deck : ObservableObject
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public PokemonType Type { get; set; }

        public ObservableCollection<Card> Cards { get; set; }

        [ObservableProperty]
        private string _backgroundColour;

        [ObservableProperty]
        private string _foregroundColour;

        [ObservableProperty]
        private string _borderColour;

        [ObservableProperty]
        private Bitmap _imageSource;

        public Deck(string name, string category, PokemonType type)
        {
            Id = _nextId++;
            Name = name;
            Category = category;
            Type = type;
            Cards = new ObservableCollection<Card>();
            _backgroundColour = type.BackgroundColour;
            _foregroundColour = type.ForegroundColour;
            _borderColour = type.BorderColour;
            _imageSource = ImageHelper.LoadFromResource(type.ImageSource);
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}