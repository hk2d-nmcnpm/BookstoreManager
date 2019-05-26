using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataTransferObject;

namespace UnitTestProject
{
    [TestClass]
    public class TheLoaiSachTableTest
    {

        TheLoaiSachTable theLoaiSachTable;
        [TestInitialize]
        public void TestInit()
        {
            theLoaiSachTable = new TheLoaiSachTable();
        }
        [TestMethod]
        public void AddRowTest()
        {
            TheLoaiSach theLoai = new TheLoaiSach()
            {
                MaTheLoai = "TL02",
                TenTheLoai = "Sách Giáo Khoa",
            };
            Assert.IsTrue(theLoaiSachTable.AddRow(theLoai));
        }
        [TestMethod]
        public void GetRowTest()
        {
            Assert.AreEqual(theLoaiSachTable.GetRows(1).Rows.Count, 1);
        }
        [TestMethod]
        public void DeleteRowTest()
        {
            Assert.IsTrue(theLoaiSachTable.DeleteRow("TL02"));
        }
    }
}
