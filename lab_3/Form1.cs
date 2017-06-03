using System;
using System.Drawing;
using System.Windows.Forms;
using lab_3.Factories;
using lab_3.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using lab_3.Helpers;
using lab_3.PluginSignaturing;
using System.Security.Cryptography;
using System.IO;
using lab_3.Crypto;


namespace lab_3
{
    public partial class serializeForm : Form
    {
        const int listDisplayMemberIndex = 0;
        const string textExt = ".txt";
        CosmeticListClass list = new CosmeticListClass();

        public serializeForm()
        {
            InitializeComponent();
            foreach (CosmeticFactory factory in factoryFormEditor.FactoryList)
            {
                comboBoxItems.Items.Add(factory.GetClassName());
            }
            comboBoxItems.SelectedIndex = 0;
            panelAdd.Controls.Clear();
            panelAdd.Controls.AddRange(factoryFormEditor.FactoryList[comboBoxItems.SelectedIndex].GetListControl(new Size(200, 15), 10).ToArray());
            panelAdd.Tag = factoryFormEditor.FactoryList[comboBoxItems.SelectedIndex].GetSomeCosmeticProduct(comboBoxItems.SelectedIndex);
            listBoxOfProducts.DataSource = list.CosmeticList;
            listBoxOfProducts.DisplayMember = "ProductName";

            dllComboBox.Visible = false;
            buttonEncrypt.Visible = false;
            buttonDecrypt.Visible = false;
            panelCrypto.Visible = false;

        }


        private static AllProductsFactory factoryFormEditor = new AllProductsFactory();


        private void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelAdd.Controls.Clear();
            panelAdd.Controls.AddRange(factoryFormEditor.FactoryList[comboBoxItems.SelectedIndex].GetListControl(new Size(200, 20), 10).ToArray());
            panelAdd.Tag = factoryFormEditor.FactoryList[comboBoxItems.SelectedIndex].GetSomeCosmeticProduct(comboBoxItems.SelectedIndex);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CosmeticProduct temp = (CosmeticProduct)panelAdd.Tag;
            if (ComponentCreatorHelper.CheckTextBoxes(panelAdd.Controls))
            {
                try
                {
                    factoryFormEditor.FactoryList[temp.ClassIndex].GetDataFromComponents(temp, panelAdd.Controls);
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные!");
                    return;
                }
                panelAdd.Tag = factoryFormEditor.FactoryList[comboBoxItems.SelectedIndex].GetSomeCosmeticProduct(comboBoxItems.SelectedIndex);
                list.CosmeticList.Add(temp);
            }
            else
            {

                MessageBox.Show("Заполните все поля!");
            }
        }

