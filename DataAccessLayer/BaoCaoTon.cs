using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoTonTable: DBConnection
    {
        public BaoCaoTonTable() : base() { }
        public bool AddBaoCaoTon(BaoCaoTon bct)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "insert into BaoCaoTon values(@MaBaoCao,@Thang,@Nam)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaBaoCao", SqlDbType.Char).Value = bct.MaBaoCaoTon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = bct.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = bct.Nam;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return false;
        }
        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = "select * from BaoCaoTon";
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

        public DataTable ThongKeBaoCaoTon(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = @"SELECT  ThongKeSach.MaSach,TongSach.TenSach, ThongKeSach.TonDau, ThongKeSach.PhatSinh, ThongKeSach.TonCuoi
FROM
(
	SELECT TOP 100 PERCENT ISNULL(TonThangNay.MaSach, TonTruoc.MaSach) as MaSach, ISNULL(TonTruoc.SLSachTon, 0) as TonDau, ISNULL(TonThangNay.SLSachTon, 0) as PhatSinh 
	,ISNULL(TonThangNay.SLSachTon , 0) + ISNULL(TonTruoc.SLSachTon , 0) as TonCuoi
	FROM 
	(
		 SELECT ISNULL(CTBan.MaSach,CTNhap.MaSach) as MaSach,  ISNULL(CTNhap.SLSach,0)- ISNULL(CTBan.SLSach,0) as SLSachTon
		FROM   
		(
		  SELECT ChiTietHoaDon.MaSach, SUM(ChiTietHoaDon.SoLuongBan) as SLSach
		  FROM ChiTietHoaDon, HoaDon
		  WHERE ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon AND MONTH(HoaDon.NgayHoaDon) = @thang AND YEAR(HoaDon.NgayHoaDon) = @nam
		  GROUP BY ChiTietHoaDon.MaSach
		) as CTBan
		FULL JOIN
		(
			  SELECT ChiTietPhieuNhapSach.MaSach, SUM(ChiTietPhieuNhapSach.SoLuongNhap) as SLSach
			  FROM ChiTietPhieuNhapSach, PhieuNhapSach
			  WHERE ChiTietPhieuNhapSach.MaPhieuNhapSach = PhieuNhapSach.MaPhieuNhapSach AND MONTH(PhieuNhapSach.NgayNhap) = @thang AND YEAR(PhieuNhapSach.NgayNhap) = @nam 
			  GROUP BY ChiTietPhieuNhapSach.MaSach
		) as CTNhap
		ON CTBan.MaSach = CTNhap.MaSach
	) as TonThangNay

	FULL JOIN

	(
		 SELECT ISNULL(CTBan.MaSach,CTNhap.MaSach) as MaSach,  ISNULL(CTNhap.SLSach,0)- ISNULL(CTBan.SLSach,0) as SLSachTon
		FROM  
		(
		  SELECT ChiTietHoaDon.MaSach, SUM(ChiTietHoaDon.SoLuongBan) as SLSach
		  FROM ChiTietHoaDon, HoaDon
		  WHERE ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon AND
		 ( (YEAR(HoaDon.NgayHoaDon) < @nam) OR	 (	YEAR(HoaDon.NgayHoaDon) = @nam AND MONTH(HoaDon.NgayHoaDon) <@thang )  )
		 GROUP BY ChiTietHoaDon.MaSach
		) as CTBan 
		FULL JOIN  
		(
			SELECT ChiTietPhieuNhapSach.MaSach, SUM(ChiTietPhieuNhapSach.SoLuongNhap) as SLSach
			FROM ChiTietPhieuNhapSach, PhieuNhapSach
			WHERE  ChiTietPhieuNhapSach.MaPhieuNhapSach = PhieuNhapSach.MaPhieuNhapSach  AND
			   ( (YEAR(PhieuNhapSach.NgayNhap) < @nam) OR (	YEAR(PhieuNhapSach.NgayNhap) = @nam	AND	MONTH(PhieuNhapSach.NgayNhap) <@thang) )	  
			GROUP BY ChiTietPhieuNhapSach.MaSach
		) as CTNhap
		ON CTBan.MaSach = CTNhap.MaSach
	) as TonTruoc
	ON TonThangNay.MaSach = TonTruoc.MaSach

 ) as ThongKeSach, Sach as TongSach
 
WHERE ThongKeSach.MaSach = TongSach.MaSach
ORDER BY TongSach.MaSach ASC";


                SqlCommand cmd = new SqlCommand(query, _connection);
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
                string query = "select * from BaoCaoTon where Thang=@thang and Nam=@nam";
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

        public bool UpdateBaoCao(BaoCaoTon bccn)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "update BaoCaoTon" +
                    "set Thang=@Thang," +
                    "Nam=@Nam" +
                    "where MaBaoCaoTon=@MaBaoCaoTon";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@MaBaoCaoTon", SqlDbType.Char).Value = bccn.MaBaoCaoTon;
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

        public BaoCaoTon GetBaoCaoFromThangNam(int thang, int nam)
        {

            try
            {
                var obj = new BaoCaoTon();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoTon WHERE Thang = @thang and Nam=@nam", _connection);
                command.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaBaoCaoTon = reader["MaBaoCaoTon"].ToString();
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
