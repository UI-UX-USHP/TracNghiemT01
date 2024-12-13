using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbSinhVien
{
    public int IdSinhVien { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? TrangThai { get; set; }

    public int IdBaiThi { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public int? IdKetQua { get; set; }

    public int? IdKetQuaChiTiet { get; set; }

    public virtual TbBaiThi IdBaiThiNavigation { get; set; } = null!;

    public virtual TbKetQuaChiTiet? IdKetQuaChiTietNavigation { get; set; }

    public virtual TbKetQua? IdKetQuaNavigation { get; set; }

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();
}
