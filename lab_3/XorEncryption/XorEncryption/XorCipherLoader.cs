using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using lab_3.Crypto;
using lab_3.Helpers;

namespace XorEncryption
{
    public class XorCipherLoader: CryptoLoader
    {
        public const int KeyTextIndex = 1;
        public const int CheckBoxIndex = 3;

        public override object GetAlgorithmName()
        {
            Object obj = new Object();
            obj = "Сложение по модулю 2";
            return obj;
        }

        public override List<Control> GetControls(Size size)
        {
            List<Control> result = new List<Control>();
            result.Add(ComponentCreatorHelper.GetLabel("key", "Введите ключ", size, new Point(10, 20), 1));
            result.Add(ComponentCreatorHelper.GetTextBox("keyText", size, new Point(10, 40), 2, null));
            result.Add(ComponentCreatorHelper.GetButton("loadKey", "Загрузить ключ из файла", new Size(120, 35), new Point(10, 70), ButtonLoadKey_Click, 3));
            result.Add(ComponentCreatorHelper.GetCheckBox("saveKey", "Сохранить ключ при сохранении файла?", new Size(200, 45), new Point(10, 105), 4));
            return result;
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
                return true;
            }
        }
         
       

      
       

    }
}
