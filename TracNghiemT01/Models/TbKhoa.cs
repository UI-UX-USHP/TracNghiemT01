using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TracNghiemT01.Models;

public partial class TbKhoa
{
    [DisplayName("Id Khoa")]
    public int IdKhoa { get; set; }
    [DisplayName("Tên Khoa")]
    public string? TenKhoa { get; set; }

    public virtual ICollection<TbGiangVien> TbGiangViens { get; set; } = new List<TbGiangVien>();

    public virtual ICollection<TbMonHoc> TbMonHocs { get; set; } = new List<TbMonHoc>();
}
