using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExtremelySimpleLogger;

namespace OlimpaSolution
{
    public partial class App : Application
    {
        public static readonly string Path = $"/home/{Environment.UserName}/Documents/OlimpaData/";

        public static Logger Logger = new Logger()
        {
            Sinks = {new FileSink(Path + "/log.log", true)}
        }; 
        public override void Initialize()
        {
            Logger.Log(LogLevel.Info, $"begging new session on {DateTime.Now}");
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}