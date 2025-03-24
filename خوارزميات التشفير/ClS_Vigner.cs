using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace خوارزميات_التشفير
{
    class ClS_Vigner
    {
        static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string output = null;
        static char[] letter = alpha.ToCharArray();
        static char[] input = null;
        static int res = 0;

        public static int getkey(string key)
        {
            int r = 0;
            input = key.ToUpper().ToCharArray();
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        r = i;
                    }
                }
            }
            return r;
        }

        public static string Encription(string planText, int key)
        {
            input = planText.ToUpper().ToCharArray();
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        input[j] = letter[(i + key) % letter.Length];
                        break;
                    }
                }
            }
            output = new string (input);
            return output;
        }

        public static string Decription(string cipherText, int key)
        {
            input = cipherText.ToUpper().ToCharArray();
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    if (input[j] == letter[i])
                    {
                        res = (i - key + letter.Length);
                        input[j] = letter[res % letter.Length];
                        break;
                    }
                }
            }
            output = new string(input);
            return output;
        }

    }
}
