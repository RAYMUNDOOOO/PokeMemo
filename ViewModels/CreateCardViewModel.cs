using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace PokeMemo.ViewModels
{
    public class CreateCardViewModel : ViewModelBase
    {
        /* Used to create a new card and display contents in the card preview */
        public string? Question { get; set; }
        public string? Answer { get; set; }
    
        public ICommand NavigateToPreviewDeckViewCommand { get; }
        public ICommand CreateAndSaveNewCardCommand { get; }

        public CreateCardViewModel()
        {
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
            CreateAndSaveNewCardCommand = new RelayCommand(o => CreateAndSaveNewCard());
        }

        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

        private void CreateAndSaveNewCard()
        {
            
        }
    }
}
