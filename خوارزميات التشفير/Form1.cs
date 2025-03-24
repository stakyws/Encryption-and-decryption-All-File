using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace خوارزميات_التشفير
{
    public partial class Form1 : Form
    {
        //TextBox t18 = new TextBox();
        //TextBox t16 = new TextBox();
        
        RSAParameters public_key;
        RSAParameters private_key;
        string m = null;
        string k = null;
        static int c1;
        char[] alphaAR = new[] { 'ا', 'ب', 'ت', 'ث', 'ج', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ك', 'ل', 'م', 'ن', 'ه', 'و', 'ي' };
        static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] alphaEN = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] alpha1 = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] letter = alpha.ToCharArray();
        public Form1()
        {
            InitializeComponent();
            RSACryptoServiceProvider n = new RSACryptoServiceProvider(2048);
            public_key = n.ExportParameters(false);
            private_key = n.ExportParameters(true);
            textBox18.Text = "3";
            textBox16.Text = "7";
        }
        private int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private int[] FindPosition(char[,] matrix, char c)
        {
            int[] pos = new int[2];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == c)
                    {
                        pos[0] = i;
                        pos[1] = j;
                        return pos;
                    }
                }
            }
            return pos;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                // RSA
                RSACryptoServiceProvider n2 = new RSACryptoServiceProvider();
                n2.ImportParameters(public_key);
                byte[] m = Encoding.Unicode.GetBytes(richTextBox4.Text);
                byte[] m2 = n2.Encrypt(m, false);
                richTextBox3.Text = Convert.ToBase64String(m2);
                richTextBox4.Clear();
            }
            catch { };

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                // RSA
                RSACryptoServiceProvider decrpt = new RSACryptoServiceProvider();
                decrpt.ImportParameters(private_key);
                byte[] c = Convert.FromBase64String(richTextBox3.Text);
                byte[] c1 = decrpt.Decrypt(c, false);
                richTextBox4.Text = Encoding.Unicode.GetString(c1);
            }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox6_1.Clear();
            richTextBox7.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox20.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox17.Clear();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //****************************** Encription Kaesar Start ************************************
            if (radioButton1.Checked)
            {
                try
                {
                    char[] letter = alphaAR.ToArray();
                    int key = int.Parse(textBox1.Text);
                    richTextBox2.Text = "";
                    string planext = richTextBox1.Text;
                    planext = planext.ToUpper();
                    int c = 0;
                    for (int i = 0; i < planext.Length; i++)
                    {
                        if (planext[i] == ' ')
                        {
                            richTextBox2.Text = " ";
                            continue;
                        }
                        for (int j = 0; j < letter.Length; j++)
                        {
                            if (planext[i] == letter[j])
                            {
                                c = j;
                                richTextBox2.Text += letter[(c + key) % 28].ToString();
                            }
                        }
                    }
                }
                catch { }
            }
            //****************************** Encription Kaesar End ************************************

            //****************************** Encription Vigner Start ************************************
            if (radioButton2.Checked)
            {
                try
                {
                    richTextBox2.Clear();
                    m = richTextBox1.Text;
                    k = textBox1.Text;
                    int r = 0;
                    string s = null;
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (r == k.Length - 1)
                            r = 0;
                        else if (r < k.Length && i > 0)
                            r++;
                        else if (r < k.Length && i == 0)
                            r = 0;
                        if (r < k.Length)
                        {
                            s += ClS_Vigner.Encription(m.Substring(i, 1).ToUpper(), ClS_Vigner.getkey(k.Substring(r, 1).ToUpper()));
                        }
                    }
                    richTextBox2.Text = s;
                }
                catch { };
            }
            //****************************** Encription Vigner End ************************************


            //****************************** Encription Affine Start ************************************
            if (radioButton4.Checked == true)
            {
                try
                {
                    char[] letter = alphaAR.ToArray();
                    int m = int.Parse(textBox1.Text);
                    int b = int.Parse(textBox2.Text);
                    string plantext = richTextBox1.Text;
                    plantext = plantext.ToUpper();
                    richTextBox2.Text = "";
                    int x = 0;
                    for (int i = 0; i < plantext.Length; i++)
                    {
                        for (int j = 0; j < letter.Length; j++)
                        {
                            if (plantext[i] == letter[j])
                            {
                                x = j;
                                richTextBox2.Text += letter[(m * x + b) % 28].ToString();
                            }
                        }
                    }
                }
                catch { };
            }
            //****************************** Encription Affine End ************************************

            //****************************** Encription Playfer End ************************************
            if (radioButton3.Checked == true)
            {
                try
                {
                    string key = textBox1.Text.ToUpper();
                    string plaintext = richTextBox1.Text.ToUpper();
                    string alphabet = "ابتثج خدذرزسشصضطظعغفقكلمنهوي";

                    char[,] matrix = new char[5, 5];
                    int keyPos = 0;
                    int alphaPos = 0;

                    for (int i = 0; i < 25; i++)
                    {
                        char currentChar;

                        if (keyPos < key.Length)
                        {
                            currentChar = key[keyPos++];
                        }
                        else
                        {
                            while (key.Contains(alphabet[alphaPos]))
                            {
                                alphaPos++;
                            }

                            currentChar = alphabet[alphaPos++];
                        }

                        matrix[i / 5, i % 5] = currentChar;
                    }

                    string ciphertext = "";
                    plaintext = plaintext.Replace("ي", "ى");

                    for (int i = 0; i < plaintext.Length; i += 2)
                    {
                        char a = plaintext[i];
                        char b = (i + 1 < plaintext.Length) ? plaintext[i + 1] : 'ء';

                        int[] posA = FindPosition(matrix, a);
                        int[] posB = FindPosition(matrix, b);

                        if (posA[0] == posB[0]) // Same row
                        {
                            ciphertext += matrix[posA[0], (posA[1] + 1) % 5];
                            ciphertext += matrix[posB[0], (posB[1] + 1) % 5];
                        }
                        else if (posA[1] == posB[1]) // Same column
                        {
                            ciphertext += matrix[(posA[0] + 1) % 5, posA[1]];
                            ciphertext += matrix[(posB[0] + 1) % 5, posB[1]];
                        }
                        else // Different row and column
                        {
                            ciphertext += matrix[posA[0], posB[1]];
                            ciphertext += matrix[posB[0], posA[1]];
                        }
                    }

                    richTextBox2.Text = ciphertext;
                }
                catch { };
            }
        }
        
            //****************************** Encription Playfer End ************************************
        private void button6_Click(object sender, EventArgs e)
        {
            //****************************** Decreption Kaesar Start ************************************
            if (radioButton1.Checked)
            {
                try
                {
                    char[] letter = alphaAR.ToArray();
                    string ciphertext = richTextBox2.Text;
                    int key = int.Parse(textBox1.Text);
                    ciphertext = ciphertext.ToUpper();
                    richTextBox1.Text = "";
                    int m = 0;
                    for (int i = 0; i < ciphertext.Length; i++)
                    {
                        if (ciphertext[i] == ' ')
                        {
                            richTextBox1.Text = " ";
                            continue;
                        }
                        for (int j = 0; j < letter.Length; j++)
                        {
                            if (ciphertext[i] == letter[j])
                            {
                                m = j;
                                if (m - key < 0)
                                {
                                    richTextBox1.Text += letter[28 + (m - key)].ToString();
                                }
                                else
                                {
                                    richTextBox1.Text += letter[m - key].ToString();
                                }
                            }
                        }
                    }
                }
                catch { };
            }
            //****************************** Decreption Kaesar End ************************************


            //****************************** Decreption Vigner Start ************************************
            if (radioButton2.Checked)
            {
                try
                {
                    richTextBox1.Clear();
                    m = richTextBox2.Text;
                    k = textBox1.Text;
                    int r = 0;
                    string s = null;
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (r == k.Length - 1)
                            r = 0;
                        else if (r < k.Length && i > 0)
                            r++;
                        else if (r < k.Length && i == 0)
                            r = 0;
                        if (r < k.Length)
                        {
                            s += ClS_Vigner.Decription(m.Substring(i, 1).ToUpper(), ClS_Vigner.getkey(k.Substring(r, 1).ToUpper()));
                        }
                    }
                    richTextBox1.Text = s;
                }
                catch { };
            }
            //****************************** Decreption Vigner End ************************************

            

            //****************************** Decreption Affine Start ************************************
            if (radioButton4.Checked)
            {
                try
                {
                    char[] letter = alphaAR.ToArray();
                    richTextBox1.Text = "";
                    int m = int.Parse(textBox1.Text);
                    int b = int.Parse(textBox2.Text);
                    string ciphertext = richTextBox2.Text;
                    int c = 0;
                    ciphertext = ciphertext.ToUpper();
                    for (int i = 1; i < 28; i++)
                    {
                        if (((m * i) % 28) == 1)
                        {
                            c1 = i;
                        }
                    }

                    for (int i = 0; i < ciphertext.Length; i++)
                    {
                        for (int j = 0; j < letter.Length; j++)
                        {
                            if (ciphertext[i] == letter[j])
                            {
                                c = j;
                                richTextBox1.Text += letter[(c1 * ((c - b) + 28) % 28)].ToString();
                            }
                        }
                    }
                }
                catch { };
            }
           
            //****************************** Decreption Affine End ************************************

            //****************************** Decreption Playfer Start ************************************
            if (radioButton3.Checked == true)
            {
                try
                {
                    string key = textBox1.Text.ToUpper();
                    string ciphertext = richTextBox2.Text.ToUpper();
                    string alphabet = "ابتثج خدذرزسشصضطظعغفقكلمنهوي";

                    char[,] matrix = new char[5, 5];
                    int keyPos = 0;
                    int alphaPos = 0;

                    for (int i = 0; i < 25; i++)
                    {
                        char currentChar;

                        if (keyPos < key.Length)
                        {
                            currentChar = key[keyPos++];
                        }
                        else
                        {
                            while (key.Contains(alphabet[alphaPos]))
                            {
                                alphaPos++;
                            }

                            currentChar = alphabet[alphaPos++];
                        }

                        matrix[i / 5, i % 5] = currentChar;
                    }

                    string plaintext = "";
                    for (int i = 0; i < ciphertext.Length; i += 2)
                    {
                        char a = ciphertext[i];
                        char b = (i + 1 < ciphertext.Length) ? ciphertext[i + 1] : 'ء';

                        int[] posA = FindPosition(matrix, a);
                        int[] posB = FindPosition(matrix, b);

                        if (posA[0] == posB[0]) // نفس الصف
                        {
                            plaintext += matrix[posA[0], (posA[1] + 4) % 5];
                            plaintext += matrix[posB[0], (posB[1] + 4) % 5];
                        }
                        else if (posA[1] == posB[1]) // نفس العمود
                        {
                            plaintext += matrix[(posA[0] + 4) % 5, posA[1]];
                            plaintext += matrix[(posB[0] + 4) % 5, posB[1]];
                        }
                        else // صف وعمود مختلفين
                        {
                            plaintext += matrix[posA[0], posB[1]];
                            plaintext += matrix[posB[0], posA[1]];
                        }
                    }

                    richTextBox1.Text = plaintext.Replace("ي", "ى");
                }
                catch { };
            }
            //****************************** Decreption Playfer End ************************************
        }

        private bool TryParse(string p, out int index)
        {
            throw new NotImplementedException();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton2.Checked && radioButton3.Checked)
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                    e.Handled = true;
                else
                    e.Handled = false;

                if (e.KeyChar == 8) // تمكين الحذف
                    e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton1.Checked && radioButton4.Checked)
            {
                if (e.KeyChar < '0' || e.KeyChar > '9')
                    e.Handled = true;
                else
                    e.Handled = false;

                if (e.KeyChar == 8) // تمكين الحذف
                    e.Handled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                label3.Text = "M";
                label4.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label3.Text = "Key";
                label4.Visible = false;
                textBox2.Visible = false;
            }
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            label5.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox6_1.Clear();
            richTextBox7.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox20.Clear();
            textBox17.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(textBox3.Text);
                int a = int.Parse(textBox4.Text);
                int m = int.Parse(textBox5.Text);
                int E = int.Parse(textBox6.Text);
                int n = p * a;
                double c = Math.Pow(m, E) % n;
                textBox8.Text = c.ToString();
            }
            catch { };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // فك تشفير
                int p = int.Parse(textBox3.Text);
                int a = int.Parse(textBox4.Text);
                int D = int.Parse(textBox7.Text); // مفترض هنا أن D تمثل المفتاح الخاص لعملية فك التشفير
                double c = double.Parse(textBox5.Text);
                int n = p * a;
                double m = Math.Pow(c, D) % n;
                textBox9.Text = m.ToString();
            }
            catch { };
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                richTextBox1.Clear();
                richTextBox2.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                richTextBox1.Clear();
                richTextBox2.Clear();
                textBox1.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int p = int.Parse(textBox10.Text);
            int g = int.Parse(textBox11.Text);
            int praS = int.Parse(textBox12.Text);
            int praR = int.Parse(textBox13.Text);
            double pubS = Math.Pow(g, praS) % p;
            double pubR = Math.Pow(g, praR) % p;
            double secS = Math.Pow(pubR, pubS) % p;
            double secR = Math.Pow(pubS, pubR) % p;
            textBox14.Text = secS.ToString();
            textBox15.Text = secR.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox6_1.Clear();
            richTextBox7.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox20.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox17.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            label5.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox6_1.Clear();
            richTextBox7.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox20.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            richTextBox4.Clear();
            textBox17.Clear();
        }


        private void button17_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            groupBox4.Visible = false;
            label5.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox17.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            char[] letter = alphaAR.ToArray();
            int m = int.Parse(textBox18.Text);
            int b = int.Parse(textBox16.Text);
            int keyCaesar = 3;

            string plaintextCC = richTextBox5.Text.ToUpper();
            string plaintextAC = richTextBox6_1.Text.ToUpper();
            string caesarCiphertext = "";
            string affineCiphertext = "";
            string caesarCiphertextPreserved = "";
            bool isFirstSentence = true;
            bool isFirstSentence2 = true;
            foreach (char c in plaintextCC)
            {
                if (alphaAR.Contains(char.ToLower(c)) || alphaEN.Contains(char.ToUpper(c))|| char.IsPunctuation(c) || char.IsSymbol(c) || c == ' ')
                {
                    // خوارزمية القيصر
                    int index;
                    if (alphaAR.Contains(char.ToLower(c)))
                    {
                        index = Array.IndexOf(alphaAR, char.ToLower(c));
                        int newIndex = (index + keyCaesar) % alphaAR.Length;
                        caesarCiphertext += char.IsUpper(c) ? char.ToUpper(alphaAR[newIndex]) : alphaAR[newIndex];
                    }
                    else if (alphaEN.Contains(char.ToUpper(c)))
                    {
                        index = Array.IndexOf(alphaEN, char.ToUpper(c));
                        int newIndex = (index + keyCaesar) % alphaEN.Length;
                        caesarCiphertext += char.IsLower(c) ? char.ToLower(alphaEN[newIndex]) : alphaEN[newIndex];
                    }

                }
                else
                {
                    caesarCiphertext += c;
                }

                if (c == '.' || c == '!' || c == '?' || c == '*' || c == ':' || c == '(' || c == ')' || c == '#' || c == ' ' || c == '/' || c == '|' || c == '%' || c == '$' || c == '@' || c == ';' || c == ',' || c == '-' || c == '_' || c == '+')
                {
                    caesarCiphertext += c;
                    isFirstSentence = true;
                    richTextBox6_1.Text = caesarCiphertext;
                    caesarCiphertextPreserved = richTextBox6_1.Text;
                }

            }

            foreach (char c in caesarCiphertextPreserved)
            {
                if (alphaAR.Contains(char.ToLower(c)) || alphaEN.Contains(char.ToUpper(c)) || c == ' ' || char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    char[] letterAC = alphaAR.Contains(char.ToLower(c)) ? alphaAR : alphaEN;

                    if (char.IsLetter(c))
                    {
                        int x = Array.IndexOf(letterAC, char.ToUpper(c));
                        int encryptedIndex = ((m * x + b) % letterAC.Length);
                        char encryptedChar = letterAC[encryptedIndex];
                        affineCiphertext += char.IsUpper(c) ? char.ToUpper(encryptedChar) : encryptedChar;
                    }
                    else
                    {
                        affineCiphertext += c; // الحفاظ على الرموز والمسافات كما هي
                    }
                }
                else
                {
                    affineCiphertext += c; // الحفاظ على الرموز والمسافات كما هي
                }
                richTextBox6.Text = affineCiphertext;
                richTextBox5.Clear();
            }
            // Save the encrypted text to a txt file
            System.IO.File.WriteAllText("encrypted_text.txt",affineCiphertext);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox19.Text = openFileDialog1.FileName;
            textBox20.Text = Path.GetFileName(textBox19.Text);
            textBox21.Text = Path.GetExtension(textBox19.Text);
            if (textBox21.Text == ".txt")
                richTextBox5.Text = File.ReadAllText(textBox19.Text);
            else
                textBox20.Text = "The file is invalid";
        }

        private void button18_Click(object sender, EventArgs e)
        {

            char[] letter = alphaAR.ToArray();
            int m = int.Parse(textBox18.Text);
            int b = int.Parse(textBox16.Text);
            int keyCaesar = 3;

            string caesarCiphertext = richTextBox6_1.Text.ToUpper(); // المشفر بواسطة القيصر
            string affineCiphertext = richTextBox6.Text.ToUpper(); // المشفر بواسطة ال Affine

            string decryptedAffine = "";
            string decryptedCaesar = "";

            foreach (char c in affineCiphertext)
            {
                bool isArabic = alphaAR.Contains(c);
                bool isEnglish = alphaEN.Contains(c);

                if (isArabic || isEnglish)
                {
                    char[] letterAC = isArabic ? alphaAR : alphaEN;

                    for (int j = 0; j < letterAC.Length; j++)
                    {
                        if (c == letterAC[j])
                        {
                            int x = j;
                            // حساب الحرف المفكك
                            int inverseM = 0;
                            for (int i = 1; i < letterAC.Length; i++)
                            {
                                if ((m * i) % letterAC.Length == 1)
                                {
                                    inverseM = i;
                                    break;
                                }
                            }

                            int decryptedIndex = inverseM * (x - b + letterAC.Length) % letterAC.Length;
                            char decryptedChar = letterAC[decryptedIndex];
                            decryptedAffine += decryptedChar;
                        }
                    }
                }
                else
                {
                    decryptedAffine += c;
                }
            }

            richTextBox7.Text = decryptedAffine;
            caesarCiphertext = richTextBox7.Text.ToUpper();

            foreach (char c in caesarCiphertext)
            {
                if (alphaAR.Contains(char.ToLower(c)) || alphaEN.Contains(char.ToUpper(c)) || c == ' ' || char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    int index;
                    if (alphaAR.Contains(char.ToLower(c)))
                    {
                        index = Array.IndexOf(alphaAR, char.ToLower(c));
                        int newIndex = (index - keyCaesar + alphaAR.Length) % alphaAR.Length;
                        decryptedCaesar += char.IsUpper(c) ? char.ToUpper(alphaAR[newIndex]) : alphaAR[newIndex];
                    }
                    else if (alphaEN.Contains(char.ToUpper(c)))
                    {
                        index = Array.IndexOf(alphaEN, char.ToUpper(c));
                        int newIndex = (index - keyCaesar + alphaEN.Length) % alphaEN.Length;
                        decryptedCaesar += char.IsLower(c) ? char.ToLower(alphaEN[newIndex]) : alphaEN[newIndex];
                    }
                }
                else
                {
                    decryptedCaesar += c;
                }
                bool isFirstSentence = true;
                if (c == '.' || c == '!' || c == '?' || c == '*' || c == ':' || c == '(' || c == ')' || c == '#' || c == ' ' || c == '/' || c == '|' || c == '%' || c == '$' || c == '@' || c == ';' || c == ',' || c == '-' || c == '_' || c == '+')
                {
                    decryptedCaesar += c;
                    isFirstSentence = true;
                }
                richTextBox5.Text = decryptedCaesar;
            }
            // حفظ النص الأصلي في ملف txt
            System.IO.File.WriteAllText("decrypted_text.txt", decryptedCaesar);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox6_1.Clear();
            richTextBox7.Clear();
        }

        
    }
}
