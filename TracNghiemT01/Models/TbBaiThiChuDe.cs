using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbBaiThiChuDe
{
    public int IdBaiThiChuDe { get; set; }

    public int? IdBaiThi { get; set; }

    public int? IdChuDe { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbChuDe? IdChuDeNavigation { get; set; }
}
