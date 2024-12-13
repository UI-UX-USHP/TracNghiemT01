using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbLoaiCauHoi
{
    public int IdLoaiCauHoi { get; set; }

    public string? LoaiCauHoi { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual ICollection<TbBaiThi> TbBaiThis { get; set; } = new List<TbBaiThi>();

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
