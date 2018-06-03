using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOR_Crypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string myxor = XORString(textBox1.Text, textBox2.Text);
            string otxor = EncryptOrDecrypt(textBox1.Text, textBox2.Text);

            // XOR 1st time:
            textBox3.Text = myxor;

            // XOR 2nd time: 

            //textBox3.Text = XORString(myxor, textBox2.Text);

            

            

        }

        string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
            {
                // take next character from string
                char character = text[c];

                // cast to a uint
                uint charCode = (uint)character;

                // figure out which character to take from the key
                int keyPosition = c % key.Length; // use modulo to "wrap round"

                // take the key character
                char keyChar = key[keyPosition];

                // cast it to a uint also
                uint keyCode = (uint)keyChar;

                // perform XOR on the two character codes
                uint combinedCode = charCode ^ keyCode;

                // cast back to a char
                char combinedChar = (char)combinedCode;

                // add to the result
                result.Append(combinedChar);
            }

            return result.ToString();
        }



        private string XORString(string input, string key)
        {
            int length = input.Length;
            char[] ch = new char[length];
            


            for (int i = 0; i < length; i++)
            {
                int c = Convert.ToInt32(input[i]);
                int kpos = i % key.Length;
                int d = Convert.ToInt32(key[kpos]);

                ch[i] = Convert.ToChar(c ^ d);

               //int c = 1, d = 0, e;
               // e = c ^ d;
            }

            string str = new string(ch);

            return str;


         
        }

        private Boolean XOR(int a, int b)
        {
            if ( (a != b)&&(a > 0) || (b != a)&&(b > 0) )
            {
                return true;
            }

            return false;
        }



    }
}
