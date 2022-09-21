using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ManajemenAsetKaryawan.Models;

namespace ManajemenAsetKaryawan.Controller
{
    class KaryawanController
    {
        Karyawan karyawan = new Karyawan();

        public KaryawanController(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        SqlConnection sqlConnection;
        public string connectionString;

        public void GetAll()
        {
            string query = "SELECT * FROM Karyawan";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void Insert(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter nama = new SqlParameter("@nama", karyawan.Nama);
                sqlCommand.Parameters.Add(nama);

                SqlParameter departemen = new SqlParameter("@departemen", karyawan.Departemen);
                sqlCommand.Parameters.Add(departemen);

                SqlParameter email = new SqlParameter("@email", karyawan.Email);
                sqlCommand.Parameters.Add(email);

                SqlParameter phone = new SqlParameter("@phone", karyawan.Phone);
                sqlCommand.Parameters.Add(phone);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Karyawan " +
                        " VALUES (@nama,@departemen,@email,@phone)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine("-------Insert Karyawan Sukses-------");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine("-------Insert Karyawan Gagal-------");
                }
            }
        }
    }
}
