using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Models;
using PokeMemo.Utility;

namespace PokeMemo.ViewModels
{
    // This ViewModel is responsible for handling the logic of the Quiz view.
    public partial class QuizViewModel : ViewModelBase
    {
        // The DeckLibrary instance is initialized with the DataService's DeckLibrary instance
        private DeckLibrary DeckLibrary { get; }

        // The shuffled cards are stored in a list, and the current card index is used to keep track of the current card
        private List<Card> _shuffledCards;
        private int _currentCardIndex;

        // The current card text is used to display the question or answer of the current card
        private string? _currentCardText;
        public string? CurrentCardText
        {
            get => _currentCardText;
            set
            {
                _currentCardText = value;
                OnPropertyChanged(nameof(CurrentCardText));
            }
        }

        // The current card is used to store the current card object
        private Card _currentCard;
        public Card CurrentCard
        {
            get => _currentCard;
            set
            {
                _currentCard = value;
                OnPropertyChanged(nameof(CurrentCard));
            }
        }

        // Commands to handle the quiz logic
        public ICommand DontRememberCommand { get; }
        public ICommand RememberCommand { get; }
        public ICommand RevealAnswerCommand { get; }

        // Commands to navigate to other views
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToQuizResultsViewCommand { get; }

        public QuizViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;

            // If no deck is selected, navigate back to the DeckLibrary view
            if (DeckLibrary.SelectedDeck == null)
            {
                NavigateToDeckLibraryView();
                return;
            }

            StartNewQuiz();

            // Shuffles the cards in the selected deck and sets the current card to the first card
            _shuffledCards = DeckLibrary.SelectedDeck?.Cards.OrderBy(c => Guid.NewGuid()).ToList();
            _currentCardIndex = 0;
            CurrentCard = _shuffledCards[_currentCardIndex];
            CurrentCardText = CurrentCard.Question;

            DontRememberCommand = new RelayCommand(DontRememberCard);
            RememberCommand = new RelayCommand(RememberCard);
            RevealAnswerCommand = new RelayCommand(RevealAnswer);
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToQuizResultsViewCommand = new RelayCommand(NavigateToQuizResultsView);
        }

        // The Start New Quiz method is used to create a new quiz instance and set it to the DeckLibrary's CurrentQuiz property
        private void StartNewQuiz()
        {
            DeckLibrary.CurrentQuiz = new Quiz(DeckLibrary.SelectedDeck.Cards.Count);
            OnPropertyChanged(nameof(DeckLibrary.CurrentQuiz));
        }

        // The Don't Remember method is used to move to the next card without incrementing the score
        private void DontRememberCard()
        {
            NextCard();
        }

        // The Remember method is used to increment the score and move to the next card
        private void RememberCard()
        {
            DeckLibrary.CurrentQuiz.Score++;
            NextCard();
        }

        // The Reveal Answer method is used to change the text on the current card to the answer rather than the question
        private void RevealAnswer()
        {
            CurrentCardText = CurrentCard.Answer;
        }

        // The Next Card method iterates through the shuffled cards and sets the current card to the next card
        // If there are no more cards, the user is navigated to the Quiz Results view
        private void NextCard()
        {
            if (_currentCardIndex < _shuffledCards.Count - 1)
            {
                _currentCardIndex++;
                CurrentCard = _shuffledCards[_currentCardIndex];
                CurrentCardText = CurrentCard.Question;
            }
            else
            {
                NavigateToQuizResultsView();
            }
        }

        // The following methods are used to navigate to other views
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToQuizResultsView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToQuizResultsViewCommand.Execute(null);
        }
    }
}