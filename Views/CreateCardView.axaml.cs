using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class CreateCardView : Window
{
    public CreateCardView()
    {
        InitializeComponent();
        DataContext = new CreateCardViewModel();
    }
}