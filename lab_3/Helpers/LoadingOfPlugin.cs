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

        private static List<T> GetPlugins<T>(string[] arrOfPath) where T: class
        {
            List<T> result = new List<T>();
            for (int i = 0; i < arrOfPath.Length; i++)
            {
                string currentPluginPath = arrOfPath[i];
                Assembly assembly = Assembly.LoadFrom(currentPluginPath);
                List<Type> pluginTypes = GetTypes<T>(assembly);
                if (pluginTypes.Count != 0)
                {
                    for (int j = 0; j < pluginTypes.Count; j++)
                    {
                        T plugin = Activator.CreateInstance(pluginTypes[j]) as T;
                        result.Add(plugin);
                    }
                }

            }
            return result;
        }

        public static void LoadNewProducts(string[] plugins, AllProductsFactory factoryFormEditor, ComboBox comboBoxToUse)
        {

            string[] validPlugins = GetValidPluginNames(plugins);
            List<IPlugin> pluginList = GetPlugins<IPlugin>(validPlugins);
            if (pluginList.Count != 0)
            {
                int prevComboBoxIndex = factoryFormEditor.FactoryList.Count();
                for (int i = 0; i < pluginList.Count(); i++)
                {
                    factoryFormEditor.AddProduct(pluginList[i].GetFormLoader());
                }

                for (int j = prevComboBoxIndex; j < factoryFormEditor.FactoryList.Count; j++)
                {
                    comboBoxToUse.Items.Add(factoryFormEditor.FactoryList[j].GetClassName());
                }
            }
        }
       


        public static string[] GetValidPluginNames(string[] pluginNames)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < pluginNames.Count(); i++)
            {
                string currentPluginName = pluginNames[i];
                string shortPluginName = Path.GetFileName(currentPluginName);

                try
                {
                    Signature signature = new Signature(currentPluginName);
                    if (signature.CheckIfValid())
                    {
                        Assembly assembly = Assembly.LoadFrom(currentPluginName);
                        result.Add(currentPluginName);
                    }
                    else
                    {
                        MessageBox.Show(shortPluginName + " - " + "Подлинность плагина не установлена.");
                    }
                }
                catch(BadImageFormatException)
                {
                    MessageBox.Show(shortPluginName + " - " + "Ошибка загрузки dll");
                }
                catch(Exception exception)
                {
                    MessageBox.Show(shortPluginName + " - " + exception.Message);
                }
            }


            return result.ToArray();
        }

        public static void LoadFuncPlugins(string[] pluginNames, Plugins plugins, Dictionary<string, int> dict, ComboBox comboBoxOfAlg)
        {
            //size of plugin list before this loading
            int prevCounter = plugins.ListOfPlugins.Count();
            int amountOfAddedPlugins = 0;

            string[] validPlugins = GetValidPluginNames(pluginNames);
            List<ICryptoPlugin> ListOfCryptoAlg = GetPlugins<ICryptoPlugin>(validPlugins);

            if (ListOfCryptoAlg.Count != 0)
            {
                for (int i = 0; i < ListOfCryptoAlg.Count(); i++)
                {
                    if (!(plugins.IsAddedToList(ListOfCryptoAlg[i])))
                    {
                        MessageBox.Show(ListOfCryptoAlg[i].GetCryptoLoader().GetAlgorithmName() + " - " + "Данный продукт уже добавлен!");
                    }
                    else
                    {
                        amountOfAddedPlugins++;
                    }
                }
            }


            //add to dictionary and combobox

            for (int i = prevCounter; i < prevCounter + amountOfAddedPlugins; i++)
            {
                dict.Add(plugins.ListOfPlugins[i].GetBasicExtension(), i);
                CryptoLoader currLoader = plugins.ListOfPlugins[i].GetCryptoLoader();
                comboBoxOfAlg.Items.Add(currLoader.GetAlgorithmName());
            }

        }

        



    }
}




     

