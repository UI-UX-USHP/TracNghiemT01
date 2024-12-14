using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TracNghiemT01.Models;

public partial class TbKetQua
{
    [DisplayName("Id Kết Quả")]
    public int IdKetQua { get; set; }
    [DisplayName("Id Giảng Viên")]
    public int? IdNguoiDung { get; set; }
    [DisplayName("Id Bài Thi")]
    public int? IdBaiThi { get; set; }
    [DisplayName("Tổng Điểm")]
    public double? TongDiem { get; set; }
    [DisplayName("Thời Gian Nộp")]
    public DateTime? ThoiGianNop { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }
    [DisplayName("Id Sinh Viên")]
    public int? IdSinhVien { get; set; }

    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbGiangVien? IdNguoiDungNavigation { get; set; }

    public virtual TbSinhVien? IdSinhVienNavigation { get; set; }

    public virtual ICollection<TbKetQuaChiTiet> TbKetQuaChiTiets { get; set; } = new List<TbKetQuaChiTiet>();

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
