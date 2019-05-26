using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataTransferObject;

namespace UnitTestProject
{
    [TestClass]
    public class SachTableTest
    {
        SachTable sachTable;
        [TestInitialize]
        public void TestInit()
        {
            sachTable = new SachTable();
        }
        [TestMethod]
        public void AddRowTest()
        {
            
            Sach sach = new Sach()
            {
                MaSach = "B0009",
                TenSach = "Ten Sach Thu Nghiem",
                TacGia = "TacGia1",
                DonGia = 20000,
                MaTheLoai = "TL01",
                SoLuongTon = 30,
                AnhBia = null,
                SoTrang = 20,
                MoTa = "Noi dung mo ta",
                NamXuatBan = 2019,
                NhaXuatBan = "NXB NhaXuatBan",
            };
            Assert.IsTrue(sachTable.AddRow(sach));
        }
        [TestMethod]
        public void GetRowTest()
        {
            var count = sachTable.GetRows(1).Rows.Count;
            Assert.AreEqual(count, 1);
        }
        [TestMethod]
        public void DeleteRowTest()
        {
            Assert.IsTrue(sachTable.DeleteRow("B0009"));
        }

    }
}
