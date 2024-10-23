using PokeMemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Utility
{
    public class DataService
    {
        private static DataService _instance;
        public static DataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataService();
                }
                return _instance;
            }
        }

        public DeckLibrary DeckLibrary { get; }

        public DataService() {
            DeckLibrary = new DeckLibrary();
        }
    }
}
