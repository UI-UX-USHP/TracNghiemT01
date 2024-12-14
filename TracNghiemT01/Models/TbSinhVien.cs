using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace TracNghiemT01.Models;

public partial class TbSinhVien
{
    [DisplayName("Id Sinh Viên")]
    public int IdSinhVien { get; set; }

    [DisplayName("Tên Đăng Nhập")]
    public string? TenDangNhap { get; set; }
    [DisplayName("Mật Khẩu")]
    public string? MatKhau { get; set; }
    [DisplayName("Email")]
    public string? Email { get; set; }
    [DisplayName("Số Điện Thoại")]
    public string? Sdt { get; set; }
    [DisplayName("Trạng Thái")]
    public string? TrangThai { get; set; }
    [DisplayName("Id Bài Thi")]
    public int IdBaiThi { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }
    [DisplayName("Id Kết Quả")]
    public int? IdKetQua { get; set; }
    [DisplayName("Id Kết Quả Chi Tiết")]
    public int? IdKetQuaChiTiet { get; set; }

    public virtual TbBaiThi IdBaiThiNavigation { get; set; } = null!;

    public virtual TbKetQuaChiTiet? IdKetQuaChiTietNavigation { get; set; }

    public virtual TbKetQua? IdKetQuaNavigation { get; set; }

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();
}
