using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbBaiThi
{
    [DisplayName("Id Bài thi")]
    public int IdBaiThi { get; set; }
    [DisplayName("Tên Bài Thi")]
    public string? TenBaiThi { get; set; }
    [DisplayName("Số Lần Thi Tối Đa")]
    public int? SoLanToiDa { get; set; }
    [DisplayName("Thời gian")]
    public TimeOnly? ThoiGian { get; set; }
    [DisplayName("Thời gian bắt đầu")]
    public DateTime? ThoiGianBatDau { get; set; }
    public int? IdChuDe { get; set; }
    [DisplayName("Số Câu Hỏi")]
    public int? SoCauHoi { get; set; }
    [DisplayName("Số Câu Dễ")]
    public int? SoCauDe { get; set; }
    [DisplayName("Số Câu Trung Bình")]
    public int? SoCauTrungBinh { get; set; }
    [DisplayName("Số Câu Khó")]
    public int? SoCauKho { get; set; }
    [DisplayName("Điểm Câu Dễ")]
    public double? DiemCauDe { get; set; }
    [DisplayName("Điểm Câu Trung Bình")]
    public double? DiemCauTrungBinh { get; set; }
    [DisplayName("Điểm Câu Khó")]
    public double? DiemCauKho { get; set; }
    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }
    [DisplayName("Id Sinh Viên")]
    public int IdSinhVien { get; set; }

    public virtual TbLoaiCauHoi? SoLanToiDaNavigation { get; set; }

    public virtual ICollection<TbBaiThiCauHoi> TbBaiThiCauHois { get; set; } = new List<TbBaiThiCauHoi>();

    public virtual ICollection<TbBaiThiChuDe> TbBaiThiChuDes { get; set; } = new List<TbBaiThiChuDe>();

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
