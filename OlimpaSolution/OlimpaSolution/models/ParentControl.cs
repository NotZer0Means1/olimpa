using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ExtremelySimpleLogger;
using OlimpaSolution.services;

namespace OlimpaSolution.models;

public partial class ParentControl : UserControl
{
    private static bool _proccessOnline = false;
    public static readonly string ScriptPath = App.Path + "script.sh";
    private readonly DataControl _dataControl;
    public ParentControl()
    {
        InitializeComponent();
        _dataControl = this.Find<DataControl>("DataControl");
    }

    private async Task<bool> RunScript(string script)
    {
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            UseShellExecute = false,
            Arguments = " " + script,
            RedirectStandardOutput = true
        };

        using Process process = Process.Start(start)!;
        using StreamReader reader = process.StandardOutput;
        string result = await reader.ReadToEndAsync();
        App.Logger.Log(LogLevel.Info, $"script wrote: {result}");

        return true;
    }
    private async void Call(object? sender, RoutedEventArgs args)
    {
        if (!_proccessOnline)
        {
            _proccessOnline = true;
            var res = await NetworkService.GetSensorsData();
            if (!res) App.Logger.Log(LogLevel.Error, "request failed");
            await RunScript(ScriptPath);
            _dataControl.LoadDiagrams();
            _dataControl.LoadMapImage();
            
            _proccessOnline = false;
        }
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}