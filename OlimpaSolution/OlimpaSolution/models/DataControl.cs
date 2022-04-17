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
    private readonly TextBox _a;
    private readonly TextBox _b;
    private static readonly string SourcePath = App.Path + "images/";
    public DataControl()
    {
        
        InitializeComponent();
        _gridDiagrams = this.Find<Grid>("GridListBox");
        _mapImage = this.Find<Image>("MapImage");
        _a = this.Find<TextBox>("A");
        _b = this.Find<TextBox>("B");

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

    public ((int, int), (int, int)) GetCoordinates()
    {
        var text1 = _a.Text.Split(' ');
        var text2 = _b.Text.Split(' ');
        return ((int.Parse(text1[0]), int.Parse(text1[1])), (int.Parse(text2[0]), int.Parse(text2[1])));
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}