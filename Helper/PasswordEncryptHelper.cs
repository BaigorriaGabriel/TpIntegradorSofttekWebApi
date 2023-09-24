using System.Security.Cryptography;
using System.Text;

namespace TpIntegradorSofttek.Helper
{
    public static class PasswordEncryptHelper
    {
        public static string EncryptPassword(string password, string mail)
        {
            var salt = CreateSalt(mail);
            string saltAndPwd = string.Concat(password, salt);
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));

            for(int i = 0; i < stream.Length; i++) 
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }

        private static string CreateSalt(string mail)
        {
            var salt = mail;
            byte[] saltBytes;
            string saltStr;

            saltBytes=ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach(byte x in saltBytes) 
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();

            return saltStr;
        }
    }
}
