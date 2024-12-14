using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbLoaiCauHoi
{
    [DisplayName("Id Loại Câu Hỏi")]
    public int IdLoaiCauHoi { get; set; }
    [DisplayName("Loại Câu Hỏi")]
    public string? LoaiCauHoi { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }
    public virtual ICollection<TbBaiThi> TbBaiThis { get; set; } = new List<TbBaiThi>();

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
