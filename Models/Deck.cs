using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;

namespace PokeMemo.Models
{
    // This class represents a Deck of flashcards.
    // It inherits from ObservableObject, which is part of the CommunityToolkit.Mvvm library, so that changes to its properties can be observed by the UI.
    public partial class Deck : ObservableObject
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Category { get; set; }

        // The PokemonType property is used to set the colours and image of the deck.
        private PokemonType _type;
        public PokemonType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        // The Cards property is an observable collection of Card objects, which means that changes to the collection can be observed by the UI.
        public ObservableCollection<Card> Cards { get; set; }

        // These properties are used to set the colours and image of the Deck.
        // They are also passed to the Cards when they are added to the Deck.
        private string _backgroundColour;
        public string BackgroundColour
        {
            get => _backgroundColour;
            set
            {
                _backgroundColour = value;
                OnPropertyChanged();
            }
        }

        private string _foregroundColour;
        public string ForegroundColour
        {
            get => _foregroundColour;
            set
            {
                _foregroundColour = value;
                OnPropertyChanged();
            }
        }

        private string _borderColour;
        public string BorderColour
        {
            get => _borderColour;
            set
            {
                _borderColour = value;
                OnPropertyChanged();
            }
        }

        private Bitmap _imageSource;
        public Bitmap ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        // The colours and image of the Deck are set based on the PokemonType of the Deck.
        // The list of PokemonTypes is defined in the DeckLibrary class.
        public Deck(string? name, string? category, PokemonType type)
        {
            Id = _nextId++;
            Name = name;
            Category = category;
            Type = type;
            Cards = new ObservableCollection<Card>();
            BackgroundColour = type.BackgroundColour;
            ForegroundColour = type.ForegroundColour;
            BorderColour = type.BorderColour;
            _imageSource = type.ImageSource;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}