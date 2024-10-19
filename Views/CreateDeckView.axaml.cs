using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class CreateDeckView : UserControl
{
    public CreateDeckView()
    {
        InitializeComponent();
        DataContext = new CreateDeckViewModel();
    }
}