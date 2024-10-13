using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace PokeMemo.Models
{
    public partial class Deck : ObservableObject
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Card> Cards { get; set; }

        [ObservableProperty]
        private string _backgroundColour;

        [ObservableProperty]
        private string _foregroundColour;

        [ObservableProperty]
        private string _borderColour;

        public Deck(string name, string category, string backgroundColour, string foregroundColour, string borderColour)
        {
            Id = _nextId++;
            Name = name;
            Category = category;
            Cards = new List<Card>();
            _backgroundColour = backgroundColour;
            _foregroundColour = foregroundColour;
            _borderColour = borderColour;
        }
    }
}
