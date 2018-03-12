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
            if (radioButton2.Checked)
            {
                string tmp = textBox1.Text;
                textBox1.Text = textBox2.Text;
                textBox2.Text = tmp;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = radioButton2.Text;
            if (radioButton1.Checked)
            {
                string tmp = textBox1.Text;
                textBox1.Text = textBox2.Text;
                textBox2.Text = tmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            if (textBox3.Text != string.Empty || textBox3.Text != "")
            {
                BlowFish bf = new BlowFish(Encoding.Default.GetBytes(textBox3.Text));
                //Для режима CBC нужен INITIAL VECTOR
                textBox4.Text = textBox4.Text.Replace(" ", string.Empty);
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
                        if (textBox4.Text == "")
                        {
                            textBox2.Text = "Неправильно задан вектор инициализации. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";
                            textBox4.Text = string.Empty;
                            return;
                        }
                        else if (textBox4.Text.Length > 17)
                        {
                            textBox2.Text = "Неправильно задан вектор инициализации. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";
                            textBox4.Text = string.Empty;
                            return;
                        }
                        else if (textBox4.Text.Length == 16)
                        {
                            string temp = textBox4.Text.ToLower();
                            for (int i = 0; i < textBox4.Text.Length; i++)
                                if (!((temp[i] >= 'a' && temp[i] <= 'f') || (temp[i] >= '0' && temp[i] <= '9')))
                                {
                                    textBox4.Text = "Неправильно задан вектор инициализации. Вектор состоит из HEX чисел: 2 символа на число. Символ A-F или 0-9.";
                                    textBox4.Text = string.Empty;
                                    return;
                                }
                            bf.IV = bf.HexToByte(textBox4.Text);
                            textBox2.Text = bf.Encrypt_CBC(textBox1.Text);
                        }
                        else textBox4.Text = "Неправильно задан вектор инициализации. Вектор состоит из HEX чисел: 2 символа на число. Символ A-F или 0-9. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";
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
                        if (textBox4.Text == "")
                        {
                            textBox2.Text = "Неправильно задан вектор инициализации. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";
                            textBox4.Text = string.Empty;
                            return;
                        }
                        else if (textBox4.Text.Length > 17)
                        {
                            textBox2.Text = "Неправильно задан вектор инициализации. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";
                            textBox4.Text = string.Empty;
                            return;
                        }
                        else if (textBox4.Text.Length == 16)
                        {
                            string temp = textBox4.Text.ToLower();
                            for (int i = 0; i < textBox4.Text.Length; i++)
                                if (!((temp[i] >= 'a' && temp[i] <= 'f') || (temp[i] >= '0' && temp[i] <= '9')))
                                {
                                    textBox4.Text = "Неправильно задан вектор инициализации. Вектор состоит из HEX чисел: 2 символа на число. Символ A-F или 0-9.";
                                    textBox4.Text = string.Empty;
                                    return;
                                }
                            bf.IV = bf.HexToByte(textBox4.Text);
                            textBox2.Text = bf.Decrypt_CBC(textBox1.Text);
                        }
                        else textBox4.Text = "Неправильно задан вектор инициализации. Вектор состоит из HEX чисел: 2 символа на число. Символ A-F или 0-9. Вектор должен состоять из 16 символов (по 2 символа на байт) = 8 байт.";

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
            else textBox2.Text = "Отсутствует ключ расшифровки.";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ReadOnly = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ReadOnly = true;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ReadOnly = true;
        }
    }
}
