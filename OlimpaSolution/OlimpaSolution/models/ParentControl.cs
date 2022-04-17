using System.Xml;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OlimpaSolution.models;

public partial class ParentControl : UserControl
{
    public ParentControl()
    {
        
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}