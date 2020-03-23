using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using 喵语翻译器;
using LitJson;
using System.Net.Http;

namespace MLT_Phone
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const int 喵喵版本号 = 10;

        internal IClipboard MyClipboard;
        internal IHelper MyHelper;
        public MainPage()
        {
            InitializeComponent();
            Title = "喵语翻译器";
            sometext.Text = "";
            meow.Text = "";
            if (Device.RuntimePlatform == Device.WPF)
                MyClipboard = DependencyService.Get<IClipboard>();
            else MyClipboard = new Clipboard();
            if (Device.RuntimePlatform == Device.WPF)
                MyHelper = DependencyService.Get<IHelper>();
            else MyHelper = new Helper();
            检查更新();
        }

        private void 变成喵(object sender, EventArgs e)
        {
            if (sometext.Text.Length==0)
            {
                DisplayAlert("喵", "你要先输入一些字喵(｡･ω･｡)", "喵");
                return;
            }
            meow.Text = 喵.喵喵Encode(sometext.Text);
        }
        private void 喵喵套娃(object sender, EventArgs e)
        {
            if (sometext.Text.Length == 0)
            {
                DisplayAlert("喵", "你要先输入一些字喵(｡･ω･｡)", "喵");
                return;
            }
            DisplayActionSheet("喵喵套娃", "禁止套娃", null, "中杯", "大杯", "超大杯").ContinueWith((Task<string> task) =>
            {
            int CatLength = 0;
            switch (task.Result)
            {
                case "中杯":
                    CatLength = 100;
                    break;
                case "大杯":
                    CatLength = 500;
                    break;
                case "超大杯":
                    CatLength = 1000;
                    break;
                default:
                    return;
            }
            string cat = 喵.喵喵Encode(sometext.Text);
            while (cat.Length < CatLength)
            {
                cat = 喵.喵喵Encode(cat);
            }
            Device.BeginInvokeOnMainThread(() => meow.Text = cat);
                
            });
            
        }
        private void 变成字(object sender, EventArgs e)
        {
            if (meow.Text.Length==0)
            {
                DisplayAlert("喵", "你要先输入一些字喵(｡･ω･｡)", "喵");
                return;
            }
            try
            {
                sometext.Text = 喵.喵喵Decode(meow.Text);
            }
            catch(Exception ex)
            {
                DisplayAlert("喵喵出错了！", ex.Message, "喵");
            }
        }

        private void 复制字(object sender, EventArgs e)
        {
            MyClipboard.SetText(sometext.Text);
            DisplayAlert("复制字", "复制好啦喵", @"~\(≧▽≦)/~");
        }
        private void 复制喵(object sender, EventArgs e)
        {
            MyClipboard.SetText(meow.Text);
            DisplayAlert("复制喵", "复制好啦喵", @"~\(≧▽≦)/~");
        }
        private void 粘贴字(object sender, EventArgs e)
        {
            sometext.Text = MyClipboard.GetText();
        }
        private void 粘贴喵(object sender, EventArgs e)
        {
            meow.Text = MyClipboard.GetText();
        }

        private void 检查更新(bool manual = false)
        {
            var 上网喵喵 = new HttpClient();
            try
            {
                上网喵喵.GetStringAsync("https://guest314.win/MLT/update.json").ContinueWith((Task<string> task) =>
                {
                    var json = JsonMapper.ToObject(task.Result);
                    var 更新喵喵 = new 喵喵更新()
                    {
                        versionCode = Convert.ToInt32(json["versionCode"].ToString()),
                        versionName = json["versionName"].ToString(),
                        url = json["url"].ToString()
                    };
                    if (更新喵喵.versionCode >= 喵喵版本号)
                    {
                        Device.BeginInvokeOnMainThread(()=> { this.更新喵喵(更新喵喵); });
                    }
                    else if (manual)
                        Device.BeginInvokeOnMainThread(() => { DisplayAlert("更新喵喵！", "已经是最新版本啦！"+ 更新喵喵.versionCode, "喵"); });
                });
            }
            catch (Exception e) { if (manual) Device.BeginInvokeOnMainThread(() => { DisplayAlert("更新喵喵失败！", e.Message, "喵"); }); }
        }
        private void 更新喵喵(喵喵更新 喵)
        {
            DisplayAlert("发现更新！", 喵.versionName, "去更新喵", "不要更新").ContinueWith((Task<bool> 更新喵) =>
             {
             if (更新喵.Result) Device.BeginInvokeOnMainThread(() => MyHelper.OpenURL(喵.url));
            });
        }
        private class 喵喵更新
        {
            internal int versionCode;
            internal string versionName;
            internal string url;
        }
        private void 关于(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

    }
    public interface IClipboard
    {
        string GetText();
        void SetText(string text);
    }
    internal class Clipboard : IClipboard
    {
        public string GetText() => Xamarin.Essentials.Clipboard.GetTextAsync().Result;
        public void SetText(string text) => Xamarin.Essentials.Clipboard.SetTextAsync(text).Wait();
    }

    public interface IHelper

    {
        void OpenURL(string url);
    }
    internal class Helper : IHelper
    {
        public void OpenURL(string url)=> Xamarin.Essentials.Browser.OpenAsync(url);
    }
}
