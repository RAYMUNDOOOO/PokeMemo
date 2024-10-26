using Avalonia.Controls.ApplicationLifetimes;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Utility;
using PokeMemo.Models;

namespace PokeMemo.ViewModels
{
    // This ViewModel is responsible for handling the logic of the CreateDeck view.
    public partial class CreateDeckViewModel : ViewModelBase
    {
        // The DeckLibrary instance is initialized with the DataService's DeckLibrary instance
        public DeckLibrary DeckLibrary { get; }

        public Deck? CurrentDeck { get; }

        private Deck? _deckToBeModified;

        /*
         * Fields used for the creation of a deck; generating the deck preview
         * and determining which controls are visible
         */
        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string? _category;
        public string? Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private bool _isNameEmpty;
        public bool IsNameEmpty
        {
            get => _isNameEmpty;
            set
            {
                _isNameEmpty = value;
                OnPropertyChanged();
            }
        }

        private bool _isCategoryEmpty;
        public bool IsCategoryEmpty
        {
            get => _isCategoryEmpty;
            set
            {
                _isCategoryEmpty = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeckTypeNotSelected;
        public bool IsDeckTypeNotSelected
        {
            get => _isDeckTypeNotSelected;
            set
            {
                _isDeckTypeNotSelected = value;
                OnPropertyChanged();
            }
        }

        /*
         * Setting up view navigation by creating RelayCommands that call on functions
         * that update the CurrentViewModel in MainWindowViewModel
         */
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }

        public ICommand SaveDeckAndExitCommand { get; }
        
        /*
         * Initialise the view with empty fields to create a new deck and
         * set the content of the button to indicate to the user that they
         * are creating a new deck, adding it to the deck library and then
         * exiting.
         */
        public CreateDeckViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToCreateCardViewCommand = new RelayCommand(NavigateToCreateCardView);
            SaveDeckAndExitCommand = new RelayCommand(SaveDeckAndExit);
        }

        /*
         * If there is a deck to be modified, set this and the corresponding fields
         * in the view to its existing Question and Answer fields. This will also
         * set the button to indicate to the user that they're modifying an existing
         * deck and then exiting.
         */
        public CreateDeckViewModel(Deck? deckToBeModified)
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            SaveDeckAndExitCommand = new RelayCommand(SaveDeckAndExit);

            _deckToBeModified = deckToBeModified;
            Name = deckToBeModified?.Name;
            Category = deckToBeModified?.Category;
        }

        // Navigation functions
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToCreateCardView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
        }

        // Depending on whether the user is creating a new deck or modifying an existing one
        // This function will either save the modifications to the deck and return to the deck library
        // Or create a new deck and navigate to the create card view
        private void SaveDeckAndExit()
        {
            if (_deckToBeModified != null)
            {
                if (CheckIfFieldsAreValid())
                {
                    _deckToBeModified.Name = Name;
                    _deckToBeModified.Category = Category;
                    NavigateToDeckLibraryView();
                    return;
                }
            }

            if (CheckIfFieldsAreValid())
            {
                CreateDeckAndRefreshFields();
                NavigateToCreateCardView();
            }
        }

        // This function checks if the user has input data in the fields and 
        // selected a theme for the deck before returning true
        private bool CheckIfFieldsAreValid()
        {
            /* Return if either the name or category field is empty */
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsCategoryEmpty = string.IsNullOrEmpty(Category);
            // IsDeckTypeNotSelected = DeckLibrary.SelectedType == null;

            if (IsNameEmpty || IsCategoryEmpty || IsDeckTypeNotSelected) return false;

            return true;
        }

        // This function creates a new deck and adds it to the deck library
        // It also refreshes the fields in the view
        private void CreateDeckAndRefreshFields()
        {
            if (DeckLibrary.SelectedType != null)
            {
                var newDeck = new Deck(Name, Category, DeckLibrary.SelectedType);
                DeckLibrary.Decks.Add(newDeck);
                DeckLibrary.SelectedDeck = newDeck;

                /* Refresh the fields and update the corresponding view */
                Name = string.Empty;
                Category = string.Empty;
                IsNameEmpty = false;
                IsCategoryEmpty = false;
            } 
        }
    }
}