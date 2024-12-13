using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbBaiThi
{
    public int IdBaiThi { get; set; }

    public string? TenBaiThi { get; set; }

    public int? SoLanToiDa { get; set; }

    public TimeOnly? ThoiGian { get; set; }

    public DateTime? ThoiGianBatDau { get; set; }

    public int? IdChuDe { get; set; }

    public int? SoCauHoi { get; set; }

    public int? SoCauDe { get; set; }

    public int? SoCauTrungBinh { get; set; }

    public int? SoCauKho { get; set; }

    public double? DiemCauDe { get; set; }

    public double? DiemCauTrungBinh { get; set; }

    public double? DiemCauKho { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public int IdSinhVien { get; set; }

    public virtual TbLoaiCauHoi? SoLanToiDaNavigation { get; set; }

    public virtual ICollection<TbBaiThiCauHoi> TbBaiThiCauHois { get; set; } = new List<TbBaiThiCauHoi>();

    public virtual ICollection<TbBaiThiChuDe> TbBaiThiChuDes { get; set; } = new List<TbBaiThiChuDe>();

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
