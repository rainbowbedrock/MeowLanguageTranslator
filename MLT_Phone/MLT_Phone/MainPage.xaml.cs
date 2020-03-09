using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using 喵语翻译器;
using Xamarin.Essentials;

namespace MLT_Phone
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "喵语翻译器";
            sometext.Text = "";
            meow.Text = "";
            string cb= Clipboard.GetTextAsync().Result;
            if (cb.StartsWith("喵")) meow.Text = cb;
        }

        private void 变成喵(object sender, EventArgs e)
        {
                meow.Text = 喵.喵喵Encode(sometext.Text);
        }
        private void 变成字(object sender, EventArgs e)
        {
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
            Clipboard.SetTextAsync(sometext.Text);
        }
        private void 复制喵(object sender, EventArgs e)
        {
            Clipboard.SetTextAsync(meow.Text);
        }
        private void 粘贴字(object sender, EventArgs e)
        {
            sometext.Text = Clipboard.GetTextAsync().Result;
        }
        private void 粘贴喵(object sender, EventArgs e)
        {
            meow.Text = Clipboard.GetTextAsync().Result;
        }

        private void 关于(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage()).Wait();
        }
    }
}
