using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    // This class represents a PokemonType, which is used to set the colours and image of a Card.
    public partial class PokemonType : ObservableObject
    {
        public string Name { get; set; }
        public string BackgroundColour { get; set; }
        public string ForegroundColour { get; set; }
        public string BorderColour { get; set; }

        [ObservableProperty]
        private Bitmap _imageSource;

        // The list of PokemonTypes is defined in the DeckLibrary class.
        public PokemonType(string name, string backgroundColour, string foregroundColour, string borderColour, string imageSource)
        {
            Name = name;
            BackgroundColour = backgroundColour;
            ForegroundColour = foregroundColour;
            BorderColour = borderColour;
            _imageSource = ImageHelper.LoadFromResource(imageSource);
        }
    }
}