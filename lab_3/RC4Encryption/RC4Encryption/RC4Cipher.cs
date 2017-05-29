using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace RC4Encryption
{
    public class RC4Cipher
    {
        byte[] keyStream = new byte[256];
        int x = 0;
        int y = 0;

        private string Key { get; set; }
        private string FileToReadPath { get; set; }

        public const string keyExt = ".RC4key";

        private void Init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                keyStream[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + keyStream[i] + key[i % keyLength]) % 256;
                keyStream.Swap(i, j);
            }
        }

       

        public RC4Cipher(string key, string fileToReadPath)
        {
            Key = key;
            byte[] keyBytes = Encoding.Default.GetBytes(Key);
            Init(keyBytes);
            FileToReadPath = fileToReadPath;
        }

        //reading information from "FileToReadPath"
        public string GetStringFromFile(string path)
        {
            string result;
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
                throw new Exception("Ошибка чтения!");
            }
            return result;
        }

        public void WriteResultToFile(string path, string infoToSave)
        {
            StreamWriter outputFile = new StreamWriter(path, false, Encoding.Default);
            outputFile.Write(infoToSave);
            outputFile.Flush();
            outputFile.Close();
        }

        public void SaveKey()
        {
            string pathOfKey = Path.GetDirectoryName(FileToReadPath) + "\\" + Path.GetFileNameWithoutExtension(FileToReadPath) + keyExt;
            StreamWriter outputFile = new StreamWriter(pathOfKey, false, Encoding.Default);
            outputFile.Write(Key);
            outputFile.Flush();
            outputFile.Close();
        }


        public virtual void EncryptFile(string ext)
        {
            int keyLength = Key.Length;
            string infoToEncrypt = GetStringFromFile(FileToReadPath);
            byte[] bytesToEncrypt = Encoding.Default.GetBytes(infoToEncrypt);

            byte[] keyBytes = Encoding.Default.GetBytes(Key);
            byte[] result = new byte[bytesToEncrypt.Length];


            for (int i = 0; i < bytesToEncrypt.Length; i++)
            {
                result[i] = (byte)(bytesToEncrypt[i] ^ keyBytes[i % keyBytes.Length]);
            }

            string infoToWrite = Encoding.Default.GetString(result);

            string destFilePath = Path.GetDirectoryName(FileToReadPath) + "\\" + Path.GetFileNameWithoutExtension(FileToReadPath) + ext;
            WriteResultToFile(destFilePath, infoToWrite);
        }


        public virtual void DecryptFile(string ext)
        {
            EncryptFile(ext);
        }





    }
}
