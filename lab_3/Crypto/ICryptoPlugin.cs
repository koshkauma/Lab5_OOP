using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace lab_3.Crypto
{
    public interface ICryptoPlugin
    {
        CryptoLoader GetCryptoLoader();
        string GetBasicExtension();

        void EncryptFile(Control.ControlCollection controls, string sourcePath, string resultPath);
        void DecryptFile(Control.ControlCollection controls, string sourcePath, string resultPath);


    }
}
