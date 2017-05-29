using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lab_3.Helpers;
using lab_3.Classes;

namespace lab_3.Factories
{
    public class Item
    {
        public string NameToShow { get; set; }
        public string Value { get; set; }
        public Item(string NameToShow, string Value)
        {
            this.NameToShow = NameToShow;
            this.Value = Value;
        }
    }

    public abstract class CosmeticFactory
    {
        const int backspaceCode = 8;

        const int nameIndex = 0;
        const int brandIndex = 1;
        const int priceCategoryIndex = 2;
        const int colorButtonIndex = 3;

        public abstract object GetClassName();
        

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Button buttonToChange = (Button)sender;
                buttonToChange.BackColor = colorDialog.Color;
           
            }
        }

        public Button GetPaletteButton(string name, Size size, Point location, int tabIndex, EventHandler buttonClick)
        {
            Button buttonToCreate = new Button();
            buttonToCreate.Name = name;
            buttonToCreate.Size = size;
            buttonToCreate.Location = location;
            buttonToCreate.TabIndex = tabIndex;
            buttonToCreate.Click += buttonClick;
            return buttonToCreate;
        }

        public ComboBox GetComboBox(string name, Size size, Point location, int tabIndex, List<string> names, List<string> values)
        {
            ComboBox comboBoxToCreate = new ComboBox();
            comboBoxToCreate.Name = name;
            comboBoxToCreate.TabIndex = tabIndex;

            int len = values.Count;
            List<Item> dataSource = new List<Item>();

            for (int i = 0; i < len; i++)
            {
                dataSource.Add(new Item(names[i], values[i]));
            }

            comboBoxToCreate.DataSource = dataSource;
            comboBoxToCreate.DisplayMember = "NameToShow";
            comboBoxToCreate.ValueMember = "Value";

            comboBoxToCreate.Location = location;
            comboBoxToCreate.DropDownStyle = ComboBoxStyle.DropDownList;
            return comboBoxToCreate;
        }



        public virtual List<Control> GetListControl(Size size, int leftCoord)
        {
            List<Control> resultList = new List<Control>();

            resultList.Add(ComponentCreatorHelper.GetLabel("productName", "Название продукта", size, new Point(leftCoord, 10), 1));
            resultList.Add(ComponentCreatorHelper.GetTextBox("productName", size, new Point(leftCoord, 30), 2, ComponentCreatorHelper.TextBoxString_KeyPress));
     

            resultList.Add(ComponentCreatorHelper.GetLabel("brand", "Бренд", size, new Point(leftCoord, 60), 3));
            resultList.Add(ComponentCreatorHelper.GetTextBox("brand", size, new Point(leftCoord, 80), 4, ComponentCreatorHelper.TextBoxString_KeyPress));

            List<string> namesOfItems = EnumHelper<CosmeticProduct.PriceCategory>.GetAllDescriptions();
            List<string> values = EnumHelper<CosmeticProduct.PriceCategory>.GetEnumValues();
            resultList.Add(ComponentCreatorHelper.GetLabel("priceCategory", "Ценовая категория", size, new Point(leftCoord, 110), 5));
            resultList.Add(GetComboBox("priceCategory", size, new Point(leftCoord, 130), 6, namesOfItems, values));

            resultList.Add(ComponentCreatorHelper.GetLabel("color", "Цвет", size, new Point(leftCoord, 160), 7));
            resultList.Add(GetPaletteButton("colorButton", new Size(50, 30), new Point(leftCoord, 180), 8, buttonColor_Click));

            return resultList;
        }


        public abstract CosmeticProduct GetSomeCosmeticProduct(int index);

        public Control[] GetComponentsForInput(Control.ControlCollection controlList)
        {
            List<Control> result = new List<Control>();
            foreach (Control someControl in controlList)
            {
                if (!(someControl is Label))
                {
                    result.Add(someControl);
                }
            }
            return result.ToArray();
        }

        public virtual void GetDataFromComponents(CosmeticProduct currentProduct, Control.ControlCollection controls)
        {
            Control[] controlList = GetComponentsForInput(controls);
            currentProduct.ProductName = controlList[nameIndex].Text;
            currentProduct.Brand = controlList[brandIndex].Text;
            ComboBox temp = (ComboBox)controlList[priceCategoryIndex];
            currentProduct.PriceCategoryOfProduct = (CosmeticProduct.PriceCategory)Enum.Parse(typeof(CosmeticProduct.PriceCategory), temp.SelectedValue.ToString());
            currentProduct.Color = controlList[colorButtonIndex].BackColor;
        }


        public virtual void LoadDataToComponets(CosmeticProduct currentProduct, Control.ControlCollection controls)
        {
            Control[] controlList = GetComponentsForInput(controls);
            controlList[nameIndex].Text = Convert.ToString(currentProduct.ProductName);
            controlList[brandIndex].Text = Convert.ToString(currentProduct.Brand);

            ComboBox temp = (ComboBox)controlList[priceCategoryIndex];
            temp.SelectedValue = Enum.GetName(typeof(CosmeticProduct.PriceCategory), currentProduct.PriceCategoryOfProduct);
          
            controlList[colorButtonIndex].BackColor = currentProduct.Color;
        }
        
    

    }
}
