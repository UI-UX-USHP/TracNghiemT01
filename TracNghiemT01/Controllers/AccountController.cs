using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TracNghiemT01.Models;
using TracNghiemT01.ViewModels;

namespace TracNghiemT01.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbTracNghiemContext _context;

        public AccountController(DbTracNghiemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Nếu đã đăng nhập rồi thì chuyển về trang chủ tương ứng
            if (User.Identity.IsAuthenticated)
            {
                var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                return RedirectToActionByRole(role);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool isAuthenticated = false;
            string hoTen = "";
            int userId = 0;

            switch (model.Role.ToLower())
            {
                case "admin":
                    var admin = await _context.Admins
                        .FirstOrDefaultAsync(a =>
                            a.TenDangNhap == model.TenDangNhap &&
                            a.MatKhau == model.MatKhau);
                    if (admin != null)
                    {
                        isAuthenticated = true;
                        hoTen = admin.HoTen ?? admin.TenDangNhap;
                        userId = admin.Id;
                    }
                    break;

                case "giangvien":
                    var giangVien = await _context.TbGiangViens
                        .FirstOrDefaultAsync(gv =>
                            gv.TenDangNhap == model.TenDangNhap &&
                            gv.MatKhau == model.MatKhau);
                    if (giangVien != null)
                    {
                        isAuthenticated = true;
                        hoTen = giangVien.HoTen ?? giangVien.TenDangNhap;
                        userId = giangVien.IdNguoiDung;
                    }
                    break;

                case "sinhvien":
                    var sinhVien = await _context.TbSinhViens
                        .FirstOrDefaultAsync(sv =>
                            sv.TenDangNhap == model.TenDangNhap &&
                            sv.MatKhau == model.MatKhau);
                    if (sinhVien != null)
                    {
                        isAuthenticated = true;
                        hoTen = sinhVien.TenDangNhap;
                        userId = sinhVien.IdSinhVien;
                    }
                    break;
            }

            if (!isAuthenticated)
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.TenDangNhap),
                new Claim(ClaimTypes.Role, model.Role),
                new Claim("HoTen", hoTen),
                new Claim("UserId", userId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Cấu hình thời gian cookie tồn tại
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Cookie sẽ được giữ lại sau khi đóng trình duyệt
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) // Cookie hết hạn sau 8 giờ
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);

            return RedirectToActionByRole(model.Role);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // Cũng thêm phương thức GET để xử lý link đăng xuất thông thường
        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Login");
        }
        // Thêm vào class AccountController sau phương thức Logout

        [HttpGet]
        public IActionResult Register()
        {
            // Lấy danh sách khoa cho dropdown
            ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
                return View(model);
            }

            try
            {
                // Kiểm tra tên đăng nhập đã tồn tại
                var userExists = await _context.Admins.AnyAsync(x => x.TenDangNhap == model.TenDangNhap) ||
                                await _context.TbGiangViens.AnyAsync(x => x.TenDangNhap == model.TenDangNhap) ||
                                await _context.TbSinhViens.AnyAsync(x => x.TenDangNhap == model.TenDangNhap);

                if (userExists)
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại");
                    ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
                    return View(model);
                }

                switch (model.Role.ToLower())
                {
                    case "giangvien":
                        if (model.IdKhoa == null)
                        {
                            ModelState.AddModelError("IdKhoa", "Vui lòng chọn khoa");
                            ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
                            return View(model);
                        }

                        var giangVien = new TbGiangVien
                        {
                            TenDangNhap = model.TenDangNhap,
                            MatKhau = model.MatKhau,
                            HoTen = model.HoTen,
                            Email = model.Email,
                            Sdt = model.Sdt,
                            IdKhoa = model.IdKhoa,                        
                            TonTai = 1,
                            ThuTuHienThi = 0
                        };
                        _context.TbGiangViens.Add(giangVien);
                        break;

                    case "sinhvien":
                        var sinhVien = new TbSinhVien
                        {
                            // Bỏ IdSinhVien vì nó sẽ tự động tăng
                            TenDangNhap = model.TenDangNhap,
                            MatKhau = model.MatKhau,
                            Email = model.Email,
                            Sdt = model.Sdt,
                            TrangThai = "Active",
                            TonTai = 1,
                            ThuTuHienThi = 0,
                            IdBaiThi = 1  // Cần đảm bảo có bài thi với ID này trong database
                        };
                        _context.TbSinhViens.Add(sinhVien);
                        break;
                        
                    default:
                        ModelState.AddModelError("", "Vai trò không hợp lệ");
                        ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
                        return View(model);
                }

                await _context.SaveChangesAsync();

                // Thông báo đăng ký thành công
                TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                // Log error here
                ModelState.AddModelError("", "Có lỗi xảy ra trong quá trình đăng ký. Vui lòng thử lại sau.");
                ViewBag.Khoas = new SelectList(_context.TbKhoas, "IdKhoa", "TenKhoa");
                return View(model);
            }
        }

        private IActionResult RedirectToActionByRole(string role)
        {
            switch (role?.ToLower())
            {
                case "admin":
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                case "giangvien":
                    return RedirectToAction("Index", "Home", new { area = "GiangVien" });
                case "sinhvien":
                    return RedirectToAction("Index", "Home", new { area = "SinhVien" });
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}