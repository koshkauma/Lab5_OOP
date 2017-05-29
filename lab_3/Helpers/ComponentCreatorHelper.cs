using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3.Helpers
{
    public static class ComponentCreatorHelper
    {
        const int backspaceCode = 8;

        public static void TextBoxDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != backspaceCode))
            {
                e.Handled = true;
            }
        }


        public static void TextBoxString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != backspaceCode) && (e.KeyChar != ' ') && !Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }




        public static Button GetButton(string name, string text, Size size, Point location, EventHandler buttonClick, int tabIndex)
        {
            Button buttonToCreate = new Button();
            buttonToCreate.Name = name;
            buttonToCreate.Text = text;
            buttonToCreate.Size = size;
            buttonToCreate.Location = location;
            buttonToCreate.Click += buttonClick;
            buttonToCreate.TabIndex = tabIndex;
            return buttonToCreate;
        }

        public static bool CheckTextBoxes(Control.ControlCollection controlList)
        {
            bool result = true;
            int i = 0;
            while (result && i < controlList.Count)
            {
                if (controlList[i] is TextBox)
                {
                    if (controlList[i].Text == "")
                    {
                        result = false;
                        break;
                    }
                }
                i++;
            }
            return result;
        }


        public static TextBox GetTextBox(string name, Size size, Point location, int tabIndex,
         KeyPressEventHandler keyPressEvent)
        {
            TextBox textboxToCreate = new TextBox();
            textboxToCreate.Location = location;
            textboxToCreate.Name = name;
            textboxToCreate.TabIndex = tabIndex;
            textboxToCreate.KeyPress += keyPressEvent;
            return textboxToCreate;
        }

        public static Label GetLabel(string name, string text, Size size, Point location, int tabIndex)
        {
            Label labelToCreate = new Label();
            labelToCreate.Location = location;
            labelToCreate.Name = name;
            labelToCreate.Text = text;
            labelToCreate.Size = size;
            labelToCreate.BackColor = Color.Transparent;
            labelToCreate.TabIndex = tabIndex;
            return labelToCreate;
        }


        public static CheckBox GetCheckBox(string name, string text, Size size, Point location, int tabIndex)
        {
            CheckBox result = new CheckBox();
            result.Name = name;
            result.Size = size;
            result.Text = text;
            result.Location = location;
            result.TabIndex = tabIndex;
            result.Checked = true;
            return result;
        }

    }
}
