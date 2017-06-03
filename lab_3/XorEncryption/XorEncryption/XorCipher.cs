using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XorEncryption
{
    public class XorCipher
    {
        private string Key { get; set; }
        private string FileToReadPath { get; set; }
        private string OutputPath { get; set; }
        public const string keyExt = ".xorkey";
        

        public XorCipher(string key, string fileToReadPath, string outputPath)
        {
            Key = key;
            FileToReadPath = fileToReadPath;
            OutputPath = outputPath;
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
            string pathOfKey = Path.GetDirectoryName(FileToReadPath) + "\\"  + Path.GetFileNameWithoutExtension(FileToReadPath) + keyExt;
            StreamWriter outputFile = new StreamWriter(pathOfKey, false, Encoding.Default);
            outputFile.Write(Key);
            outputFile.Flush();
            outputFile.Close();
        }


        public virtual void EncryptFile()
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

          
            WriteResultToFile(OutputPath, infoToWrite);
        }
       

        public virtual void DecryptFile()
        {
            EncryptFile();
        }

    }
}
