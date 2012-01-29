using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Beetree.AESCrypto.Business;
using NUnit.Framework.Constraints;

namespace Beetree.AESCrypto.Business.Test
{
    [TestFixture]
    public class SimpleAESTest
    {
        [Test]
        public void EncryptDecrypt_WhaenCalled_ReturnsSameValue()
        {
            // Get key for the encryption/decryption
            var privateKey = SimpleAES.GenerateEncryptionKey();
            // get an IV for the operation
            var privateIV = SimpleAES.GenerateEncryptionVector();

            // encrpt a string and store result
            const string SecretString = "jdhsbdsb87dubdlvbd8v7dvd7 my bank details here";
            var simpleAES = new SimpleAES(privateKey, privateIV);
            var encryptedSecret = simpleAES.Encrypt(SecretString);

            // decrypt result and assert the same string returned 
            var decryptedSecret = simpleAES.Decrypt(encryptedSecret);
            Assert.That(decryptedSecret, Is.EqualTo(SecretString));
        }
    }
}
