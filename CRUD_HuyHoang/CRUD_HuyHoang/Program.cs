using CRUD_HuyHoang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
class Program
{
    static SqlConnection connection = null;

    static void Main(string[] args)
    {
        Connect();
        Menu();
        Disconnect();
    }

    static void Connect()
    {
        string connectionString = "Data Source=(local);Initial Catalog=CRUD_DB;Integrated Security=True";
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    static void Disconnect()
    {
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }

    static void Menu()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("==== MENU ====");
            Console.WriteLine("1. Công nhân");
            Console.WriteLine("2. Ca làm");
            Console.WriteLine("3. Bản đăng ký");
            Console.WriteLine("0. Thoát");
            Console.Write("Lựa chọn: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CongNhanMenu();
                    break;
                case 2:
                    CaLamMenu();
                    break;
                case 3:
                    BanDangKyMenu();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    break;
            }
        }
    }

    static void CongNhanMenu()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("==== CÔNG NHÂN ====");
            Console.WriteLine("1. Xem danh sách công nhân");
            Console.WriteLine("2. Thêm công nhân");
            Console.WriteLine("3. Sửa công nhân");
            Console.WriteLine("4. Xóa công nhân");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewCongNhan();
                    break;
                case 2:
                    AddCongNhan();
                    break;
                case 3:
                    UpdateCongNhan();
                case 4:
                    DeleteCongNhan();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    break;
            }
        }
    }

    static void CaLamMenu()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("==== CA LÀM ====");
            Console.WriteLine("1. Xem danh sách ca làm");
            Console.WriteLine("2. Thêm ca làm");
            Console.WriteLine("3. Sửa ca làm");
            Console.WriteLine("4. Xóa ca làm");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewCaLam();
                    break;
                case 2:
                    AddCaLam();
                    break;
                case 3:
                    UpdateCaLam();
                    break;
                case 4:
                    DeleteCaLam();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    break;
            }
        }
    }

    static void BanDangKyMenu()
    {
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("==== BẢN ĐĂNG KÝ ====");
            Console.WriteLine("1. Xem danh sách bản đăng ký");
            Console.WriteLine("2. Thêm bản đăng ký");
            Console.WriteLine("3. Sửa bản đăng ký");
            Console.WriteLine("4. Xóa bản đăng ký");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewBanDangKy();
                    break;
                case 2:
                    AddBanDangKy();
                    break;
                case 3:
                    UpdateBanDangKy();
                    break;
                case 4:
                    DeleteBanDangKy();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    break;
            }
        }
    }

    static void ViewCongNhan()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM CongNhan", connection);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("==== DANH SÁCH CÔNG NHÂN ====");
        while (reader.Read())
        {
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", reader["maCN"], reader["tenCN"], reader["ngaySinh"], reader["gioiTinh"], reader["diaChi"]);
        }
        reader.Close();
    }

    static void AddCongNhan()
    {
        Console.WriteLine("==== THÊM CÔNG NHÂN ====");
        Console.Write("Nhập mã công nhân: ");
        string maCN = Console.ReadLine();
        Console.Write("Nhập tên công nhân: ");
        string tenCN = Console.ReadLine();
        Console.Write("Nhập ngày sinh: ");
        string ngaySinh = Console.ReadLine();
        Console.Write("Nhập giới tính: ");
        string gioiTinh = Console.ReadLine();
        Console.Write("Nhập địa chỉ: ");
        string diaChi = Console.ReadLine();

        SqlCommand command = new SqlCommand("INSERT INTO CongNhan (maCN, tenCN, ngaySinh, gioiTinh, diaChi) VALUES (@maCN, @tenCN, @ngaySinh, @gioiTinh, @diaChi)", connection);
        command.Parameters.AddWithValue("@maCN", maCN);
        command.Parameters.AddWithValue("@tenCN", tenCN);
        command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        command.Parameters.AddWithValue("@diaChi", diaChi);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Thêm công nhân thành công");
        }
        else
        {
            Console.WriteLine("Thêm công nhân thất bại");
        }
    }

    static void UpdateCongNhan()
    {
        Console.WriteLine("==== SỬA CÔNG NHÂN ====");
        Console.Write("Nhập mã công nhân cần sửa: ");
        string maCN = Console.ReadLine();
        Console.Write("Nhập tên công nhân mới: ");
        string tenCN = Console.ReadLine();
        Console.Write("Nhập ngày sinh mới: ");
        string ngaySinh = Console.ReadLine();
        Console.Write("Nhập giới tính mới: ");
        string gioiTinh = Console.ReadLine();
        Console.Write("Nhập địa chỉ mới: ");
        string diaChi = Console.ReadLine();

        SqlCommand command = new SqlCommand("UPDATE CongNhan SET tenCN = @tenCN, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, diaChi = @diaChi WHERE maCN = @maCN", connection);
        command.Parameters.AddWithValue("@maCN", maCN);
        command.Parameters.AddWithValue("@tenCN", tenCN);
        command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        command.Parameters.AddWithValue("@diaChi", diaChi);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Sửa công nhân thành công");
        }
        else
        {
            Console.WriteLine("Sửa công nhân thất bại");
        }
    }

    static void DeleteCongNhan()
    {
        Console.WriteLine("==== XÓA CÔNG NHÂN ====");
        Console.Write("Nhập mã công nhân cần xóa: ");
        string maCN = Console.ReadLine();

        SqlCommand command = new SqlCommand("DELETE FROM CongNhan WHERE maCN = @maCN", connection);
        command.Parameters.AddWithValue("@maCN", maCN);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Xóa công nhân thành công");
        }
        else
        {
            Console.WriteLine("Xóa công nhân thất bại");
        }
    }

    static void ViewCaLam()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM CaLam", connection);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("==== DANH SÁCH CA LÀM ====");
        while (reader.Read())
        {
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", reader["maCa"], reader["tenCa"], reader["thoiGianBatDau"], reader["thoiGianKetThuc"], reader["maCN"]);
        }
        reader.Close();
    }

    static void AddCaLam()
    {
        Console.WriteLine("==== THÊM CA LÀM ====");
        Console.Write("Nhập mã ca làm: ");
        (maCN, tenCN, ngaySinh, gioiTinh, diaChi) VALUES(@maCN, @tenCN, @ngaySinh, @gioiTinh, @diaChi)", connection);
        command.Parameters.AddWithValue("@maCN", maCN);
        command.Parameters.AddWithValue("@tenCN", tenCN);
        command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        command.Parameters.AddWithValue("@diaChi", diaChi);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Thêm công nhân thành công");
        }
        else
        {
            Console.WriteLine("Thêm công nhân thất bại");
        }
    }

    static void UpdateCongNhan()
    {
        Console.WriteLine("==== SỬA CÔNG NHÂN ====");
        Console.Write("Nhập mã công nhân cần sửa: ");
        string maCN = Console.ReadLine();
        Console.Write("Nhập tên công nhân mới: ");
        string tenCN = Console.ReadLine();
        Console.Write("Nhập ngày sinh mới: ");
        string ngaySinh = Console.ReadLine();
        Console.Write("Nhập giới tính mới: ");
        string gioiTinh = Console.ReadLine();
        Console.Write("Nhập địa chỉ mới: ");
        string diaChi = Console.ReadLine();

        SqlCommand command = new SqlCommand("UPDATE CongNhan SET tenCN = @tenCN, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, diaChi = @diaChi WHERE maCN = @maCN", connection);
        command.Parameters.AddWithValue("@maCN", maCN);
        command.Parameters.AddWithValue("@tenCN", tenCN);
        command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        command.Parameters.AddWithValue("@diaChi", diaChi);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Sửa công nhân thành công");
        }
        else
        {
            Console.WriteLine("Sửa công nhân thất bại");
        }
    }

    static void DeleteCongNhan()
    {
        Console.WriteLine("==== XÓA CÔNG NHÂN ====");
        Console.Write("Nhập mã công nhân cần xóa: ");
        string maCN = Console.ReadLine();

        SqlCommand command = new SqlCommand("DELETE FROM CongNhan WHERE maCN = @maCN", connection);
        command.Parameters.AddWithValue("@maCN", maCN);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Xóa công nhân thành công");
        }
        else
        {
            Console.WriteLine("Xóa công nhân thất bại");
        }
    }

    static void ViewCaLam()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM CaLam", connection);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("==== DANH SÁCH CA LÀM ====");
        while (reader.Read())
        {
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", reader["maCa"], reader["tenCa"], reader["thoiGianBatDau"], reader["thoiGianKetThuc"], reader["maCN"]);
        }
        reader.Close();
    }

    static void AddCaLam()
    {
        Console.WriteLine("==== THÊM CA LÀM ====");
        Console.Write("Nhập mã ca làm: ");
        string maCa = Console.ReadLine();
        Console.Write("Nhập tên ca làm: ");
        string tenCa = Console.ReadLine();
        Console.Write("Nhập thời gian bắt đầu: ");
        string thoiGianBatDau = Console.ReadLine();
        Console.Write("Nhập thời gian kết thúc: ");
        string thoiGianKetThuc = Console.ReadLine();
        Console.Write("Nhập mã công nhân: ");
        string maCN = Console.ReadLine();

        SqlCommand command = new SqlCommand("INSERT INTO CaLam (maCa, tenCa, thoiGianBatDau, thoiGianKetThuc, maCN) VALUES (@maCa, @tenCa, @thoiGianBatDau, @thoiGianKetThuc, @maCN)", connection);
        command.Parameters.AddWithValue("@maCa", maCa);
        command.Parameters.AddWithValue("@tenCa", tenCa);
        command.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
        command.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
        command.Parameters.AddWithValue("@maCN", maCN);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Thêm ca làm thành công");
        }
        else
        {
            Console.WriteLine("Thêm ca làm thất bại");
        }
    }

    static void UpdateCaLam()
    {
        Console.WriteLine("==== SỬA CA LÀM ====");
        Console.Write("Nhập mã ca làm cần sửa: ");
        string maCa = Console.ReadLine();
        Console.Write("Nhập tên ca làm mới: ");
        string tenCa = Console.ReadLine();
        Console.Write("Nhập thời gian bắt đầu mới: ");
        string thoiGianBatDau = Console.ReadLine();
        Console.Write("Nhập thời gian kết thúc mới: ");
        string thoiGianKetThuc = Console.ReadLine();
        Console.Write("Nhập mã công nhân mới: ");
        string maCN = Console.ReadLine();

        SqlCommand command = new SqlCommand("UPDATE CaLam SET tenCa = @tenCa, thoiGianBatDau = @thoiGianBatDau, thoiGianKetThuc = @thoiGianKetThuc, maCN = @maCN WHERE maCa = @maCa", connection);
        command.Parameters.AddWithValue("@maCa", maCa);
        command.Parameters.AddWithValue("@tenCa", tenCa);
        command.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
        command.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
        command.Parameters.AddWithValue("@maCN", maCN);

        int result = command.ExecuteNonQuery();
        if (result > 0)
        {
            Console.WriteLine("Sửa ca làm thành công");
        }
        else
        {
            Console.WriteLine("Sửa ca làm thất bại");
        }
    }

    static void DeleteCaLam()
    {
        Console.WriteLine("==== XÓA CA LÀM ====");
        Console.Write("Nhập mã ca làm cần xóa: ");
        string maCa = Console.ReadLine();

        SqlCommand command = new SqlCommand("DELETE FROM CaLam WHERE maCa = @maCa", connection);
        command.Parameters.AddWithValue("@maCa", maCa);

        int result = command.ExecuteNonQuery();
        if (result >
                 {
            Console.WriteLine("Xóa ca làm thành công");
        }
        else
        {
            Console.WriteLine("Xóa ca làm thất bại");
        }
    }

    static void SelectCaLam()
    {
        Console.WriteLine("==== DANH SÁCH CA LÀM ====");

        SqlCommand command = new SqlCommand("SELECT * FROM CaLam", connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-20} {4,-10}", "Mã ca", "Tên ca", "Thời gian bắt đầu", "Thời gian kết thúc", "Mã CN");
            while (reader.Read())
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-20} {4,-10}", reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }
        }
        else
        {
            Console.WriteLine("Không có dữ liệu");
        }

        reader.Close();
    }
}







