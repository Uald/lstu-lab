using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace EncryptionDES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string sKey;

        private void button1_Click(object sender, EventArgs e)
        {
            sKey = textBox1.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "des files |*.des";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    EncryptFile(source, destination, sKey);
                }
            }
        }

        private void EncryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncryptedt = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();

            try
            {
                dESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                dESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform cryptoTransform = dESCryptoServiceProvider.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncryptedt, cryptoTransform, CryptoStreamMode.Write);

                byte[] byteArrayInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Write(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }

            fsInput.Close();
            fsEncryptedt.Close();
        }

        private void DecrypttFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncryptedt = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();

            try
            {
                dESCryptoServiceProvider.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                dESCryptoServiceProvider.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desenTransform = dESCryptoServiceProvider.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncryptedt, desenTransform, CryptoStreamMode.Write);

                byte[] byteArrayInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Write(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }

            fsInput.Close();
            fsEncryptedt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sKey = textBox1.Text;
            openFileDialog1.Filter = "des files |*.des";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "txt files |*.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    DecrypttFile(source, destination, sKey);
                }
            }
        }
    }
}
