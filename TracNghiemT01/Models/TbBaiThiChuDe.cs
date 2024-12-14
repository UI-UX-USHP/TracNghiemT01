using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbBaiThiChuDe
{
    [DisplayName("Id Bài Thi Chủ Đề")]
    public int IdBaiThiChuDe { get; set; }
    [DisplayName("Id Bài Thi")]
    public int? IdBaiThi { get; set; }
    [DisplayName("Id Chủ Đề")]
    public int? IdChuDe { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbChuDe? IdChuDeNavigation { get; set; }
}
