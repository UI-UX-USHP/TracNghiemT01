using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbChuDe
{
    [DisplayName("Id Chủ Đề")]
    public int IdChuDe { get; set; }
    [DisplayName("Id Môn Học")]
    public int? IdMonHoc { get; set; }
    [DisplayName("Tên Chủ Đề")]
    public string? TenChuDe { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbMonHoc? IdMonHocNavigation { get; set; }

    public virtual ICollection<TbBaiThiChuDe> TbBaiThiChuDes { get; set; } = new List<TbBaiThiChuDe>();

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
