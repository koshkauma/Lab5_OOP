using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab_3.Crypto;
using System.Windows.Forms;

namespace XorEncryption
{
    

    public class XorEncryptionPlugin: ICryptoPlugin
    {
        public const string xorExt = ".xor";

        public CryptoLoader GetCryptoLoader()
        {
            return new XorCipherLoader();
        }

        public string GetBasicExtension()
        {
            return xorExt;
        }

        public void EncryptFile(Control.ControlCollection controls, string sourcePath, string outputPath)
        {

            XorCipher xorCipher = new XorCipher(controls[XorCipherLoader.KeyTextIndex].Text, sourcePath, outputPath);
            CheckBox checkBox = (CheckBox)controls[XorCipherLoader.CheckBoxIndex];
            if (checkBox.Checked)
            {
                MessageBox.Show("Ключ сохранен в той же папке, что и Ваш файл.\r\nСам зашифрованный файл сохранен с расширением .xor");
                xorCipher.SaveKey();
            };
            xorCipher.EncryptFile();
        }

        public void DecryptFile(Control.ControlCollection controls, string sourcePath, string outputPath)
        {
            XorCipher xorCipher = new XorCipher(controls[XorCipherLoader.KeyTextIndex].Text, sourcePath, outputPath);
            xorCipher.DecryptFile();   
        }


       
    }
}
