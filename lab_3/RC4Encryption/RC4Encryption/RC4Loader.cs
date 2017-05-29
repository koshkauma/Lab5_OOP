using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Crypto;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace RC4Encryption
{
    public class RC4Loader : CryptoLoader
    {
        public const string textExt = ".txt";
        public const string xorExt = ".xor";
        const int KeyTextIndex = 1;
        const int CheckBoxIndex = 3;

        public override object GetAlgorithmName()
        {
            Object obj = new Object();
            obj = "RC4";
            return obj;
        }

        public override List<Control> GetControls(Size size)
        {
            List<Control> result = new List<Control>();
            result.Add(GetLabel("key", "Введите ", size, new Point(10, 20)));
            result.Add(GetTextBox("keyText", size, new Point(10, 40), null));
            result.Add(GetButton("loadKey", "Загрузить ключ из файла", new Size(120, 35), new Point(10, 70), ButtonLoadKey_Click));
            result.Add(GetCheckBox("saveKey", "Сохранить ключ при сохранении файла?", new Size(200, 45), new Point(10, 105)));
            return result;
        }

        public override void EncryptFile(Control.ControlCollection controls, string sourcePath)
        {

            RC4Cipher xorCipher = new RC4Cipher(controls[KeyTextIndex].Text, sourcePath);
            CheckBox checkBox = (CheckBox)controls[CheckBoxIndex];
            if (checkBox.Checked)
            {
                MessageBox.Show("Ключ сохранен в той же папке, что и Ваш файл.\r\nСам зашифрованный файл сохранен с расширением .xor");
                xorCipher.SaveKey();
            };
            xorCipher.EncryptFile(xorExt);
            File.Delete(sourcePath);

        }

        public override string DecryptFile(Control.ControlCollection controls, string sourcePath)
        {
            RC4Cipher xorCipher = new RC4Cipher(controls[KeyTextIndex].Text, sourcePath);
            xorCipher.DecryptFile(textExt);
            string outputFileWithOriginalText = Path.GetDirectoryName(sourcePath) + "\\" + Path.GetFileNameWithoutExtension(sourcePath) + textExt;
            return outputFileWithOriginalText;
        }
    }
}
