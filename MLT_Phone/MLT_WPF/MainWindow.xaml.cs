using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: Dependency(typeof(MLT_WPF.Clipboard))]
namespace MLT_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            LoadApplication(new MLT_Phone.App());
            
        }
    }
    public class Clipboard:MLT_Phone.IClipboard
    {
        public string GetText() => System.Windows.Clipboard.GetText();
        public void SetText(string text) => System.Windows.Clipboard.SetText(text);
    }
    
}
