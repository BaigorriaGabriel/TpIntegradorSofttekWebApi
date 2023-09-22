using System.Security.Cryptography;
using System.Text;

namespace TpIntegradorSofttek.Helper
{
    public static class PasswordEncryptHelper
    {
        public static string EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = Array.Empty<byte>();
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(password));

            for(int i = 0; i < stream.Length; i++) 
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
