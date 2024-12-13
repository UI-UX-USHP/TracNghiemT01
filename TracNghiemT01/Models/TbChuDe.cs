using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbChuDe
{
    public int IdChuDe { get; set; }

    public int? IdMonHoc { get; set; }

    public string? TenChuDe { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbMonHoc? IdMonHocNavigation { get; set; }

    public virtual ICollection<TbBaiThiChuDe> TbBaiThiChuDes { get; set; } = new List<TbBaiThiChuDe>();

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
