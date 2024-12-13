using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbMonHoc
{
    public int IdMonHoc { get; set; }

    public string? TenMonHoc { get; set; }

    public int? IdKhoa { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbKhoa? IdKhoaNavigation { get; set; }

    public virtual ICollection<TbChuDe> TbChuDes { get; set; } = new List<TbChuDe>();
}
