using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace خوارزميات_التشفير
{
    public class Encript_File
    {
        // TripleDES خوارزميه ال
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        
        public Encript_File(string key) 
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB; 
        }

        // هنا نقوم بتشفير الملفات
        public void encript(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath); 
            byte[] ebytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, ebytes);
        }

        // هنا نقوم بفك تشفير الملفات
        public void decript(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath); 
            byte[] dbytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, dbytes);
        }
    }
}
