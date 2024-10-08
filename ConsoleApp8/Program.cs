//Tran Bao Quan - 21810310025
using System;
using System.Collections.Generic;

// 1. Lớp trừu tượng PhuongTien
abstract class PhuongTien
{
    public string TenPhuongTien { get; set; }
    public string LoaiNhienLieu { get; set; }

    public PhuongTien(string tenPhuongTien, string loaiNhienLieu)
    {
        TenPhuongTien = tenPhuongTien;
        LoaiNhienLieu = loaiNhienLieu;
    }

    // Phương thức trừu tượng DiChuyen
    public abstract void DiChuyen();
}

// 3. Giao diện IThongTinThem
interface IThongTinThem
{
    int TocDoToiDa(); // Tốc độ tối đa của phương tiện
    double MucTieuThuNhienLieu(); // Mức tiêu thụ nhiên liệu (lít/100km)
}

// 2. Lớp con XeHoi
class XeHoi : PhuongTien, IThongTinThem
{
    public XeHoi(string tenPhuongTien, string loaiNhienLieu)
        : base(tenPhuongTien, loaiNhienLieu) { }

    public override void DiChuyen()
    {
        Console.WriteLine($"{TenPhuongTien} di chuyen bang dong co chay {LoaiNhienLieu}.");
    }

    // Hiện thực giao diện IThongTinThem
    public int TocDoToiDa()
    {
        return 180; // Ví dụ tốc độ tối đa của xe hơi là 180 km/h
    }

    public double MucTieuThuNhienLieu()
    {
        return 8.5; // Ví dụ mức tiêu thụ nhiên liệu của xe hơi là 8.5 lít/100km
    }
}

// 2. Lớp con XeDap
class XeDap : PhuongTien, IThongTinThem
{
    public XeDap(string tenPhuongTien)
        : base(tenPhuongTien, "Khong co") { }

    public override void DiChuyen()
    {
        Console.WriteLine($"{TenPhuongTien} di chuyen bang suc nguoi.");
    }

    // Hiện thực phương thức của giao diện IThongTinThem
    public int TocDoToiDa()
    {
        return 30; // Ví dụ tốc độ tối đa của xe đạp là 30 km/h
    }

    // Vì XeDap không dùng nhiên liệu nên không hiện thực MucTieuThuNhienLieu
    public double MucTieuThuNhienLieu()
    {
        throw new NotImplementedException("Xe dap khong su dung nhien lieu.");
    }
}

// 4. Chương trình chính
class Program
{
    static void Main(string[] args)
    {
        List<PhuongTien> danhSachPhuongTien = new List<PhuongTien>
        {
            new XeHoi("Toyota", "Xang"),
            new XeDap("Xe dap dia hinh")
        };

        foreach (var phuongTien in danhSachPhuongTien)
        {
            Console.WriteLine($"Phuong tien: {phuongTien.TenPhuongTien}");
            phuongTien.DiChuyen();

            // Kiểm tra nếu phương tiện là xe hơi để lấy thông tin thêm
            if (phuongTien is IThongTinThem thongTin)
            {
                Console.WriteLine($"Toc do toi da: {thongTin.TocDoToiDa()} km/h");
                try
                {
                    Console.WriteLine($"Muc tieu thu nhien lieu: {thongTin.MucTieuThuNhienLieu()} lít/100km");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Xe nay khong su dung nhien lieu.");
                }
            }
            Console.WriteLine();
        }
    }
}
