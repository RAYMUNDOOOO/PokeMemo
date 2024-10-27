using PokeMemo.Models;

namespace PokeMemo.Utility
{
    // The DataService class is a singleton class that provides access to the DeckLibrary instance.
    // This class is used to ensure that only one instance of the DeckLibrary is created and shared across the application.
    public class DataService
    {
        private static DataService? _instance;
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