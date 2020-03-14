using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace MLT_Phone.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public static void Copy(string text) => Clipboard.SetText(text);
        public static string Paste() => Clipboard.GetText();
        public MainWindow()
        {
            InitializeComponent();
            Forms.Init();
            LoadApplication(new MLT_Phone.App());
        }
    }
}
