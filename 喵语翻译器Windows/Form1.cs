using System;
using System.Windows.Forms;
using 喵语翻译器;

namespace 喵语翻译器Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{ textBox2.Text = 喵.喵喵Encode(textBox1.Text); }
            catch { textBox2.Text = "出现错误喵"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { textBox1.Text = 喵.喵喵Decode(textBox2.Text); }
            catch { textBox1.Text = "出现错误喵"; }
        }
    }
}
