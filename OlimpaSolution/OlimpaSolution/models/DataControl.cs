using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OlimpaSolution.models;

public partial class DataControl : UserControl
{
    private TabItem _mapTab;
    private TabItem _diagramsTab;
    private TabItem _userAdditionTab;
    public DataControl()
    {
        _mapTab = this.Find<TabItem>("Map");
        _diagramsTab = this.Find<TabItem>("Diagrams");
        _userAdditionTab = this.Find<TabItem>("DataEnter");
        
        
        
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}