using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TracNghiemT01.ViewModels
{
    // ViewModels/LoginViewModel.cs
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn vai trò")]
        [DisplayName("Vai trò")]
        public string Role { get; set; }  // Admin/GiangVien/SinhVien
    }
}
