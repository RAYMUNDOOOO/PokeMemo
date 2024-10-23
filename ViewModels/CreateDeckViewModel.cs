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
        public Deck CurrentDeck { get; }
        
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

        /*
         * Setting up view navigation by creating RelayCommands that call on functions
         * that update the CurrentViewModel in MainWindowViewModel
         */
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }

        public CreateDeckViewModel()
        {
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToCreateCardViewCommand = new RelayCommand(NavigateToCreateCardView);
        }
        
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }
        
        private void NavigateToCreateCardView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
            
            CheckIfFieldsAreValid();
            CreateDeckAndRefreshFields();
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
            string type = "grass";
            
            var typeName = ImageHelper.PokemonTypes[type.ToLower()];
            
            DataService.Instance.DeckLibrary.Decks.Add(new Deck(Name, Category, typeName));
            
            /* Refresh the fields and update the corresponding view */
            Name = string.Empty;
            Category = string.Empty;
            IsNameEmpty = false;
            IsCategoryEmpty = false;
        }
    }
}