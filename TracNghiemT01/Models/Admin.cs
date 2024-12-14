using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class Admin
{
    [DisplayName("Id của Admin")]
    public int Id { get; set; }
    [DisplayName("Tên Đăng Nhập")]
    public string? TenDangNhap { get; set; }
    [DisplayName("Mật Khẩu")]
    public string? MatKhau { get; set; }
    [DisplayName("Họ và Tên")]
    public string? HoTen { get; set; }
    [DisplayName("Email")]
    public string? Email { get; set; }
    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TònTai { get; set; }
}
