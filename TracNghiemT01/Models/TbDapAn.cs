using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbDapAn
{
    public int IdDapAn { get; set; }

    public int? IdCauHoi { get; set; }

    public string? NoiDung { get; set; }

    public bool? DapAnDung { get; set; }

    public int? ThuTu { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbCauHoi? IdCauHoiNavigation { get; set; }
}
