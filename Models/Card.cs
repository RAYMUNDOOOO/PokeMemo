using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    public partial class Card : ObservableObject
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }

        [ObservableProperty]
        private string _backgroundColour;

        [ObservableProperty]
        private string _foregroundColour;

        [ObservableProperty]
        private string _borderColour;

        [ObservableProperty]
        private Bitmap _imageSource;

        public Card(string? question, string? answer, string backgroundColour, string foregroundColour, string borderColour, string imageSource)
        {
            Id = _nextId++;
            Question = question;
            Answer = answer;
            _backgroundColour = backgroundColour;
            _foregroundColour = foregroundColour;
            _borderColour = borderColour;
            _imageSource = ImageHelper.LoadFromResource(imageSource);
        }
    }
}