using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace quanLiXeBuyt.NghiepVu
{
    internal class MaHoa
    {
        // Hàm này dùng khi bà tạo tài khoản mới (để băm mật khẩu)
        public static string BamMatKhau(string matKhau)
        {
            return BCrypt.Net.BCrypt.HashPassword(matKhau);
        }

        // Hàm này dùng khi đăng nhập để so sánh mật khẩu nhập vào với mã đã băm trong DB
        public static bool KiemTra(string matKhau, string matKhauBam)
        {
            return BCrypt.Net.BCrypt.Verify(matKhau, matKhauBam);
        }
    }
}
