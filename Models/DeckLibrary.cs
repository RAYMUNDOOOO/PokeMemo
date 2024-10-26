using CommunityToolkit.Mvvm.ComponentModel;
using PokeMemo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeMemo.Models
{
    // This class represents a Deck Library, which is used to store the Decks and list of PokemonTypes in the application.
    public partial class DeckLibrary : ObservableObject
    {
        // The Decks property is a list of Deck objects that represent the different decks available in the application.
        public List<Deck> Decks { get; set; }

        // The SelectedDeck property is used to store the currently selected deck in the application.
        // It is used by the PreviewDeck View, Quiz View, ModifyDeck View and CreateCard View to display / modify / add cards to the selected deck.
        private Deck? _selectedDeck;
        public Deck? SelectedDeck
        {
            get => _selectedDeck;
            set => SetProperty(ref _selectedDeck, value);
        }

        // The SelectedType property is used to store the currently selected PokemonType in the application.
        // It is selected in the CreateDeck View to determine the colours and image of the new Deck.
        private PokemonType? _selectedType;
        public PokemonType? SelectedType
        {
            get => _selectedType;
            set => SetProperty(ref _selectedType, value);
        }

        // The PokemonTypes property is a list of PokemonType objects that represent the different colours and images available for the decks.
        public List<PokemonType> PokemonTypes { get; set; }

        // The CurrentQuiz property is used to store the current Quiz object that is being played in the Quiz View.
        [ObservableProperty]
        private Quiz? _currentQuiz;

        public DeckLibrary()
        {
            // The list of PokemonTypes is initialized with the available types in the application.
            PokemonTypes = new List<PokemonType>
            {
                new PokemonType("Grass", "#94D88D", "Black", "#61BB59", "/Assets/grass-type.png"),
                new PokemonType("Fire", "#FFC9A1", "Black", "#FF9D55", "/Assets/fire-type.png"),
                new PokemonType("Water", "#87BBF1", "Black", "#4D91D7", "/Assets/water-type.png"),
                new PokemonType("Electric", "#FFEC94", "Black", "#F3D33C", "/Assets/electric-type.png"),
                new PokemonType("Normal", "#C4C4C4", "Black", "#A8A8A8", "/Assets/normal-type.png"),
            };

            // The list of Decks is initialized with some dummy data for testing and demonstration purposes.
            Decks = new List<Deck>
                {
                    CreateDeck("Multiplication Deck", "Maths", "Water"),
                    CreateDeck("Addition Deck", "Maths", "Electric"),
                    CreateDeck("Greetings Deck", "Spanish", "Fire"),
                    CreateDeck("Animals Deck", "Science", "Grass"),
                };

            var multDeck = Decks.FirstOrDefault(d => d.Name == "Multiplication Deck");
            multDeck?.Cards.Add(new Card("What is 1 x 1?", "1", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 2?", "2", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 3?", "3", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 4?", "4", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 5?", "5", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 6?", "6", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 7?", "7", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 8?", "8", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));
            multDeck?.Cards.Add(new Card("What is 1 x 9?", "9", multDeck.BackgroundColour, multDeck.ForegroundColour, multDeck.BorderColour, ImageHelper.GetImageByType(multDeck.Type)));

            var addnDeck = Decks.FirstOrDefault(d => d.Name == "Addition Deck");
            addnDeck?.Cards.Add(new Card("What is 1 + 1?", "2", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 2 + 2?", "4", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 3 + 3?", "6", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 4 + 4?", "8", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 5 + 5?", "10", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 6 + 6?", "12", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 7 + 7?", "14", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 8 + 8?", "16", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));
            addnDeck?.Cards.Add(new Card("What is 9 + 9?", "18", addnDeck.BackgroundColour, addnDeck.ForegroundColour, addnDeck.BorderColour, ImageHelper.GetImageByType(addnDeck.Type)));

            var greetDeck = Decks.FirstOrDefault(d => d.Name == "Greetings Deck");
            greetDeck?.Cards.Add(new Card("Hello", "Hola", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Goodbye", "Adiós", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Please", "Por favor", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Thank you", "Gracias", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("You're welcome", "De nada", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Excuse me", "Perdón", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Yes", "Sí", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("No", "No", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("I'm sorry", "Lo siento", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Good morning", "Buenos días", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Good afternoon", "Buenas tardes", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));
            greetDeck?.Cards.Add(new Card("Good evening", "Buenas noches", greetDeck.BackgroundColour, greetDeck.ForegroundColour, greetDeck.BorderColour, ImageHelper.GetImageByType(greetDeck.Type)));

            var animalDeck = Decks.FirstOrDefault(d => d.Name == "Animals Deck");
            animalDeck?.Cards.Add(new Card("What is the largest mammal in the world?", "Blue whale", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the fastest land animal?", "Cheetah", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the largest bird of prey?", "Andean condor", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("Which animal can change colour for camouflage?", "Chameleon", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the largest land animal?", "African elephant", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("How do bats navigate in the dark?", "Echolocation", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("Which bird has the largest wingspan?", "Wandering albatross", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the smallest mammal in the world?", "Bumblebee bat", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the primary diet of pandas?", "Bamboo", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("How many hearts does an octopus have?", "Three", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What organ allows fish to breathe underwater?", "Gills", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));
            animalDeck?.Cards.Add(new Card("What is the largest reptile in the world?", "Saltwater crocodile", animalDeck.BackgroundColour, animalDeck.ForegroundColour, animalDeck.BorderColour, ImageHelper.GetImageByType(animalDeck.Type)));

            SelectedDeck = null;
        }

        // The CreateDeck method is used to create a new Deck object with the specified name, category, and type.
        // It is only used internally in this class to set the dummy Decks above
        private Deck CreateDeck(string name, string category, string type)
        {
            // It converts the string type to a PokemonType object by finding the corresponding type in the PokemonTypes list.
            var typeName = PokemonTypes.First(t => t.Name.Equals(type, StringComparison.OrdinalIgnoreCase));
            return new Deck(name, category, typeName);
        }
    }
}