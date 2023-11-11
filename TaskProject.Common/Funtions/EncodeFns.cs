using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Funtions
{
    public class EncodeFns
    {
        public string HashPassword(string password)
        {
            // Mã hóa mật khẩu với mức độ salt mặc định
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Kiểm tra xem mật khẩu có khớp với mật khẩu đã mã hóa hay không
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return passwordMatch;
        }
    }
}
