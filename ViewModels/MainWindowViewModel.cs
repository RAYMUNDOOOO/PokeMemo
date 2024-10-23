using System;
using ReactiveUI;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Models;

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
        public ICommand NavigateToPreviewDeckViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }
        public ICommand NavigateToQuizViewCommand { get; }
        public ICommand NavigateToQuizResultsViewCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibrary);
            NavigateToCreateDeckViewCommand = new RelayCommand(NavigateToCreateDeckView);
            NavigateToPreviewDeckViewCommand = new RelayCommand(NavigateToPreviewDeckView);
            NavigateToCreateCardViewCommand = new RelayCommand<Card>(NavigateToCreateCardView);
            NavigateToQuizViewCommand = new RelayCommand(NavigateToQuizView);
            NavigateToQuizResultsViewCommand = new RelayCommand(NavigateToQuizResultsView);
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
        private void NavigateToPreviewDeckView()
        {
            CurrentView = new PreviewDeckViewModel();
        }

        /*
         * If we have received a selectedCard, lets move to the CreateCardView with the
         * Question and Answer fields pre-filled with the selected card's question and answer.
         */
        private void NavigateToCreateCardView(Card? selectedCard)
        {
            if (selectedCard == null)
            {
                CurrentView = new CreateCardViewModel();
            }
            else
            {
                CurrentView = new CreateCardViewModel(selectedCard);
            }
        }
        private void NavigateToQuizView()
        {
            CurrentView = new QuizViewModel();
        }
        private void NavigateToQuizResultsView()
        {
            CurrentView = new QuizResultsViewModel();
        }
    }
}