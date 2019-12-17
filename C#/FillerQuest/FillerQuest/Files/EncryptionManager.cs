using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    public class EncryptionManager
    {
        public static void EncryptFile<T>(string path, T item)
        {
            if (File.Exists(path))
                File.Delete(path);

            string key = $"y4Zp0FSBuWQAECAwQFBgcICQ";

            string playerKey = "y4Zp0FSBuW";

            RijndaelManaged rjm = new RijndaelManaged();

            UnicodeEncoding ue = new UnicodeEncoding();

            byte[] k = Convert.FromBase64String(key);

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(playerKey, k);

            ICryptoTransform encryptor = CreateEncryptorOrDecryptor(0);

            using (var file = new FileStream(path, FileMode.Create))
            {
                using (var encrypt = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                {
                    Serializer.Serialize(encrypt, item);
                    encrypt.Flush();
                }
            }
        }

        public static T DeCrypt<T>(string path)
        {
            string key = $"y4Zp0FSBuWQAECAwQFBgcICQ";

            string playerKey = "y4Zp0FSBuW";

            RijndaelManaged rjm = new RijndaelManaged();

            UnicodeEncoding ue = new UnicodeEncoding();

            byte[] k = Convert.FromBase64String(key);

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(playerKey, k);

            ICryptoTransform decryptor = CreateEncryptorOrDecryptor(1);

            T ret;
            using (var file = new FileStream(path, FileMode.Open))
            {
                using (var decrypt = new CryptoStream(file, decryptor, CryptoStreamMode.Read))
                {
                    ret = Serializer.Deserialize<T>(decrypt);
                    decrypt.Flush();
                }
            }

            return ret;
        }

        private static ICryptoTransform CreateEncryptorOrDecryptor(byte ed)
        {
            string key = $"y4Zp0FSBuWQAECAwQFBgcICQ";

            string playerKey = "y4Zp0FSBuW";

            RijndaelManaged rjm = new RijndaelManaged();

            UnicodeEncoding ue = new UnicodeEncoding();

            byte[] k = Convert.FromBase64String(key);

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(playerKey, k);

            if(ed == 0)
            {
                return rjm.CreateEncryptor(rfc.GetBytes(rjm.KeySize / 8), rfc.GetBytes(rjm.BlockSize / 8));
            }
            else
            {
                return rjm.CreateDecryptor(rfc.GetBytes(rjm.KeySize / 8), rfc.GetBytes(rjm.BlockSize / 8));
            }
        }
    }
}
