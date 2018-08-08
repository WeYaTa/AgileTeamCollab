using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileTeamCollabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTeamCollabLibrary.Tests
{
    [TestClass()]
    public class BarangDAOOfflineTests
    {

        BarangDAOOffline test = new BarangDAOOffline();

        //INSERT
        [TestMethod()]
        public void InsertTest()
        {
            Assert.AreEqual(1, test.Insert("P001", "Melon", 5000, (decimal)5.5));
        }

        //Test tambah barang dengan harga minus
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertHargaMinus()
        {
            test.Insert("P001", "Melon", -5000, (decimal)5.5);
        }

        //Test tambah barang dengan pajak minus
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertPajakMinus()
        {
            test.Insert("P002", "Melon", 5000, (decimal)-5.5);
        }

        //Test tambah barang dengan pajak 0%
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertPajakNol()
        {
            test.Insert("P003", "Melon", 5000, (decimal)0);
        }

        //Test tambah barang dengan pajak > 100%
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertPajakLebih100()
        {
            test.Insert("P004", "Melon", 5000, (decimal)101.5);
        }

        //Test tambah barang tanpa kode
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertKodeKosong()
        {
            test.Insert("", "Melon", 5000, (decimal)10);
        }

        //Test tambah barang tanpa nama
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertNamaKosong()
        {
            test.Insert("P005", "", 5000, (decimal)10);
        }

        //Test tambah barang dengan kode lebih dari 4 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertKodeLebih4Karakter()
        {
            test.Insert("P0011", "Melon", 5000, (decimal)10);
        }

        //Test tambah barang dengan nama lebih dari 50 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertNamaLebih50Karakter()
        {
            test.Insert("P006", "Melonnmmnmnmnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnskgjsheehsaufhukeasfhafwahfwaufgaufihawfl;DPAEIFIAIUKFAJsfjshegiusefnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", 5000, (decimal)5.5);
        }

        //Test tambah barang dengan kode yang sudah ada
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInsertKodeSama()
        {
            test.Insert("P001", "Melon", 5000, (decimal)10);
            test.Insert("P001", "Melon", 5000, (decimal)10);
        }

        //UPDATE
        [TestMethod()]
        public void UpdateTest()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            Assert.AreEqual(1,test.Update("P001", "Semangka", 10000, (decimal)5.5));

        }

        //Test update barang dengan harga minus
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateHargaMinus()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "Semangka", -10000, (decimal)5.5);
        }

        //Test update barang dengan pajak minus
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdatePajakMinus()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "Semangka", 10000, (decimal)-5.5);
        }

        //Test update barang dengan pajak 0%
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdatePajakNol()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "Semangka", 10000, (decimal)0);
        }

        //Test update barang dengan pajak melebihi 100%
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdatePajakLebih100()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "Semangka", 10000, (decimal)105);
        }

        //Test update barang dengan kode kosong
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateKodeKosong()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("", "Semangka", 10000, (decimal)5.5);
        }

        //Test update barang dengan nama kosong
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNamaKosong()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "", 10000, (decimal)5.5);
        }

        //Test update barang dengan kode melebihi 4 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateKodeLebih4Karakter()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P00123", "Semangka", 10000, (decimal)5.5);
        }

        //Test update barang dengan nama melebihi 50 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNamaLebih50Karakter()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Update("P001", "Melonnmmnmnmnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnskgjsheehsaufhukeasfhafwahfwa" +
                "ufgaufihawfl;DPAEIFIAIUKFAJsfjshegiusefnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", 5000, (decimal)5.5);
    
        }

        //GetDataBarang
        [TestMethod()]
        public void GetDataBarangByKodeTest()
        {
            Barang c = new Barang { Kode = "P001", Nama = "Melon", Harga = 5000, Pajak = (decimal)5.5 };
            test.Insert(c.Kode,c.Nama,c.Harga,c.Pajak);
            Assert.AreEqual(c.Kode, test.GetDataBarangByKode("P001").Kode);
            Assert.AreEqual(c.Harga, test.GetDataBarangByKode("P001").Harga);
        }

        //Test cari data barang dengan kode kosong
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetBarangByKodeKosong()
        {
            Barang c = new Barang { Kode = "P001", Nama = "Melon", Harga = 5000, Pajak = (decimal)5.5 };
            test.Insert(c.Kode, c.Nama, c.Harga, c.Pajak);
            Assert.AreEqual(c.Kode, test.GetDataBarangByKode("").Kode);
        }

        //Test cari data barang dengan kode melebihi 4 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetBarangByKodeLebih4Karakter()
        {
            Barang c = new Barang { Kode = "P001", Nama = "Melon", Harga = 5000, Pajak = (decimal)5.5 };
            test.Insert(c.Kode, c.Nama, c.Harga, c.Pajak);
            Assert.AreEqual(c.Kode, test.GetDataBarangByKode("12345").Kode);
        }


        //DELETE
        [TestMethod()]
        public void DeleteTest()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            Assert.AreEqual(test.Delete("P001"), 1);
        }

        //Test delete barang dengan kode kosong
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteKodeKosong()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Delete("");
        }

        //Test delete barang dengan kode melebihi 4 karakter
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteKodeLebih4Karakter()
        {
            test.Insert("P001", "Melon", 5000, (decimal)5.5);
            test.Delete("QWERTY");
        }
    }
}