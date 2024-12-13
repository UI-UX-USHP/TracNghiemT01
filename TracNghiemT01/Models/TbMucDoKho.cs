using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbMucDoKho
{
    public int IdMucDoKho { get; set; }

    public string? TenMucDo { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
