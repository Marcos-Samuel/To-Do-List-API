using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace To_Do_List_API.Dtos.Converters
{

    public class PasswordConverter
    {

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);


                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i]);
                }
                return sb.ToString();
            }
        }


        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);

            return hashedInput.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }


}
