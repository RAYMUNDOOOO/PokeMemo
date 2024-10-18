using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class PreviewDeckView : UserControl
{
    public PreviewDeckView()
    {
        InitializeComponent();
        DataContext = new PreviewDeckViewModel();
    }
}