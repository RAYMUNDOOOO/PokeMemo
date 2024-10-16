using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Models
{
    public class DeckLibrary
    {
        public List<Deck> Decks { get; set; }

        public DeckLibrary()
        {
            Decks = new List<Deck>();
        }
    }
}
