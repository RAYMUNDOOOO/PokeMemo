using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using PokeMemo.Models;
using PokeMemo.Utility;

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
            }
        }

        private string? _category;

        public string? Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }

        private bool _isNameEmpty;
        public bool IsNameEmpty
        {
            get => _isNameEmpty;
            set
            {
                _isNameEmpty = value;
            }
        }
        
        private bool _isCategoryEmpty;

        public bool IsCategoryEmpty
        {
            get => _isCategoryEmpty;
            set
            {
                _isCategoryEmpty = value;
            }
        }

        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }

        public CreateDeckViewModel()
        {
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
            NavigateToCreateCardViewCommand = new RelayCommand(o => NavigateToCreateCardView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            /* Add a new card to the currently selected deck */
            var backgroundColour = CurrentDeck?.BackgroundColour ?? "#FFFFFF";
            var foregroundColour = CurrentDeck?.ForegroundColour ?? "#000000";
            var borderColour = CurrentDeck?.BorderColour ?? "#000000";
            var imagePath = ImageHelper.GetImageByType(CurrentDeck?.Type);

            CurrentDeck?.AddCard(new Card(Name, Category, backgroundColour, foregroundColour, borderColour, imagePath));

            /* Refresh the fields and update the corresponding view */
            Name = string.Empty;
            Category = string.Empty;
            IsNameEmpty = false;
            IsCategoryEmpty = false;
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
    }
}