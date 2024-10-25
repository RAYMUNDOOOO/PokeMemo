using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    public partial class PokemonType : ObservableObject
    {
        public string Name { get; set; }
        public string BackgroundColour { get; set; }
        public string ForegroundColour { get; set; }
        public string BorderColour { get; set; }

        [ObservableProperty]
        private Bitmap _imageSource;

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