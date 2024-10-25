using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PokeMemo.Models;

namespace PokeMemo.Utility
{
    public static class ImageHelper
    {
        public static Bitmap LoadFromResource(string path)
        {
            var uri = new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}{path}");
            return new Bitmap(AssetLoader.Open(uri));
        }

        private static readonly List<string> _grassTypeImages = new List<string>
        {
            "/Assets/bulbasaur.png",
            "/Assets/ivysaur.png",
            "/Assets/venusaur.png",
            "/Assets/oddish.png",
            "/Assets/gloom.png",
            "/Assets/vileplume.png",
        };

        private static readonly List<string> _fireTypeImages = new List<string>
        {
            "/Assets/charmander.png",
            "/Assets/charmeleon.png",
            "/Assets/charizard.png",
            "/Assets/vulpix.png",
            "/Assets/ninetales.png",
            "/Assets/growlithe.png",
            "/Assets/arcanine.png",
        };

        private static readonly List<string> _waterTypeImages = new List<string>
        {
            "/Assets/squirtle.png",
            "/Assets/wartortle.png",
            "/Assets/blastoise.png",
            "/Assets/psyduck.png",
            "/Assets/golduck.png",
            "/Assets/poliwag.png",
            "/Assets/poliwhirl.png",
            "/Assets/poliwrath.png",
        };

        private static readonly List<string> _electricTypeImages = new List<string>
        {
            "/Assets/pikachu.png",
            "/Assets/raichu.png",
            "/Assets/voltorb.png",
            "/Assets/electrode.png",
            "/Assets/electabuzz.png",
            "/Assets/jolteon.png",
        };

        public static string GetImageByType(PokemonType type)
        {
            var random = new Random();
            return type.Name.ToLower() switch
            {
                "grass" => _grassTypeImages[random.Next(_grassTypeImages.Count)],
                "fire" => _fireTypeImages[random.Next(_fireTypeImages.Count)],
                "water" => _waterTypeImages[random.Next(_waterTypeImages.Count)],
                "electric" => _electricTypeImages[random.Next(_electricTypeImages.Count)],
                _ => throw new ArgumentException("Invalid type"),
            };
        }
    }
}