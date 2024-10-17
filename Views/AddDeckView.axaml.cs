using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class AddDeckView : UserControl
{
    public AddDeckView()
    {
        InitializeComponent();
        DataContext = new AddDeckViewModel();
    }
}