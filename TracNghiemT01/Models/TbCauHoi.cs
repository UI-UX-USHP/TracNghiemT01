using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbCauHoi
{
    [DisplayName("Id Câu Hỏi")]
    public int IdCauHoi { get; set; }
    [DisplayName("Id Chủ Đề")]
    public int? IdChuDe { get; set; }
    [DisplayName("Id Mức Độ Khó")]
    public int? IdMucDoKho { get; set; }
    [DisplayName("Nội Dung Câu Hỏi")]
    public string? NoiDung { get; set; }
    [DisplayName("Ưu Tiên Sử Dụng")]
    public bool? UuTienSuDung { get; set; }
    [DisplayName("Chỉ Định Dặc Biệt")]
    public bool? ChiDinhDacBiet { get; set; }
    [DisplayName("Id Loại Câu Hỏi")]
    public int? IdLoaiCauHoi { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbChuDe? IdChuDeNavigation { get; set; }

    public virtual TbLoaiCauHoi? IdLoaiCauHoiNavigation { get; set; }

    public virtual TbMucDoKho? IdMucDoKhoNavigation { get; set; }

    public virtual ICollection<TbBaiThiCauHoi> TbBaiThiCauHois { get; set; } = new List<TbBaiThiCauHoi>();

    public virtual ICollection<TbDapAn> TbDapAns { get; set; } = new List<TbDapAn>();

    public virtual ICollection<TbKetQuaChiTiet> TbKetQuaChiTiets { get; set; } = new List<TbKetQuaChiTiet>();
}
