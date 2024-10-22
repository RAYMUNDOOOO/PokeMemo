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
    public partial class QuizResultsViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }

        public int Score => DeckLibrary.CurrentQuiz.Score;
        public int TotalCards => DeckLibrary.CurrentQuiz.TotalCards;

        public string ScoreText => $"You scored {Score} out of {TotalCards}!";

        public string ResultText => GetResultMessage(Score, TotalCards);
        public ICommand NavigateToDeckLibraryViewCommand { get; }

        public QuizResultsViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetResultMessage(int score, int totalCards)
        {
            if (score == totalCards)
            {
                return "Perfect score! You're a Pokémon Master!";
            }
            else if (score == totalCards -1)
            {
                return "So close! You were just one card away from being a Pokémon champion!";
            }
            else if (score >= totalCards * 0.75)
            {
                return "Great job! You're evolving like a Bulbasaur into Ivysaur!";
            }
            else if (score >= totalCards * 0.5)
            {
                return "Not bad at all! You're on your way to catching 'em all!";
            }
            else if (score >= totalCards * 0.25)
            {
                return "Keep trying! Even Magikarp becomes a Gyrados with enough effort!";
            }
            else
            {
                return "Don't give up! Remember, even Ash lost his first battle!";
            }
        }
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }
    }
}