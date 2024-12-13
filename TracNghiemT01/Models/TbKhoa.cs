using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbKhoa
{
    public int IdKhoa { get; set; }

    public string? TenKhoa { get; set; }

    public virtual ICollection<TbGiangVien> TbGiangViens { get; set; } = new List<TbGiangVien>();

    public virtual ICollection<TbMonHoc> TbMonHocs { get; set; } = new List<TbMonHoc>();
}
