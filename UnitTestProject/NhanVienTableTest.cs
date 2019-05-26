using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataTransferObject;

namespace UnitTestProject
{
    [TestClass]
    public class NhanVienTableTest
    {
        NhanVienTable nvt;
        [TestInitialize]
        public void TestInit()
        {
            nvt = new NhanVienTable();
        }
        [TestMethod]
        public void AddRowTest()
        {
            var nv = new NhanVien
            {
                MaNhanVien = "NV01",
                TenNhanVien = "Nguyễn Văn A",
                NgaySinh = new DateTime(1999, 1, 1),
                ChucVu = 0,
                MatKhau = "revrfrefrgresbvbvsre42423",
            };
            Assert.IsTrue(nvt.AddRow(nv));
        }
        [TestMethod]
        public void GetRow()
        {
            var count = nvt.GetRows(1).Rows.Count;
            Assert.AreEqual(count, 1);
        }
        [TestMethod]
        public void DeleteRowTest()
        {
            Assert.IsTrue(nvt.DeleteRow("NV01"));
        }
    }
}
