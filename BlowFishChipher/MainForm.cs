using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlowFishCS;

namespace BlowFishChipher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = radioButton2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BlowFish bf = new BlowFish(Encoding.Default.GetBytes(textBox3.Text));
            //Для режима CBC нужен INITIAL VECTOR

            //Если зашифровать
            if (radioButton1.Checked)
            {
                //Режим Electronic Codebook Mode(ECB)
                if (radioButton3.Checked)
                {
                    textBox2.Text = bf.Encrypt_ECB(textBox1.Text);
                }
                //Режим Cipher Block Chaining Mode(CBC)
                //Для этого режима нужен INITIAL VECTOR
                if (radioButton4.Checked)
                {
                    textBox2.Text = bf.Encrypt_CBC(textBox1.Text);
                }
                //Режим Cipher Feedback Mode(CFB)
                if (radioButton5.Checked)
                {
                    textBox2.Text = "В разработке.";
                }
                //Режим Output Feedback Mode(OFB)
                if (radioButton6.Checked)
                {
                    textBox2.Text = "В разработке.";
                }
            }

            //Если расшифровать
            if (radioButton2.Checked)
            {
                //Режим Electronic Codebook Mode(ECB)
                if (radioButton3.Checked)
                {
                    textBox2.Text = bf.Decrypt_ECB(textBox1.Text);
                }
                //Для этого режима нужен INITIAL VECTOR
                //Режим Cipher Block Chaining Mode(CBC)
                if (radioButton4.Checked)
                {
                    textBox2.Text = bf.Decrypt_CBC(textBox1.Text);
                }
                //Режим Cipher Feedback Mode(CFB)
                if (radioButton5.Checked)
                {
                    textBox2.Text = "В разработке.";
                }
                //Режим Output Feedback Mode(OFB)
                if (radioButton6.Checked)
                {
                    textBox2.Text = "В разработке.";
                }
            }
        }
    }
}
