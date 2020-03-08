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
        public MainPage()
        {
            InitializeComponent();
        }

        private void 变成喵(object sender, EventArgs e)
        {
                if (sometext.Text == null) sometext.Text = "";
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
    }
}
