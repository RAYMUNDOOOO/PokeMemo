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
    public partial class QuizViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        private List<Card> _shuffledCards;
        private int _currentCardIndex;

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

        public ICommand DontRememberCommand { get; }
        public ICommand RememberCommand { get; }
        public ICommand RevealAnswerCommand { get; }

        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToQuizResultsViewCommand { get; }

        public QuizViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;

            if (DeckLibrary.SelectedDeck == null)
            {
                NavigateToDeckLibraryView();
                return;
            }

            StartNewQuiz();

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

        private void StartNewQuiz()
        {
            DeckLibrary.CurrentQuiz = new Quiz(DeckLibrary.SelectedDeck.Cards.Count);
            OnPropertyChanged(nameof(DeckLibrary.CurrentQuiz));
        }

        private void DontRememberCard()
        {
            NextCard();
        }

        private void RememberCard()
        {
            DeckLibrary.CurrentQuiz.Score++;
            NextCard();
        }

        private void RevealAnswer()
        {
            CurrentCardText = CurrentCard.Answer;
        }

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
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToQuizResultsView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToQuizResultsViewCommand.Execute(null);
        }
    }
}
