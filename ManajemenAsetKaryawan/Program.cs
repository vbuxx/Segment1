using System;
using System.Data;
using System.Data.SqlClient;
using ManajemenAsetKaryawan.Models;
using ManajemenAsetKaryawan.Controller;

namespace ManajemenAsetKaryawan
{
    class Program
    {
        int index;
        SqlConnection sqlConnection;
        
        static string connectionString = "Data Source=DESKTOP-PQO8BSH;Initial Catalog=ManajemenAset;User ID = me; Password=12345678;Connect Timeout = 30;";

        
        static void Main(string[] args)
        {
            string active = "1";
            string sel;

            Console.Write("[1] Cek Semua Karyawan, [2] Tambah Karyawan, [3] Cek Aset ");
            Console.Write("[4] Tambah Aset, [5] Perbarui Aset, [6] Hapus Aset ");
            Console.Write("[7] Pinjam Aset, [9] Kembalikan Aset : ... ");
            sel = Console.ReadLine();

            Program program = new Program();
            AsetController aset = new AsetController(connectionString);
            KaryawanController karyawan = new KaryawanController(connectionString);
            PeminjamanAsetController peminjaman = new PeminjamanAsetController(connectionString);
            
            
            Aset newAset = new Aset();
            Karyawan newKaryawan = new Karyawan();
            PeminjamanAset pinjamAset = new PeminjamanAset();
            //newAset.Name = "Kulkas";
            //newAset.Details = "Pengadaan 2022";
            //newAset.Stock = 10;

            //aset.InsertAset(newAset);
            ////aset.DeleteAset(5);
            ////newAset.Name = "Proyektor Acer";
            ////program.Update(9, newAset);
            ///
            
            //newKaryawan.Nama = "Joko purnomo";
            //newKaryawan.Departemen = "Engineering";
            //newKaryawan.Email = "asdasd@cek.me";
            //newKaryawan.Phone = "0812345678";
            
            //karyawan.Insert(newKaryawan);
            karyawan.GetAll();

            

            
            pinjamAset.AsetId = 1;
            pinjamAset.KaryawanId = 1;

            //peminjaman.Peminjaman(pinjamAset);
            peminjaman.Pengembalian("10402811");

            switch (sel)
            {
                case "1":
                    // code block

                    break;
                case "2":
                    // code block
                    break;
                case "3":
                    // code block
                    break;
                case "4":
                    // code block
                    break;
                case "5":
                    // code block
                    break;
                case "6":
                    // code block
                    break;
                case "7":
                    // code block
                    break;
                case "8":
                    // code block
                    break;
                case "9":
                    // code block
                    break;
                default:
                    // code block
                    break;
            }


            }

        //ASET CRUD
        

        //Karyawan
        //void GetAllKaryawan
    }
}
