using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class QuizResultsView : UserControl
{
    public QuizResultsView()
    {
        InitializeComponent();
        DataContext = new QuizResultsViewModel();
    }
}