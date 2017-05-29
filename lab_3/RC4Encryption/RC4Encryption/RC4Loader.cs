using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using lab_3.Helpers;
using lab_3.Crypto;

namespace RC4Encryption
{
    public class RC4Loader : CryptoLoader
    {
        public const string textExt = ".txt";
        public const string RC4Ext = ".RC4";
        const int KeyTextIndex = 1;
        const int CheckBoxIndex = 4;
        const int keySizeIndex = 6;
        

        public override object GetAlgorithmName()
        {
            Object obj = new Object();
            obj = "RC4";
            return obj;
        }


        public override List<Control> GetControls(Size size)
        {
            List<Control> result = new List<Control>();
            result.Add(ComponentCreatorHelper.GetLabel("key", "Ключевая фраза", size, new Point(10, 20)));
            result.Add(ComponentCreatorHelper.GetTextBox("keyText", size, new Point(10, 40), null));
            result.Add(ComponentCreatorHelper.GetButton("loadKey", "Загрузить ключевую фразу из файла", new Size(120, 35), new Point(10, 70), ButtonLoadKey_Click));
            result.Add(ComponentCreatorHelper.GetButton("loadKey", "Загрузить ключ + длину ключ. потока из файла", new Size(120, 35), new Point(10, 105), ButtonLoadKeyAndKeySize_Click));
            result.Add(ComponentCreatorHelper.GetCheckBox("saveKey", "Сохранить ключ и длину ключ. последовательности при сохранении файла?", new Size(200, 45), new Point(10, 145)));
            result.Add(ComponentCreatorHelper.GetLabel("keySize", "Длина ключевой последовательности", new Size(120, 35), new Point(10, 190)));
            result.Add(ComponentCreatorHelper.GetTextBox("keySizeTextBox", size, new Point(10, 225), ComponentCreatorHelper.TextBoxDigits_KeyPress));
            return result;
        }


        public void ButtonLoadKeyAndKeySize_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string keyPath = dlg.FileName;
                string keyWord;
                int size;
                try
                {
                    using (StreamReader reader = new StreamReader(keyPath, Encoding.Default))
                    {
                        keyWord = reader.ReadLine();
                        size = Int32.Parse(reader.ReadLine());
                    }
                }
                catch
                {
                    throw new Exception("Не удалось прочитать ключ из файла!");
                }
                Button button = (Button)sender;
                Control panel = button.Parent;
                Control.ControlCollection currentControls = panel.Controls;
                currentControls[KeyTextIndex].Text = keyWord;
                currentControls[keySizeIndex].Text = size.ToString();
            }
        }


        private bool IsKeySizeCorrect(string text)
        {
            int value;
            if (Int32.TryParse(text, out value))
            {
                if ((value >= 8 && value <= 2048))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override bool CheckFiels(Control.ControlCollection controls)
        {
            if (!ComponentCreatorHelper.CheckTextBoxes(controls))
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            else
            {
                if (!IsKeySizeCorrect(controls[keySizeIndex].Text))
                {
                    MessageBox.Show("Длина ключевой последовательности - от 8 до 2048 бит");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public override void EncryptFile(Control.ControlCollection controls, string sourcePath)
        {
            RC4Cipher RC4 = new RC4Cipher(controls[KeyTextIndex].Text, sourcePath, Convert.ToInt32(controls[keySizeIndex].Text));
            CheckBox checkBox = (CheckBox)controls[CheckBoxIndex];
            if (checkBox.Checked)
            {
                MessageBox.Show("Ключ сохранен в той же папке, что и Ваш файл.\r\nСам зашифрованный файл сохранен с расширением .RC4");
                RC4.SaveKey();
            };
            RC4.EncryptFile(RC4Ext);
            File.Delete(sourcePath);
        }

        public override string DecryptFile(Control.ControlCollection controls, string sourcePath)
        {
            RC4Cipher RC4 = new RC4Cipher(controls[KeyTextIndex].Text, sourcePath, Convert.ToInt32(controls[keySizeIndex].Text));
            RC4.DecryptFile(textExt);
            string outputFileWithOriginalText = Path.GetDirectoryName(sourcePath) + "\\" + Path.GetFileNameWithoutExtension(sourcePath) + textExt;
            return outputFileWithOriginalText;
        }
    }
}
