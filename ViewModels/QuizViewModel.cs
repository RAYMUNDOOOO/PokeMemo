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

namespace PokeMemo.ViewModels
{
    public partial class QuizViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        private List<Card> _shuffledCards;
        private int _currentCardIndex;
        private bool _showAnswer;
        public Card CurrentCard { get; set; }
        public string DisplayText => _showAnswer ? CurrentCard.Answer : CurrentCard.Question;

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
            _showAnswer = false;
            CurrentCard = _shuffledCards[_currentCardIndex];

            DontRememberCommand = new RelayCommand(o => ShowAnswer());
            RememberCommand = new RelayCommand(o => RememberCard());
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
            NavigateToQuizResultsViewCommand = new RelayCommand(o => NavigateToQuizResultsView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(CurrentCard))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        private void StartNewQuiz()
        {
            DeckLibrary.CurrentQuiz = new Quiz();
            OnPropertyChanged(nameof(DeckLibrary.CurrentQuiz));
        }

        private void ShowAnswer()
        {
            _showAnswer = true;
            OnPropertyChanged(nameof(CurrentCard));
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
                _showAnswer = false;
                OnPropertyChanged(nameof(CurrentCard));
                OnPropertyChanged(nameof(DisplayText));

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
