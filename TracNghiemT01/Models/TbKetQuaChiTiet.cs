using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbKetQuaChiTiet
{
    [DisplayName("Id Kết Quả Chi Tiết")]
    public int IdKetQuaChiTiet { get; set; }
    [DisplayName("Id Kết Quả")]
    public int? IdKetQua { get; set; }
    [DisplayName("Id Câu Hỏi")]
    public int? IdCauHoi { get; set; }
    [DisplayName("Đáp Án Chọn")]
    public string? DapAnChon { get; set; }
    [DisplayName("Đáp Án Điền Khuyết")]
    public string? DapAnDienKhuyet { get; set; }
    [DisplayName("Đáp Án Sắp Xếp Thứ Tự")]
    public string? DapAnSxthuTu { get; set; }

    public bool? IsCorrect { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbCauHoi? IdCauHoiNavigation { get; set; }

    public virtual TbKetQua? IdKetQuaNavigation { get; set; }

    public virtual ICollection<TbSinhVien> TbSinhViens { get; set; } = new List<TbSinhVien>();
}
