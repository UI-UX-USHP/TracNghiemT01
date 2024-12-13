using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbBaiThiCauHoi
{
    public int IdBaiThiCauHoi { get; set; }

    public int? IdCauHoi { get; set; }

    public int? IdBaiThi { get; set; }

    public double? Diem { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbCauHoi? IdCauHoiNavigation { get; set; }
}
