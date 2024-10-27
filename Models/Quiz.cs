using CommunityToolkit.Mvvm.ComponentModel;

namespace PokeMemo.Models
{
    // This class represents a Quiz object, which is used to keep track of the user's score and the total number of cards in a quiz.
    // It inherits from ObservableObject, which is part of the CommunityToolkit.Mvvm library.
    public class Quiz : ObservableObject
    {
        // The user's score in the quiz
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged();
                }
            }
        }

        // The total number of cards in the quiz
        private int _totalCards;
        public int TotalCards
        {
            get => _totalCards;
            set
            {
                if (_totalCards != value)
                {
                    _totalCards = value;
                    OnPropertyChanged();
                }
            }
        }

        // The constructor initializes the Quiz object with the total number of cards and sets the score to 0
        public Quiz(int totalCards)
        {
            Score = 0;
            TotalCards = totalCards;
        }
    }
}