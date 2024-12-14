using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbGiangVien
{
    [DisplayName("Id Giảng Viên")]
    public int IdNguoiDung { get; set; }
    [DisplayName("Họ và Tên")]
    public string? HoTen { get; set; }
    [DisplayName("Email")]
    public string? Email { get; set; }
    [DisplayName("Tên Đăng Nhập")]
    public string? TenDangNhap { get; set; }
    [DisplayName("Mật Khẩu")]
    public string? MatKhau { get; set; }
    [DisplayName("Lớp")]
    public string? Lop { get; set; }
    [DisplayName("Id Khoa")]
    public int? IdKhoa { get; set; }

    [DisplayName("Ngày Sinh")]
    public DateOnly? NgaySinh { get; set; }
    [DisplayName("Giới Tính")]
    public byte? GioiTinh { get; set; }
    [DisplayName("Số Điện Thoại")]
    public string? Sdt { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbKhoa? IdKhoaNavigation { get; set; }

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();
}
