using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbBaiThiCauHoi
{
    [DisplayName("Id Bài Thi Câu Hỏi")]
    public int IdBaiThiCauHoi { get; set; }
    [DisplayName("Id Câu Hỏi")]
    public int? IdCauHoi { get; set; }
    [DisplayName("Id Bài Thi")]
    public int? IdBaiThi { get; set; }
    [DisplayName("Điểm")]
    public double? Diem { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }
    public virtual TbBaiThi? IdBaiThiNavigation { get; set; }

    public virtual TbCauHoi? IdCauHoiNavigation { get; set; }
}
