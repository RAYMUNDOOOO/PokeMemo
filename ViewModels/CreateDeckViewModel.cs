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
using CommunityToolkit.Mvvm.Input;

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
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
        }
        
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }
    }
}