using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbMonHoc
{
    [DisplayName("Id Môn Học")]
    public int IdMonHoc { get; set; }
    [DisplayName("Tên Môn Học")]
    public string? TenMonHoc { get; set; }
    [DisplayName("Id Khoa")]
    public int? IdKhoa { get; set; }
    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbKhoa? IdKhoaNavigation { get; set; }

    public virtual ICollection<TbChuDe> TbChuDes { get; set; } = new List<TbChuDe>();
}
