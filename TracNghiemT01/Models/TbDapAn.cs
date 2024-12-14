using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbDapAn
{
    [DisplayName("Id Đáp án")]
    public int IdDapAn { get; set; }
    [DisplayName("Id Câu Hỏi")]
    public int? IdCauHoi { get; set; }
    [DisplayName("Nội Dung")]
    public string? NoiDung { get; set; }
    [DisplayName("Đáp Án Đúng")]
    public bool? DapAnDung { get; set; }
    [DisplayName("Thứ Tự")]
    public int? ThuTu { get; set; }

    [DisplayName("Thứ Tự Hiển Thị")]
    public int? ThuTuHienThi { get; set; }
    [DisplayName("Tồn Tại")]
    public byte? TonTai { get; set; }

    public virtual TbCauHoi? IdCauHoiNavigation { get; set; }
}
