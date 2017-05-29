using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3.Crypto
{
    public class Plugins
    {
        private List<ICryptoPlugin> listOfPlugins;
        public List<ICryptoPlugin> ListOfPlugins
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
            listOfPlugins = new List<ICryptoPlugin>();   
        }


        //вынести как generic
        public bool CheckIfUnique(ICryptoPlugin plugin)
        {
            bool duplicateFound = false;
            int i = 0;
            while (!duplicateFound && i < listOfPlugins.Count)
            {
                if (listOfPlugins[i].GetType().ToString() == plugin.GetType().ToString())
                {
                    duplicateFound = true;
                }
                i++;
            }
            return duplicateFound;
        }

        public bool IsAddedToList(ICryptoPlugin somePlugin)
        {
            if (!CheckIfUnique(somePlugin))
            {
                ListOfPlugins.Add(somePlugin);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
