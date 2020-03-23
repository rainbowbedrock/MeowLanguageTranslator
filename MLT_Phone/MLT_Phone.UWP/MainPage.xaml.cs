using Xamarin.Forms;
using Windows.System;
using System;

[assembly: Dependency(typeof(MLT_Phone.UWP.MainPage.Helper))]
namespace MLT_Phone.UWP
{
    public sealed partial class MainPage
    {
        static MainPage instance;
        public MainPage()
        {
            InitializeComponent();
            instance = this;
            LoadApplication(new MLT_Phone.App());
        }
        public void OpenURL(string url) => Launcher.LaunchUriAsync(new Uri(url));
        public class Helper : IHelper
        {
            public void OpenURL(string url) => instance.OpenURL(url);
        }
    }


}
