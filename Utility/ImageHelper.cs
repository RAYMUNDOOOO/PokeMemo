using System;
using System.Collections.Generic;
using System.Reflection;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using PokeMemo.Models;

namespace PokeMemo.Utility
{
    // The ImageHelper class is a utility class that provides a method to load images from the application's Assets folder.
    public static class ImageHelper
    {
        // LoadFromResource is a static method that takes a string path and returns a Bitmap object.
        public static Bitmap LoadFromResource(string path)
        {
            var uri = new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}{path}");
            return new Bitmap(AssetLoader.Open(uri));
        }

        // GetImageByType is a static method that takes a PokemonType object and returns a string path to an image.
        // The method uses a switch statement to determine the type of Pokemon and returns a random image from the corresponding list.
        public static string GetImageByType(PokemonType type)
        {
            var random = new Random();
            return type.Name.ToLower() switch
            {
                "grass" => _grassTypeImages[random.Next(_grassTypeImages.Count)],
                "fire" => _fireTypeImages[random.Next(_fireTypeImages.Count)],
                "water" => _waterTypeImages[random.Next(_waterTypeImages.Count)],
                "electric" => _electricTypeImages[random.Next(_electricTypeImages.Count)],
                "normal" => _normalTypeImages[random.Next(_normalTypeImages.Count)],
                _ => throw new ArgumentException("Invalid type"),
            };
        }

        // The following lists contain the paths to the images for each type of Pokemon, which are used to randomly select an image for a card.
        private static readonly List<string> _grassTypeImages = new List<string>
        {
            "/Assets/bulbasaur.png",
            "/Assets/ivysaur.png",
            "/Assets/venusaur.png",
            "/Assets/oddish.png",
            "/Assets/gloom.png",
            "/Assets/vileplume.png",
            "/Assets/budew.png",
            "/Assets/roselia.png",
            "/Assets/roserade.png",
            "/Assets/leafeon.png",
            "/Assets/chikorita.png",
            "/Assets/bayleef.png",
            "/Assets/meganium.png",
            "/Assets/hoppip.png",
            "/Assets/skiploom.png",
            "/Assets/jumpluff.png",
            "/Assets/snivy.png",
            "/Assets/treecko.png",
            "/Assets/turtwig.png",
            "/Assets/bellsprout.png",
            "/Assets/weepinbell.png",
            "/Assets/victreebel.png",
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
            "/Assets/ponyta.png",
            "/Assets/ponyta-shiny.png",
            "/Assets/rapidash.png",
            "/Assets/numel.png",
            "/Assets/camerupt.png",
            "/Assets/flareon.png",
            "/Assets/chimchar.png",
            "/Assets/cyndaquil.png",
            "/Assets/quilava.png",
            "/Assets/typhlosion.png",
            "/Assets/slugma.png",
            "/Assets/magcargo.png",
            "/Assets/tepig.png",
            "/Assets/torchic.png",
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
            "/Assets/politoed.png",
            "/Assets/azumarill.png",
            "/Assets/marill.png",
            "/Assets/lapras.png",
            "/Assets/vaporeon.png",
            "/Assets/totodile.png",
            "/Assets/croconaw.png",
            "/Assets/feraligatr.png",
            "/Assets/magikarp.png",
            "/Assets/mudkip.png",
            "/Assets/oshawott.png",
            "/Assets/piplup.png",
            "/Assets/wailmer.png",
            "/Assets/wailord.png",
        };

        private static readonly List<string> _electricTypeImages = new List<string>
        {
            "/Assets/pikachu.png",
            "/Assets/raichu.png",
            "/Assets/pichu.png",
            "/Assets/voltorb.png",
            "/Assets/electrode.png",
            "/Assets/elekid.png",
            "/Assets/electabuzz.png",
            "/Assets/jolteon.png",
            "/Assets/mareep.png",
            "/Assets/mareep-shiny.png",
            "/Assets/flaaffy.png",
            "/Assets/ampharos.png",
            "/Assets/luxio.png",
            "/Assets/luxray.png",
            "/Assets/pachirisu.png",
            "/Assets/shinx.png",
            "/Assets/magnemite.png",
            "/Assets/magneton.png",
            "/Assets/magnezone.png",
            "/Assets/minun.png",
            "/Assets/plusle.png",
        };

        private static readonly List<string> _normalTypeImages = new List<string>
        {
            "/Assets/rattata.png",
            "/Assets/meowth.png",
            "/Assets/persian.png",
            "/Assets/eevee.png",
            "/Assets/bidoof.png",
            "/Assets/ditto.png",
            "/Assets/dunsparce.png",
            "/Assets/furret.png",
            "/Assets/sentret.png",
            "/Assets/lickitung.png",
            "/Assets/regigigas.png",
            "/Assets/teddiursa.png",
            "/Assets/teddiursa-shiny.png",
            "/Assets/ursaring.png",
            "/Assets/kangaskhan.png",
            "/Assets/chansey.png",
            "/Assets/blissey.png",
            "/Assets/happiny.png",
            "/Assets/porygon.png",
            "/Assets/snorlax.png",
            "/Assets/munchlax.png",
            "/Assets/zangoose.png",
        };

    }
}