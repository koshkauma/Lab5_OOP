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
        public const int KeyTextIndex = 1;
        public const int CheckBoxIndex = 4;
        public const int keySizeIndex = 6;
        

        public override object GetAlgorithmName()
        {
            Object obj = new Object();
            obj = "RC4";
            return obj;
        }


        public override List<Control> GetControls(Size size)
        {
            List<Control> result = new List<Control>();
            result.Add(ComponentCreatorHelper.GetLabel("key", "Ключевая фраза", size, new Point(10, 20), 1));
            result.Add(ComponentCreatorHelper.GetTextBox("keyText", size, new Point(10, 40), 2, null));
            result.Add(ComponentCreatorHelper.GetButton("loadKey", "Загрузить ключевую фразу из файла", new Size(120, 35), new Point(10, 70), ButtonLoadKey_Click, 3));
            result.Add(ComponentCreatorHelper.GetButton("loadKey", "Загрузить ключ + длину ключ. потока из файла", new Size(120, 35), new Point(10, 105), ButtonLoadKeyAndKeySize_Click, 4));
            result.Add(ComponentCreatorHelper.GetCheckBox("saveKey", "Сохранить ключ и длину ключ. последовательности при сохранении файла?", new Size(200, 45), new Point(10, 145), 5));
            result.Add(ComponentCreatorHelper.GetLabel("keySize", "Длина ключевой последовательности", new Size(120, 35), new Point(10, 190), 6));
            result.Add(ComponentCreatorHelper.GetTextBox("keySizeTextBox", size, new Point(10, 225), 7, ComponentCreatorHelper.TextBoxDigits_KeyPress));
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
                    Button button = (Button)sender;
                    Control panel = button.Parent;
                    Control.ControlCollection currentControls = panel.Controls;
                    currentControls[KeyTextIndex].Text = keyWord;
                    currentControls[keySizeIndex].Text = size.ToString();
                }
                catch
                {
                    MessageBox.Show("Не удалось прочитать ключ из файла!");
                }
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

        public override bool CheckFields(Control.ControlCollection controls)
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

    }
}
