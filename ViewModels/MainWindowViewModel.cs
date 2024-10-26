using System;
using ReactiveUI;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Models;

namespace PokeMemo.ViewModels
{
    // This ViewModel is responsible for handling the logic of the Main Window.
    // The Main Window connects with the Views to display the correct view based on the user's actions.
    public partial class MainWindowViewModel : ObservableObject
    {
        // The CurrentView property is used to bind the current view to the Main Window.
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        // The following commands are used to navigate to different views.
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

        // The following methods are used to navigate to different views.
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