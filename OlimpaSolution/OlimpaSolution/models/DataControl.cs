using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Linq;

namespace OlimpaSolution.models;

public partial class DataControl : UserControl
{
    private readonly Image _mapImage;
    private readonly Grid _gridDiagrams;
    private static readonly string SourcePath = App.Path + "images/";
    public DataControl()
    {
        
        InitializeComponent();
        _gridDiagrams = this.Find<Grid>("GridListBox");
        _mapImage = this.Find<Image>("MapImage");

    }

    public void LoadMapImage()
    {
        _mapImage.Source = new Bitmap(SourcePath + "map.png");
    }

    public void LoadDiagrams()
    {
        int i = 0;
        foreach (var filename in Directory.GetFiles(SourcePath))
        {
            if (!filename.Equals(SourcePath + "map.png"))
            {
                var img = new Image() {Source = new Bitmap(filename) };
                _gridDiagrams.Children.Add(img);
                Grid.SetColumn(img, i++);
            }
        }
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}