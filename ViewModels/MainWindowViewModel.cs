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
        public ICommand NavigateToAddDeckViewCommand { get; }

        public ICommand NavigateToPreviewDeckViewCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibrary());
            NavigateToAddDeckViewCommand = new RelayCommand(o => NavigateToAddDeckView());
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToDeckLibrary()
        {
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToAddDeckView()
        {
            CurrentView = new AddDeckViewModel();
        }
        private void NavigateToPreviewDeckView()
        {
            CurrentView = new PreviewDeckViewModel();
        }
    }
}