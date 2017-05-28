using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab_3.Crypto;

namespace XorEncryption
{
    class XorEncryptionPlugin: ICryptoPlugin
    {
        public CryptoLoader GetCryptoLoader()
        {
            return new XorCipherLoader();
        }
    }
}
