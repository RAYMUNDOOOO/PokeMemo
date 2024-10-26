using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Models;
using PokeMemo.Utility;

namespace PokeMemo.ViewModels
{
    // This ViewModel is responsible for handling the logic of the Quiz Results view.
    public partial class QuizResultsViewModel : ViewModelBase
    {
        // The DeckLibrary instance is initialized with the DataService's DeckLibrary instance
        private DeckLibrary DeckLibrary { get; }

        // The Score and TotalCards properties are used to display the user's score and the total number of cards in the quiz
        public int Score => DeckLibrary.CurrentQuiz.Score;
        public int TotalCards => DeckLibrary.CurrentQuiz.TotalCards;

        // The above values are then used to generate the ScoreText and ResultText properties
        public string ScoreText => $"You scored {Score} out of {TotalCards}!";
        public string ResultText => GetResultMessage(Score, TotalCards);

        // The BackgroundImage property is used to display an image based on the user's score
        private Bitmap? _backgroundImage;
        public Bitmap? BackgroundImage
        {
            get => _backgroundImage;
            set
            {
                if (_backgroundImage != value)
                {
                    _backgroundImage = value;
                    OnPropertyChanged(nameof(BackgroundImage));
                }
            }
        }

        // The NavigateToDeckLibraryViewCommand is used to navigate back to the DeckLibrary view
        public ICommand NavigateToDeckLibraryViewCommand { get; }

        public QuizResultsViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
        }

        // The GetResultMessage method is used to generate a message based on the user's score
        // It uses the ratio of the score to the total number of cards to determine the message
        // It also sets the BackgroundImage property based on the user's score
        public string GetResultMessage(int score, int totalCards)
        {
            if (score == totalCards)
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/regigigas-big.png");
                return "Perfect score! You're a Pokémon Master!";
            }
            else if (score == totalCards -1)
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/gyarados-red.png");
                return "So close! You were just one card away from being a Pokémon champion!";
            }
            else if (score >= totalCards * 0.75)
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/ivysaur-big.png");
                return "Great job! You're evolving like a Bulbasaur into Ivysaur!";
            }
            else if (score >= totalCards * 0.5)
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/snorlax-big.png");
                return "Not bad at all! You're on your way to catching 'em all!";
            }
            else if (score >= totalCards * 0.25)
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/magikarp-big.png");
                return "Keep trying! Even Magikarp becomes a Gyrados with enough effort!";
            }
            else
            {
                BackgroundImage = ImageHelper.LoadFromResource("/Assets/dunsparce-big.png");
                return "Don't give up! Remember, even Ash lost his first battle!";
            }
        }

        // The NavigateToDeckLibraryView method is used to navigate back to the DeckLibrary view
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }
    }
}