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

        private Deck _selectedDeck;
        public Deck? SelectedDeck 
        { 
            get => _selectedDeck;
            set => SetProperty(ref _selectedDeck, value);
        }

        [ObservableProperty]
        private Quiz _currentQuiz;

        public DeckLibrary()
        {
            Decks = new List<Deck>
                {
                    CreateDeck("Multiplication Deck", "Maths", "water"),
                    CreateDeck("Addition Deck", "Maths", "electric")
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
            var typeName = ImageHelper.PokemonTypes[type.ToLower()];
            return new Deck(name, category, typeName);
        }
    }

}

