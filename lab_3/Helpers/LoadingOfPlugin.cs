using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab_3.Factories;
using System.Windows.Forms;
using System.Reflection;
using lab_3.Crypto;
using lab_3.PluginSignaturing;
using System.IO;

namespace lab_3.Helpers
{
    public static class LoadingOfPlugin
    {
        private static List<Type> GetTypes<T>(Assembly assembly)
        {
            if (!typeof(T).IsInterface)
            {
                return null;
            }
            return assembly.GetTypes().Where(x => x.GetInterface(typeof(T).Name) != null).ToList();

        }

        public static void ProccessLoadingOfPlugins(string pluginPath, AllProductsFactory factoryFormEditor, ComboBox comboBoxToUse)
        {
            Assembly assembly = Assembly.LoadFrom(pluginPath);
            List<Type> pluginTypes = GetTypes<IPlugin>(assembly);

            if (pluginTypes.Count != 0)
            {
                int prevIndex = factoryFormEditor.FactoryList.Count();
                for (int i = 0; i < pluginTypes.Count; i++)
                {

                    IPlugin plugin = Activator.CreateInstance(pluginTypes[i]) as IPlugin;
                    factoryFormEditor.AddProduct(plugin.GetFormLoader());
                }

                for (int i = prevIndex; i < factoryFormEditor.FactoryList.Count; i++)
                {
                    comboBoxToUse.Items.Add(factoryFormEditor.FactoryList[i].GetClassName());
                }
            }
        }


        public static void LoadFuncPlugins(string[] pluginNames, Plugins plugins, Dictionary<string, int> dict, ComboBox comboBoxOfAlg)
        {
            //size of plugin list before this loading
            int prevCounter = plugins.ListOfPlugins.Count();
            int amountOfAddedPlugins = 0;

            for (int i = 0; i < pluginNames.Count(); i++)
            {
                string currentPluginName = pluginNames[i];
                string shortPluginName = Path.GetFileName(currentPluginName);
                try
                {

                    Signature signatureToCheck = new Signature(currentPluginName);

                    if (signatureToCheck.CheckIfValid())
                    {
                        Assembly assembly = Assembly.LoadFrom(currentPluginName);
                        List<Type> pluginTypes = GetTypes<ICryptoPlugin>(assembly);
                        if (pluginTypes.Count != 0)
                        {
                            for (int j = 0; j < pluginTypes.Count; j++)
                            {
                                ICryptoPlugin plugin = Activator.CreateInstance(pluginTypes[i]) as ICryptoPlugin;
                                //
                                //
                                if (!(plugins.IsAddedToList(plugin)))
                                {
                                    MessageBox.Show("Данный продукт уже добавлен!");
                                }
                                else
                                {
                                    amountOfAddedPlugins++;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(shortPluginName + " Подлинность плагина не установлена!");
                    }
                }
                catch (BadImageFormatException)
                {
                    MessageBox.Show(shortPluginName + " - " + "Ошибка загрузки dll");
                }
                catch(Exception exception)
                {
                    MessageBox.Show(shortPluginName + " - " + exception.Message);
                }
            }

            //add to dict. and to combobox
            for (int i = prevCounter; i < prevCounter + amountOfAddedPlugins; i++)
            {
                dict.Add(plugins.ListOfPlugins[i].GetBasicExtension(), i);
                CryptoLoader currLoader = plugins.ListOfPlugins[i].GetCryptoLoader();
                comboBoxOfAlg.Items.Add(currLoader.GetAlgorithmName());
            }

        }

        



    }
}




     

