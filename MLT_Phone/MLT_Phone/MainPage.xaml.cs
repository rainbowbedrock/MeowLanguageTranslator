using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using 喵语翻译器;

namespace MLT_Phone
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        internal IClipboard MyClipboard;
        public MainPage()
        {
            InitializeComponent();
            Title = "喵语翻译器";
            sometext.Text = "";
            meow.Text = "";
            if (Device.RuntimePlatform == Device.WPF)
                MyClipboard = DependencyService.Get<IClipboard>();
            else MyClipboard = new Clipboard();
        }

        private void 变成喵(object sender, EventArgs e)
        {
            if (sometext.Text == "")
            {
                DisplayAlert("喵", "你要先输入一些字喵(｡･ω･｡)", "喵");
                return;
            }
            meow.Text = 喵.喵喵Encode(sometext.Text);
        }

        private void 喵喵套娃(object sender, EventArgs e)
        {
            DisplayPromptAsync("喵喵套娃", "你想要套多少呢", "开始套娃", "不要", "套娃最小长度", 4, Keyboard.Numeric, "1000");
            string cat= 喵.喵喵Encode(sometext.Text);
            while (cat.Length < 1000)
            {
                cat = 喵.喵喵Encode(cat);
            }
            meow.Text = cat;
        }

        private void 变成字(object sender, EventArgs e)
        {
            if (sometext.Text == "")
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
                sometext.Text = "出现错误！喵喵格式不正确！" + ex.Message;
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

        private void 关于(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
    public class Clipboard : IClipboard
    {
        public string GetText() => Xamarin.Essentials.Clipboard.GetTextAsync().Result;
        public void SetText(string text) => Xamarin.Essentials.Clipboard.SetTextAsync(text).Wait();
    }
    public interface IClipboard
    {
        string GetText();
        void SetText(string text);
    }
}
