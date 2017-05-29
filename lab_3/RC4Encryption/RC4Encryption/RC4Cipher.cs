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
        byte[] keyStream; //keySize
        private int x = 0;
        private int y = 0;

        private int KeySize { get; set; }
        private string Key { get; set; }
        private string FileToReadPath { get; set; }

        public const string keyExt = ".RC4key";

        private void Init(byte[] key)
        {
            int keyLength = key.Length;
            

            for (int i = 0; i < keyStream.Length; i++)
            {
                keyStream[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < KeySize; i++)
            {
                j = (j + keyStream[i] + key[i % keyLength]) % KeySize;
                keyStream.Swap(i, j);
            }
        }



        public RC4Cipher(string key, string fileToReadPath, int keySize)
        {
            KeySize = keySize;
            Key = key;
            keyStream = new byte[keySize];
            byte[] keyBytes = Encoding.Default.GetBytes(Key);
            Init(keyBytes);
            FileToReadPath = fileToReadPath;
        }

        private byte keyItem()
        {
            x = (x + 1) % KeySize;
            y = (y + keyStream[x]) % KeySize;

            keyStream.Swap(x, y);

            return keyStream[(keyStream[x] + keyStream[y]) % KeySize];
        }


        //encrypting
        public byte[] Encode(byte[] dataB, int size)
        {

            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }

        public virtual void EncryptFile(string ext)
        {
            //read info from file
            string infoToEncrypt = GetStringFromFile(FileToReadPath);
            byte[] bytesToEncrypt = Encoding.Default.GetBytes(infoToEncrypt);

            byte[] result = new byte[bytesToEncrypt.Length];

            //getting result array of bytes
            for (int i = 0; i < bytesToEncrypt.Length; i++)
            {
                result[i] = (byte)(bytesToEncrypt[i] ^ keyItem());
            }

            string resultStr = Encoding.Default.GetString(result);
            string fileWithResult = Path.GetDirectoryName(FileToReadPath) + "\\" + Path.GetFileNameWithoutExtension(FileToReadPath) + ext;
            WriteResultToFile(fileWithResult, resultStr);
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
            outputFile.WriteLine(Key);
            outputFile.WriteLine(KeySize.ToString());
            outputFile.Flush();
            outputFile.Close();
        }


        public virtual void DecryptFile(string ext)
        {
            EncryptFile(ext);
        }


    }
}
