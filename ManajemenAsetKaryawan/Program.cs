using System;
using System.Data;
using System.Data.SqlClient;
using ManajemenAsetKaryawan.Models;
using ManajemenAsetKaryawan.Controller;

namespace ManajemenAsetKaryawan
{
    class Program
    {
        SqlConnection sqlConnection;
        
        static string connectionString = "Data Source=DESKTOP-PQO8BSH;Initial Catalog=ManajemenAset;User ID = me; Password=12345678;Connect Timeout = 30;";

        
        static void Main(string[] args)
        {
            Program program = new Program();
            AsetController aset = new AsetController(connectionString);
            Console.WriteLine("Hello World!");

            Aset newAset = new Aset();
            //newAset.Name = "Kulkas";
            //newAset.Details = "Pengadaan 2022";
            //newAset.Stock = 10;

            //aset.InsertAset(newAset);
            ////aset.DeleteAset(5);
            ////newAset.Name = "Proyektor Acer";
            ////program.Update(9, newAset);
            ///
            Karyawan newKaryawan = new Karyawan();
            //newKaryawan.Nama = "Joko purnomo";
            //newKaryawan.Departemen = "Engineering";
            //newKaryawan.Email = "asdasd@cek.me";
            //newKaryawan.Phone = "0812345678";
            KaryawanController karyawan = new KaryawanController(connectionString);
            //karyawan.Insert(newKaryawan);
            karyawan.GetAll();

            PeminjamanAsetController peminjaman = new PeminjamanAsetController(connectionString);

            PeminjamanAset pinjamAset = new PeminjamanAset();
            pinjamAset.AsetId = 1;
            pinjamAset.KaryawanId = 1;

            //peminjaman.Peminjaman(pinjamAset);
            peminjaman.Pengembalian("10402811");


        }

        //ASET CRUD
        

        //Karyawan
        //void GetAllKaryawan
    }
}
