using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeMemo.Utility;

namespace PokeMemo.Models
{
    public class PokemonType
    {
        public string Name { get; set; }
        public string BackgroundColour { get; set; }
        public string ForegroundColour { get; set; }
        public string BorderColour { get; set; }
        public string ImageSource { get; set; }

        public PokemonType(string name, string backgroundColour, string foregroundColour, string borderColour, string imageSource)
        {
            Name = name;
            BackgroundColour = backgroundColour;
            ForegroundColour = foregroundColour;
            BorderColour = borderColour;
            ImageSource = imageSource;
        }
    }
}
