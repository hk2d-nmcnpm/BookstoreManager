using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoCongNoTable:DBConnection
    {
        public BaoCaoCongNoTable() : base() { }

        public bool AddBaoCaoCongNo(BaoCaoCongNo bccn)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "insert into BaoCaoCongNo values(@MaBaoCao,@Thang,@Nam)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaBaoCao", SqlDbType.Char).Value = bccn.MaBaoCaoCongNo;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = bccn.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = bccn.Nam;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return false;
        }


        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = "select * from BaoCaoCongNo";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                SqlDataAdapter sqadt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqadt.Fill(dt);
                _connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return null;
        }

        public DataTable ThongKeBaoCaoCongNo(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = @"SELECT ThongKe.MaKhachHang, KhachHang.HoTenKH ,ThongKe.NoDau, ThongKe.PhatSinh, ThongKe.NoCuoi
FROM
(
	SELECT TOP 100 PERCENT ISNULL(ThangTruoc.MaKhachHang, ThangNay.MaKhachHang) as MaKhachHang, ISNULL(ThangTruoc.TienPhatSinh,0) as NoDau, ISNULL(ThangNay.TienPhatSinh,0) as PhatSinh,
	ISNULL(ThangTruoc.TienPhatSinh,0) + ISNULL(ThangNay.TienPhatSinh,0) as NoCuoi
	 FROM 
	 (
		 SELECT ISNULL(CTMua.MaKhachHang,CTThu.MaKhachHang) as MaKhachHang, ISNULL(CTMua.TongThanhTien,0) - ISNULL(CTThu.TongTienThu,0)-SumDaTra as TienPhatSinh
		 FROM
		 (
			SELECT HDThanhTien.MaKhachHang, SUM(HDThanhTien.ThanhTien) TongThanhTien,SUM(distinct TienKhachDaTra) as SumDaTra
			FROM
			(
				SELECT MaKhachHang, SoLuongBan*DonGiaBan as ThanhTien, TienKhachDaTra
				FROM CHITIETHOADON, HOADON
				WHERE HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon AND MONTH(HOADON.NgayHoaDon) = @thang AND YEAR(HOADON.NgayHoaDon) = @nam
			) as HDThanhTien

			GROUP BY HDThanhTien.MaKhachHang

		 ) as CTMua
		 FULL JOIN
		 (
			SELECT MaKhachHang, SUM(SoTienThu) as TongTienThu
			FROM PHIEUTHU
			WHERE MONTH(PhieuThu.NgayThu) = @thang AND YEAR(PhieuThu.NgayThu) = @nam
			GROUP BY MaKhachHang
		 ) as CTThu 
		 ON CTMua.MaKhachHang = CTThu.MaKhachHang
	 ) as ThangNay

	 FULL JOIN

	 (
		 SELECT ISNULL(CTMua.MaKhachHang,CTThu.MaKhachHang) as MaKhachHang, ISNULL(CTMua.TongThanhTien,0) - ISNULL(CTThu.TongTienThu,0)-SumDaTra as TienPhatSinh
		 FROM
		 (
			SELECT HDThanhTien.MaKhachHang, SUM(HDThanhTien.ThanhTien) as TongThanhTien,SUM(DISTINCT TienKhachDaTra) as sumdatra
			FROM
			(
				SELECT MaKhachHang, SoLuongBan*DonGiaBan as ThanhTien,TienKhachDaTra
				FROM ChiTietHoaDon, HoaDon
				WHERE  HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon AND
				((YEAR(HoaDon.NgayHoaDon) < @nam) OR (YEAR(HoaDon.NgayHoaDon) = @nam	AND	MONTH(HoaDon.NgayHoaDon) <@thang))
			) as HDThanhTien
			GROUP BY HDThanhTien.MaKhachHang
		 ) as CTMua
		 FULL JOIN
		 (
			SELECT MaKhachHang, SUM(SoTienThu) as TongTienThu
			FROM PhieuThu
			WHERE  ((YEAR(PhieuThu.NgayThu) < @nam) OR (YEAR(PhieuThu.NgayThu) = @nam AND MONTH(PhieuThu.NgayThu) <@thang))
			GROUP BY MaKhachHang
		 ) as CTThu 
		 ON CTMua.MaKhachHang = CTThu.MaKhachHang
	 ) as ThangTruoc
	  ON ThangNay.MaKhachHang = ThangTruoc.MaKhachHang

 ) as ThongKe, KhachHang


WHERE KhachHang.MaKhachHang = ThongKe.MaKhachHang
ORDER BY KhachHang.MaKhachHang ASC";


                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;
                SqlDataAdapter sqdat = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqdat.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return null;
        }

        public bool IsRowExists(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "select * from BaoCaoCongNo where Thang=@thang and Nam=@nam";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                _connection.Close();
                sqa.Fill(dt);
                if (dt.Rows.Count > 0) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return false;
        }

        public bool UpdateBaoCao(BaoCaoCongNo bccn)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "update BaoCaoCongNo" +
                    "set Thang=@Thang," +
                    "Nam=@Nam" +
                    "where MaBaoCaoCongNo=@MaBaoCaoCongNo";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@MaBaoCaoCongNo", SqlDbType.Char).Value = bccn.MaBaoCaoCongNo;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = bccn.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = bccn.Nam;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
            }
            return false;
        }

        public BaoCaoCongNo GetBaoCaoFromThangNam(int thang, int nam)
        {

            try
            {
                var obj = new BaoCaoCongNo();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoCongNo WHERE Thang = @thang and Nam=@nam", _connection);
                command.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaBaoCaoCongNo = reader["MaBaoCaoCongNo"].ToString();
                    obj.Thang = int.Parse(reader["Thang"].ToString());
                    obj.Nam = int.Parse(reader["Nam"].ToString());
                    reader.Close();
                }
                _connection.Close();
                return obj;
            }
            catch
            (Exception ex)
            {
                _connection.Close();
            }
            return null;
        }
    }
}
