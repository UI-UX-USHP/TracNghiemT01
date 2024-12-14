using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbMucDoKho
{
    [DisplayName("Id Mức Độ Khó")]
    public int IdMucDoKho { get; set; }
    [DisplayName("Tên Mức Độ")]
    public string? TenMucDo { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
