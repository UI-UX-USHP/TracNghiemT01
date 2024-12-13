using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbKetQua
{
    public int IdKetQua { get; set; }

    public int? IdNguoiDung { get; set; }

    public int? IdBaiThi { get; set; }

    public double? TongDiem { get; set; }

    public DateTime? ThoiGianNop { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public int? IdSinhVien { get; set; }

    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbGiangVien? IdNguoiDungNavigation { get; set; }

    public virtual TbSinhVien? IdSinhVienNavigation { get; set; }

    public virtual ICollection<TbKetQuaChiTiet> TbKetQuaChiTiets { get; set; } = new List<TbKetQuaChiTiet>();

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
