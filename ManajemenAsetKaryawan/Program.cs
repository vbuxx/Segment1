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

            string sel;

            Console.WriteLine("[1] Cek Semua Karyawan, [2] Tambah Karyawan, [3] Cek Aset ");
            Console.WriteLine("[4] Tambah Aset, [5] Perbarui Aset, [6] Hapus Aset ");
            Console.WriteLine("[7] Pinjam Aset, [8] Kembalikan Aset : ... ");
            sel = Console.ReadLine();

            Program program = new Program();
            AsetController aset = new AsetController(connectionString);
            KaryawanController karyawan = new KaryawanController(connectionString);
            PeminjamanAsetController peminjaman = new PeminjamanAsetController(connectionString);
            
            
            Aset newAset = new Aset();
            Karyawan newKaryawan = new Karyawan();
            PeminjamanAset newPinjamAset = new PeminjamanAset();

            switch (sel)
            {
                case "1":
                    karyawan.GetAll();

                    break;
                case "2":
                    Console.Write("Nama: ");
                    newKaryawan.Nama = Console.ReadLine();
                    Console.Write("Departemen: ");
                    newKaryawan.Departemen = Console.ReadLine();
                    Console.Write("Email: ");
                    newKaryawan.Email = Console.ReadLine();
                    Console.Write("Phone: ");
                    newKaryawan.Phone = Console.ReadLine();
                    karyawan.Insert(newKaryawan);
                    break;
                case "3":
                    aset.GetAll();
                    break;
                case "4":
                    Console.Write("Nama: ");
                    newAset.Name = Console.ReadLine();
                    Console.Write("Details: ");
                    newAset.Details = Console.ReadLine();
                    Console.Write("Stock: ");
                    newAset.Stock = Convert.ToInt32(Console.ReadLine());
                    aset.Insert(newAset);
                    break;
                case "5":
                    Console.Write("Nama: ");
                    newAset.Name = Console.ReadLine();
                    Console.Write("Details: ");
                    newAset.Details = Console.ReadLine();
                    aset.Insert(newAset);
                    break;
                case "6":
                    Console.Write("Hapus aset  dengan id: ");
                    aset.Delete(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "7":
                    Console.Write("Aset Id: ");
                    newPinjamAset.AsetId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Karyawan Id: ");
                    newPinjamAset.KaryawanId = Convert.ToInt32(Console.ReadLine());
                    peminjaman.Peminjaman(newPinjamAset);
                    break;
                case "8":
                    Console.Write("Masukkan kode peminjaman barang: ");
                    peminjaman.Pengembalian(Console.ReadLine());
                    break;
                default:
                    Console.Write("Tidak Tersedia ");
                    
                    break;
            }


            }

        //ASET CRUD
        

        //Karyawan
        //void GetAllKaryawan
    }
}
