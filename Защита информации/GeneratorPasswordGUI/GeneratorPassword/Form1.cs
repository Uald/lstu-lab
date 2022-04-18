using System;
using System.Text;

namespace GeneratorPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public string getUpperString(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(32 * flt));
                letter = Convert.ToChar(shift + 192);
                Encoding win1251 = Encoding.GetEncoding(1251);
                string word = win1251.GetString(BitConverter.GetBytes(letter));

                str_build.Append(word[0]);
            }
            return str_build.ToString();
        }

        public string getLowerString(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(32 * flt));
                letter = Convert.ToChar(shift + 224);
                Encoding win1251 = Encoding.GetEncoding(1251);
                string word = win1251.GetString(BitConverter.GetBytes(letter));

                str_build.Append(word[0]);
            }
            return str_build.ToString();
        }

        public string getUpperAndLowerString(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(65 * flt));
                letter = Convert.ToChar(shift + 192);
                Encoding win1251 = Encoding.GetEncoding(1251);
                string word = win1251.GetString(BitConverter.GetBytes(letter));

                str_build.Append(word[0]);
            }
            return str_build.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int LenghtPassword = (int)numericUpDown1.Value;
            int QuantityPassword = (int)numericUpDown2.Value;

            bool LowecaseSymbolsCheck = checkBox1.Checked;
            bool UppercaseSymbolsCheck = checkBox2.Checked;


            if (LowecaseSymbolsCheck == false && UppercaseSymbolsCheck == false)
            {
                MessageBox.Show("Выберите символы для пароля!", "Ошибка");
            }
            else if (LenghtPassword == 0 && QuantityPassword == 0)
            {
                MessageBox.Show("Выберите длинну паролей и их количество!", "Ошибка");
            };


            for (int i = 0; i < QuantityPassword; i++)
            {
                if (LowecaseSymbolsCheck && UppercaseSymbolsCheck)
                {
                    string value = getUpperAndLowerString(LenghtPassword);
                    richTextBox1.Text += value.ToString();
                }
                else if (LowecaseSymbolsCheck)
                {
                    string value = getLowerString(LenghtPassword);
                    richTextBox1.Text += value.ToString();
                }

                else if (UppercaseSymbolsCheck)
                {
                    string value = getUpperString(LenghtPassword);
                    richTextBox1.Text += value.ToString();
                }
                richTextBox1.Text += "\n";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}