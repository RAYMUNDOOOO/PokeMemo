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
        public ICommand NavigateToQuizViewCommand { get; }
        public ICommand NavigateToPreviewDeckViewCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibrary());
            NavigateToCreateDeckViewCommand = new RelayCommand(o => NavigateToCreateDeckView());
            NavigateToQuizViewCommand = new RelayCommand(o => NavigateToQuizView());
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToDeckLibrary()
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
        private void NavigateToPreviewDeckView()
        {
            CurrentView = new PreviewDeckViewModel();
        }
    }
}