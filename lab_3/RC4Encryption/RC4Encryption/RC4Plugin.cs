using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Crypto;
namespace RC4Encryption
{
    public class RC4Plugin: ICryptoPlugin
    {
        public CryptoLoader GetCryptoLoader()
        {
            return new RC4Loader();
        }

        public string GetBasicExtension()
        {
            return RC4Loader.RC4Ext;
        }
    }
}
