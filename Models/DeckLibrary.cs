using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Models
{
    public class DeckLibrary : ObservableObject
    {
        public List<Deck> Decks { get; set; }

        private Deck _selectedDeck;
        public Deck? SelectedDeck 
        { 
            get => _selectedDeck;
            set => SetProperty(ref _selectedDeck, value);
        }

        public DeckLibrary()
        {
            Decks = new List<Deck>
                {
                    new Deck("Multiplication Deck", "Maths", "#87BBF1", "Black", "#4D91D7", "/Assets/water-type.png"),
                    new Deck("Addition Deck", "Maths", "#94D88D", "Black", "#61BB59", "/Assets/grass-type.png")
                };

            var multiplicationDeck = Decks.FirstOrDefault(d => d.Name == "Multiplication Deck");
            multiplicationDeck.Cards.Add(new Card("What is 1 x 1?", "1", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 2?", "2", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 3?", "3", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 4?", "4", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 5?", "5", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 6?", "6", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 7?", "7", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 8?", "8", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));
            multiplicationDeck.Cards.Add(new Card("What is 1 x 9?", "9", "#87BBF1", "Black", "#4D91D7", "/Assets/squirtle.png"));

            var additionDeck = Decks.FirstOrDefault(d => d.Name == "Addition Deck");
            additionDeck.Cards.Add(new Card("What is 1 + 1?", "2", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 2 + 2?", "4", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 3 + 3?", "6", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 4 + 4?", "8", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 5 + 5?", "10", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 6 + 6?", "12", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 7 + 7?", "14", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 8 + 8?", "16", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));
            additionDeck.Cards.Add(new Card("What is 9 + 9?", "18", "#94D88D", "Black", "#61BB59", "/Assets/bulbasaur.png"));

            SelectedDeck = null;
        }
    }
}

