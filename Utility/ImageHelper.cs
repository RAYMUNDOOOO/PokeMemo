using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace PokeMemo.Utility
{
    public static class ImageHelper
    {
        public static Bitmap LoadFromResource(string path)
        {
            var uri = new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}{path}");
            return new Bitmap(AssetLoader.Open(uri));
        }
    }
}