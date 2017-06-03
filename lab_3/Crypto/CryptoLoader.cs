using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace lab_3.Crypto
{
    public abstract class CryptoLoader
    {
        const int backspaceCode = 8;

        public abstract object GetAlgorithmName();
        
        public void ButtonLoadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string keyPath = dlg.FileName;
                string result;
                try
                {
                    using (StreamReader reader = new StreamReader(keyPath, Encoding.Default))
                    {
                        result = reader.ReadToEnd();
                    }
                    Button button = (Button)sender;
                    Control panel = button.Parent;
                    TextBox textBoxToEdit = GetKeyTextBox(panel);

                    textBoxToEdit.Text = result;
                }
                catch
                {
                    MessageBox.Show("Не удалось прочитать ключ из файла!");
                }
            }
        }

        public TextBox GetKeyTextBox(Control panel)
        {
            Control.ControlCollection currentControls = panel.Controls;
            foreach(Control controlItem in currentControls)
            {
                if (controlItem is TextBox && controlItem.Name == "keyText")
                {
                    TextBox result = (TextBox)controlItem;
                    return result;
                }
            }
            return null;
        }


        public abstract List<Control> GetControls(Size size);

        public abstract bool CheckFields(Control.ControlCollection controls);
      

    }
}
