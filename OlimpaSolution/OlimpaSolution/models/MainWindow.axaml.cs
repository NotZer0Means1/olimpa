using Avalonia.Controls;
using OlimpaSolution.models;

namespace OlimpaSolution
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Content = new ParentControl();
            InitializeComponent();
        }
    }
}