        private void listBoxOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            CosmeticProduct currentProduct = (CosmeticProduct)listBoxOfProducts.SelectedItem;
            if (currentProduct != null)
            {
                panelEdit.Controls.Clear();
                panelEdit.Controls.AddRange(factoryFormEditor.FactoryList[currentProduct.ClassIndex].GetListControl(new Size(200, 20), 10).ToArray());
                factoryFormEditor.FactoryList[currentProduct.ClassIndex].LoadDataToComponets(currentProduct, panelEdit.Controls);
                labelEdit.Text = comboBoxItems.Items[currentProduct.ClassIndex].ToString();
                panelEdit.Tag = currentProduct;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CosmeticProduct temp = (CosmeticProduct)panelEdit.Tag;
            try
            {
                factoryFormEditor.FactoryList[temp.ClassIndex].GetDataFromComponents(temp, panelEdit.Controls);

            }
            catch
            {
                MessageBox.Show("Данные некорректны! Пожалуйста, повторите ввод");
                return;
            }
            list.CosmeticList.ResetBindings();
        }


        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxOfProducts.Items.Count == 0)
            {
                MessageBox.Show("В списке ничего нет!");
            }
            else
            {
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    list.SerializeItemsInList(saveFileDialog.FileName);
                }

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxOfProducts.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CosmeticProduct temp = (CosmeticProduct)listBoxOfProducts.SelectedItem;
                    list.CosmeticList.Remove(temp);
                    panelEdit.Controls.Clear();
                    labelEdit.Text = "";
                }
            }
        }

        private void Deserialize(string fileName)
        {
            try
            {
                list.DeserializeItemsInList(fileName, factoryFormEditor);
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                MessageBox.Show(message);
            }
        }


        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Deserialize(openFileDialog.FileName);
            }
        }


        private void buttonClearList_Click(object sender, EventArgs e)
        {
            if (listBoxOfProducts.Items.Count != 0)
            {
                list.CosmeticList.Clear();
                panelEdit.Controls.Clear();
                labelEdit.Text = "";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void buttonSignPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "DLL files | *.dll"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Signature signatureToCreate = new Signature(dlg.FileName);
                signatureToCreate.SaveSignature();
            }
        }


        Plugins dllList = new Plugins();
        
        //string will be our extension 
        Dictionary<string, int> pluginsExtensions = new Dictionary<string, int>();


        private void InitCryptoComponents()
        {
            panelCrypto.Visible = true;
            buttonDecrypt.Visible = true;
            buttonEncrypt.Visible = true;
            dllComboBox.SelectedIndex = 0;
            dllComboBox.Visible = true;
        }

        private void buttonFuncPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog pluginLoader = new OpenFileDialog();
            pluginLoader.Filter = "DLL files | *.dll";
            pluginLoader.Multiselect = true;
            if (pluginLoader.ShowDialog() == DialogResult.OK)
            {
                LoadingOfPlugin.LoadFuncPlugins(pluginLoader.FileNames, dllList, pluginsExtensions, dllComboBox);
            }
            if (dllList.ListOfPlugins.Count != 0)
            {
                InitCryptoComponents();
            }

        }


        private void buttonLoadPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "DLL files | *.dll";
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                LoadingOfPlugin.LoadNewProducts(dlg.FileNames, factoryFormEditor, comboBoxItems);
            }


        }



        private void dllComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            panelCrypto.Controls.Clear();
            panelCrypto.Controls.AddRange(dllList.ListOfPlugins[dllComboBox.SelectedIndex].GetCryptoLoader().GetControls(new Size(100, 20)).ToArray());
        }
        

        private void buttonDecrypt_Click_1(object sender, EventArgs e)
        {
            if (dllList.ListOfPlugins.Count != 0)
            {
                //////
                if (dllList.ListOfPlugins[dllComboBox.SelectedIndex].GetCryptoLoader().CheckFields(panelCrypto.Controls))
                {
                    //user choose file from directory
                    OpenFileDialog dlg = new OpenFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //getting file name 
                        string inputFilePath = dlg.FileName;
                        //getting extension of file we have to decrypt
                        string cryptoFileExt = Path.GetExtension(inputFilePath);

                        //getting current algorithm 
                        int currentIndexOfUsedPlugin = dllComboBox.SelectedIndex;

                        //check if dictionary contains extension of chosen file
                        if (pluginsExtensions.ContainsKey(cryptoFileExt))
                        {
                            //if we can decrypt such file 
                            //compare current alg. at combobox with alg. we need to use
                            int indexOfPluginForExt = pluginsExtensions[cryptoFileExt];

                            if (currentIndexOfUsedPlugin == indexOfPluginForExt)
                            {
                                string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + textExt;
                                dllList.ListOfPlugins[dllComboBox.SelectedIndex].DecryptFile(panelCrypto.Controls, inputFilePath, outputFilePath);
                                try
                                {
                                   list.DeserializeItemsInList(outputFilePath, factoryFormEditor);
                                }
                                catch (Exception exception)
                                {
                                    string message = exception.Message;
                                    MessageBox.Show(message);
                                }
                                File.Delete(outputFilePath);
                            }
                            else
                            {
                                //if no, we load controls panel for needed alg. 
                                dllComboBox.SelectedIndex = indexOfPluginForExt;
                                //letting the user know
                                MessageBox.Show("Вы пытаетесь расшифровать файл с расширением " + cryptoFileExt + "\r\n" + "Заполните поля для дешифрирования файлов с данным расширением");
                            }

                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Файлы с данным расширением не подлежат расшифровке!\r\nПопробовать открыть данный файл обычным способом?",
                                "Внимание!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //try to open file without any decryption
                                Deserialize(inputFilePath);
                                
                            }
                        }
                    }
                }
            }
        }

        private void buttonEncrypt_Click_1(object sender, EventArgs e)
        {
            if (dllList.ListOfPlugins.Count != 0)
            {
                //////
                if (dllList.ListOfPlugins[dllComboBox.SelectedIndex].GetCryptoLoader().CheckFields(panelCrypto.Controls))
                {
                    if (listBoxOfProducts.Items.Count == 0)
                    {
                        MessageBox.Show("В списке ничего нет!");
                    }
                    else
                    {
                        if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                        {
                            string outputFileDecrypted = Path.GetDirectoryName(saveFileDialog.FileName) + "\\" + Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + dllList.ListOfPlugins[dllComboBox.SelectedIndex].GetBasicExtension();
                            list.SerializeItemsInList(saveFileDialog.FileName);
                            dllList.ListOfPlugins[dllComboBox.SelectedIndex].EncryptFile(panelCrypto.Controls, saveFileDialog.FileName, outputFileDecrypted);
                            File.Delete(saveFileDialog.FileName);
                        }
                    }
                }
              
                /////

            }
        }


    }
    }
    