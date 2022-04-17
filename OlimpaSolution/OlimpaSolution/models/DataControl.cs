using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OlimpaSolution.models;

public partial class DataControl : UserControl
{
    public DataControl()
    {
        
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}