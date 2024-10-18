using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class QuizView : UserControl
{
    public QuizView()
    {
        InitializeComponent();
        DataContext = new QuizViewModel();
    }
}