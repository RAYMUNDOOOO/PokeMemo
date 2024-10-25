using Avalonia.Controls.ApplicationLifetimes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Utility;
using PokeMemo.Models;

namespace PokeMemo.ViewModels
{
    public partial class CreateDeckViewModel : ViewModelBase
    {
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

        private string? _type;
        public string? Type
        {
            get => _type;
            set
            {
                _type = value;
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

        private string _leftButtonText;
        public string LeftButtonText
        {
            get => _leftButtonText;
            set
            {
                _leftButtonText = value;
                OnPropertyChanged();
            }
        }

        /*
         * Setting up view navigation by creating RelayCommands that call on functions
         * that update the CurrentViewModel in MainWindowViewModel
         */
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }
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

            LeftButtonText = "Save deck and exit";
        }

        /*
         * If there is a card to be modified, set this and the corresponding fields
         * in the view to its existing Question and Answer fields. This will also
         * set the button to indicate to the user that they're modifying an existing
         * card and then exiting.
         */
        public CreateDeckViewModel(Deck? deckToBeModified)
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            //SaveDeckAndExitCommand = new RelayCommand(SaveDeckAndExit);

            _deckToBeModified = deckToBeModified;
            Name = deckToBeModified?.Name;
            Category = deckToBeModified?.Category;
            LeftButtonText = "Modify deck and exit";
        }

        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToCreateCardView()
        {
            CheckIfFieldsAreValid();
            CreateDeckAndRefreshFields();

            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
        }

        private void SaveDeckAndExit()
        {
            if (_deckToBeModified != null)
            {
                _deckToBeModified.Name = Name;
                _deckToBeModified.Category = Category;
                NavigateToDeckLibraryView();
                return;
            }

            if (CheckIfFieldsAreValid())
            {
                CreateDeckAndRefreshFields();
                NavigateToDeckLibraryView();
            }
        }

        private bool CheckIfFieldsAreValid()
        {
            /* Return if either the name or category field is empty */
            IsNameEmpty = string.IsNullOrEmpty(Name);
            IsCategoryEmpty = string.IsNullOrEmpty(Category);

            if (IsNameEmpty || IsCategoryEmpty) return false;

            return true;
        }

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