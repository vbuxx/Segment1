using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ManajemenAsetKaryawan.Models;

namespace ManajemenAsetKaryawan.Controller
{
    class PeminjamanAsetController
    {

        PeminjamanAset peminjamanAset = new PeminjamanAset();

        public PeminjamanAsetController(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
       
        public string connectionString;

        public void Peminjaman(PeminjamanAset peminjamanAset)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_PeminjamanAset", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter aset_id = new SqlParameter();
                aset_id.ParameterName = "@asetid";
                aset_id.Value = peminjamanAset.AsetId;
                sqlCommand.Parameters.Add(aset_id);

                SqlParameter karyawan_id = new SqlParameter();
                karyawan_id.ParameterName = "@karyawanid";
                karyawan_id.Value = peminjamanAset.KaryawanId;
                sqlCommand.Parameters.Add(karyawan_id);


                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine("Failed");
                }
            }
        }

        public void Pengembalian(string UniqueKey)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_PengembalianAset", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter unique = new SqlParameter();
                unique.ParameterName = "@unique";
                unique.Value = UniqueKey;
                sqlCommand.Parameters.Add(unique);


                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine("Failed");
                }
            }
        }
    }
}
