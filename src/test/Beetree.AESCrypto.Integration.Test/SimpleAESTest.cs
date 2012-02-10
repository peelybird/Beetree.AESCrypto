using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace Beetree.AESCrypto.Integration.Test
{
    [TestFixture]
    public class SimpleEASTest
    {
        [Test]
        public void DecryptUsingFileKeys_KnownDecryptedString_ReturnsKnownString()
        {
            const string KnownSecret = "iuyiuyjhkjh_ this is a known secret";
            const string KnownIV = @"æ€–,­Ê.Uy›'E°,";
            const string KnownKey = @"Ýž®3hVƒ‹ »WwfŽ÷ÿ)B¤¸-k‰]
";
            // get the keys from the files
            byte[] privateKey;
            privateKey = File.ReadAllBytes(@"C:\Users\David Peel\Documents\key.txt");

            byte[] sharedIV;
            sharedIV = File.ReadAllBytes(@"C:\Users\David Peel\Documents\iv.txt");

            var key = privateKey;


        }
    }
}
