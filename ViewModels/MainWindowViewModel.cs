using System;
using ReactiveUI;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PokeMemo.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateDeckViewCommand { get; }
        public ICommand NavigateToQuizViewCommand { get;  }

        public MainWindowViewModel()
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
            NavigateToCreateDeckViewCommand = new RelayCommand(o => NavigateToCreateDeckView());
            NavigateToQuizViewCommand = new RelayCommand(o => NavigateToQuizView());
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToDeckLibraryView()
        {
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToCreateDeckView()
        {
            CurrentView = new CreateDeckViewModel();
        }

        private void NavigateToQuizView()
        {
            CurrentView = new QuizViewModel();
        }
    }
}