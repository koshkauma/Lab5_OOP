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
       

        public TextBox GetTextBox(string name, Size size, Point location,
            KeyPressEventHandler keyPressEvent)
        {
            TextBox textboxToCreate = new TextBox();
            textboxToCreate.Location = location;
            textboxToCreate.Name = name;
            textboxToCreate.KeyPress += keyPressEvent;
            return textboxToCreate;
        }

        public Label GetLabel(string name, string text, Size size, Point location)
        {
            Label labelToCreate = new Label();
            labelToCreate.Location = location;
            labelToCreate.Name = name;
            labelToCreate.Text = text;
            labelToCreate.Size = size;
            labelToCreate.BackColor = Color.Transparent;
            return labelToCreate;
        }

        public void TextBoxString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != backspaceCode) && (e.KeyChar != ' ') && !Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        } 


        public Button GetButton(string name, string text, Size size, Point location, EventHandler buttonClick)
        {
            Button buttonToCreate = new Button();
            buttonToCreate.Name = name;
            buttonToCreate.Text = text;
            buttonToCreate.Size = size;
            buttonToCreate.Location = location;
            buttonToCreate.Click += buttonClick;
            return buttonToCreate;
        }

        
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
                }
                catch
                {
                    throw new Exception("Не удалось прочитать ключ из файла!");
                }

                Button button = (Button)sender;
                Control panel = button.Parent;
                TextBox textBoxToEdit = GetKeyTextBox(panel);

                textBoxToEdit.Text = result;
            }
        }


        public CheckBox GetCheckBox(string name, string text, Size size, Point location)
        {
            CheckBox result = new CheckBox();
            result.Name = name;
            result.Text = text;
            result.Size = size;
            result.Location = location;
            result.Checked = true;
            return result;
        }

        public TextBox GetKeyTextBox(Control panel)
        {
            Control.ControlCollection currentControls = panel.Controls;
            int i = 0;
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


        public abstract void EncryptFile(Control.ControlCollection controls, string sourcePath);
        public abstract string DecryptFile(Control.ControlCollection controls, string sourcePath);


    }
}
