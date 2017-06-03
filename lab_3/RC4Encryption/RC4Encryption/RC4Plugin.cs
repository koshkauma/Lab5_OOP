using System;
using System.Windows.Forms;
using System.IO;
using lab_3.Crypto;

namespace RC4Encryption
{
    public class RC4Plugin: ICryptoPlugin
    {

        const string RC4Extension = ".RC4";


        public CryptoLoader GetCryptoLoader()
        {
            return new RC4Loader();
        }

        public string GetBasicExtension()
        {
            return RC4Loader.RC4Ext;
        }

    
        public void EncryptFile(Control.ControlCollection controls, string sourcePath, string resultPath)
        {
            RC4Cipher RC4 = new RC4Cipher(controls[RC4Loader.KeyTextIndex].Text, sourcePath, resultPath, Convert.ToInt32(controls[RC4Loader.keySizeIndex].Text));
            CheckBox checkBox = (CheckBox)controls[RC4Loader.CheckBoxIndex];
            if (checkBox.Checked)
            {
                MessageBox.Show("Ключ сохранен в той же папке, что и Ваш файл.\r\n");
                RC4.SaveKey();
            };
            RC4.EncryptFile();
        }

        public void DecryptFile(Control.ControlCollection controls, string sourcePath, string resultPath)
        {
            RC4Cipher RC4 = new RC4Cipher(controls[RC4Loader.KeyTextIndex].Text, sourcePath, resultPath, Convert.ToInt32(controls[RC4Loader.keySizeIndex].Text));
            RC4.DecryptFile();
        }
    }
}
