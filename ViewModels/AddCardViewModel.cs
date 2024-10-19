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

namespace PokeMemo.ViewModels;

public class AddCardViewModel
{
    public partial class AddCardViewModel : ViewModelBase
    {
        public ICommand NavigateToAddCardViewCommand { get; }

        public AddCardViewModel()
        {
            NavigateToAddCardViewCommand = new RelayCommand(o => NavigateToAddCardView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void NavigateToAddCardView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToAddCardViewCommand.Execute(null);
        }
    }
}