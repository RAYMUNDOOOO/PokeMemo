using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Models;
using PokeMemo.Utility;
using ReactiveUI;

namespace PokeMemo.ViewModels
{
    public partial class QuizViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        private List<Card> _shuffledCards;
        private int _currentCardIndex;
        public Card CurrentCard { get; set; }

        public ICommand DontRememberCommand { get; }
        public ICommand RememberCommand { get; }

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

            DontRememberCommand = new RelayCommand(o => DontRememberCard());
            RememberCommand = new RelayCommand(o => RememberCard());
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
            NavigateToQuizResultsViewCommand = new RelayCommand(o => NavigateToQuizResultsView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void NextCard()
        {
            if (_currentCardIndex < _shuffledCards.Count - 1)
            {
                _currentCardIndex++;
                CurrentCard = _shuffledCards[_currentCardIndex];
                OnPropertyChanged(nameof(CurrentCard));
                OnPropertyChanged(nameof(CurrentCard.Question));

                Console.WriteLine($"CurrentCard: {CurrentCard.Question}");
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