using System.Security.Cryptography;
using System.Text;

namespace CapaPresentacion.Functions
{
    public class HashByte
    {
        public byte[] ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);

            return hash;
        }

        public byte[] decryption(string message)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(message));
            return deskey;
        }

    }
}
