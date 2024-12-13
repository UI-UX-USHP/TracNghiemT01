using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TònTai { get; set; }
}
