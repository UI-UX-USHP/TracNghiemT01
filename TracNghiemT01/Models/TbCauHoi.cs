using System;
using System.Collections.Generic;

namespace TracNghiemT01.Models;

public partial class TbCauHoi
{
    public int IdCauHoi { get; set; }

    public int? IdChuDe { get; set; }

    public int? IdMucDoKho { get; set; }

    public string? NoiDung { get; set; }

    public bool? UuTienSuDung { get; set; }

    public bool? ChiDinhDacBiet { get; set; }

    public int? IdLoaiCauHoi { get; set; }

    public int? ThuTuHienThi { get; set; }

    public byte? TonTai { get; set; }

    public virtual TbChuDe? IdChuDeNavigation { get; set; }

    public virtual TbLoaiCauHoi? IdLoaiCauHoiNavigation { get; set; }

    public virtual TbMucDoKho? IdMucDoKhoNavigation { get; set; }

    public virtual ICollection<TbBaiThiCauHoi> TbBaiThiCauHois { get; set; } = new List<TbBaiThiCauHoi>();

    public virtual ICollection<TbDapAn> TbDapAns { get; set; } = new List<TbDapAn>();

    public virtual ICollection<TbKetQuaChiTiet> TbKetQuaChiTiets { get; set; } = new List<TbKetQuaChiTiet>();
}
