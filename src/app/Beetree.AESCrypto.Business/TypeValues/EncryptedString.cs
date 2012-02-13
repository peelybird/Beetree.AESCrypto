using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.UserTypes;
using NHibernate.SqlTypes;
using System.Data;
using System.IO;

namespace Beetree.AESCrypto.Business.TypeValues
{
    public class EncryptedStringUserType : IUserType
    {
        public bool Equals(object x, object y)
        {
            return object.Equals(x, y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            object r = rs[names[0]];
            if (r == DBNull.Value)
                return null;
            // decrypt result and assert the same string returned 
            // Get key for the encryption/decryption
            var privateKey = File.ReadAllBytes(@"C:\Users\David Peel\Documents\key.txt");
            var sharedIV = File.ReadAllBytes(@"C:\Users\David Peel\Documents\iv.txt");
            
            // encrpt a string and store result
            var simpleAES = new SimpleAES(privateKey, sharedIV);
            return simpleAES.Decrypt((byte[])r);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            object paramVal = DBNull.Value;
            if (value != null)
            {
                // get the keys from the files
                var privateKey = File.ReadAllBytes(@"C:\Users\David Peel\Documents\key.txt");
                var sharedIV = File.ReadAllBytes(@"C:\Users\David Peel\Documents\iv.txt");

                // encrpt a string and store result
                var simpleAES = new SimpleAES(privateKey, sharedIV);
                paramVal = simpleAES.Encrypt((string)value);
            }
            IDataParameter parameter = (IDataParameter)cmd.Parameters[index];
            parameter.Value = paramVal;
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public SqlType[] SqlTypes
        {
            get { return new SqlType[] { new BinarySqlType() }; }
        }

        public Type ReturnedType
        {
            get { return typeof(string); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}
