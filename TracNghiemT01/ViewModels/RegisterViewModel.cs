// /ViewModels/RegisterViewModel.cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TracNghiemT01.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn vai trò")]
        [DisplayName("Vai trò")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [DisplayName("Số điện thoại")]
        public string Sdt { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string XacNhanMatKhau { get; set; }

        // Fields cho giảng viên
        [DisplayName("Khoa")]
        public int? IdKhoa { get; set; }
    }
}