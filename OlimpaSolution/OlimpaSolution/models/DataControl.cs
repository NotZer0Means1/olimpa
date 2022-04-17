using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Linq;

namespace OlimpaSolution.models;

public partial class DataControl : UserControl
{
    private Image MapImage;
    private ListBox DiagramsListBox;
    private static readonly string SourcePath = App.Path + "source/";
    public DataControl()
    {
        MapImage = this.Find<Image>("MapImage");
        DiagramsListBox = this.Find<ListBox>("DiagramsListBox");

        InitializeComponent();
    }

    public void LoadMapImage()
    {
        MapImage.Source = new Bitmap(SourcePath + "map.png");
    }

    public void LoadDiagrams()
    {
        List<Image> diagrams = new List<Image>();
        foreach (var filename in Directory.GetFiles(SourcePath))
        {
            if (!filename.Equals("map.png"))
                diagrams.Add(new Image() {Source = new Bitmap(SourcePath + filename)});
            
        }

        var newCollection = DiagramsListBox.Items.Cast<Image>().ToList();
        newCollection.AddRange(diagrams);
        DiagramsListBox.Items = newCollection;
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}