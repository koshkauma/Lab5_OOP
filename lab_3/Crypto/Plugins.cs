using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3.Crypto
{
    public class Plugins
    {
        private List<CryptoLoader> listOfPlugins;
        public List<CryptoLoader> ListOfPlugins
        {
            get
            {
                return listOfPlugins;
            }
            private set
            { }
        }


        public Plugins()
        {
            listOfPlugins = new List<CryptoLoader>();   
        }

      /*  public bool CheckIfAlreadyInList(CosmeticFactory someFormLoader)
        {
            bool duplicateFound = false;
            int i = 0;
            while (!duplicateFound && i < factoryList.Count)
            {
                if (factoryList[i].GetType().ToString() == someFormLoader.GetType().ToString())
                {
                    duplicateFound = true;
                }
                i++;
            }
            return duplicateFound;
        }

        public void AddProduct(CosmeticFactory someFormLoader)
        {
            if (!CheckIfAlreadyInList(someFormLoader))
            {
                FactoryList.Add(someFormLoader);
            }
            else
            {
                MessageBox.Show(someFormLoader.GetClassName() + " - " + "Данный продукт уже существует!");
            }
        }*/

    }
}
