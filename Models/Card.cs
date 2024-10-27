using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    // This class represents a Card in a Deck.
    // It inherits from ObservableObject, which is part of the CommunityToolkit.Mvvm library, so that changes to its properties can be observed by the UI.
    public partial class Card : ObservableObject
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }

        // These properties are used to set the colours and image of the card.
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

        // In practice the colours are set by the Deck the Card belongs to.
        // And the image is set using ImageHelper's GetImageByType method to randomise the pokemon image based on the type of the Deck.
        public Card(string? question, string? answer, string backgroundColour, string foregroundColour, string borderColour, string imageSource)
        {
            Id = _nextId++;
            Question = question;
            Answer = answer;
            BackgroundColour = backgroundColour;
            ForegroundColour = foregroundColour;
            BorderColour = borderColour;
            ImageSource = ImageHelper.LoadFromResource(imageSource);
        }
    }
}