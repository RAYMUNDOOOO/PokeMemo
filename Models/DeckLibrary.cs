using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Models
{
    public partial class DeckLibrary : ObservableObject
    {
        public List<Deck> Decks { get; set; }

        private Deck? _selectedDeck;
        public Deck? SelectedDeck
        {
            get => _selectedDeck;
            set => SetProperty(ref _selectedDeck, value);
        }

        private PokemonType? _selectedType;
        public PokemonType? SelectedType
        {
            get => _selectedType;
            set => SetProperty(ref _selectedType, value);
        }

        public List<PokemonType> PokemonTypes { get; set; }

        [ObservableProperty]
        private Quiz? _currentQuiz;

        public DeckLibrary()
        {
            PokemonTypes = new List<PokemonType>
            {
                new PokemonType("Grass", "#94D88D", "Black", "#61BB59", "/Assets/grass-type.png"),
                new PokemonType("Fire", "#FFC9A1", "Black", "#FF9D55", "/Assets/fire-type.png"),
                new PokemonType("Water", "#87BBF1", "Black", "#4D91D7", "/Assets/water-type.png"),
                new PokemonType("Electric", "#FFEC94", "Black", "#F3D33C", "/Assets/electric-type.png")
            };

            Decks = new List<Deck>
                {
                    CreateDeck("Multiplication Deck", "Maths", "Water"),
                    CreateDeck("Addition Deck", "Maths", "Electric")
                };

            var multDeck = Decks.FirstOrDefault(d => d.Name == "Multiplication Deck");
            multDeck.Cards.Add(new Card("What is 1 x 1?", "1", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 2?", "2", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 3?", "3", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 4?", "4", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 5?", "5", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 6?", "6", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 7?", "7", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 8?", "8", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck.Cards.Add(new Card("What is 1 x 9?", "9", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));

            var addnDeck = Decks.FirstOrDefault(d => d.Name == "Addition Deck");
            addnDeck.Cards.Add(new Card("What is 1 + 1?", "2", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 2 + 2?", "4", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 3 + 3?", "6", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 4 + 4?", "8", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 5 + 5?", "10", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 6 + 6?", "12", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 7 + 7?", "14", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 8 + 8?", "16", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck.Cards.Add(new Card("What is 9 + 9?", "18", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));

            SelectedDeck = null;
        }

        private Deck CreateDeck(string name, string category, string type)
        {
            var typeName = PokemonTypes.First(t => t.Name.Equals(type, StringComparison.OrdinalIgnoreCase));
            return new Deck(name, category, typeName);
        }
    }
}