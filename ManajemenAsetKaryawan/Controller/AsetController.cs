using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ManajemenAsetKaryawan.Models;

namespace ManajemenAsetKaryawan.Controller
{
    class AsetController
    {
     
        Aset aset = new Aset();

        public AsetController(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        SqlConnection sqlConnection;
        public string connectionString;
        public void GetAll()
        {
            string query = "SELECT * FROM Aset";

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

        public void Insert(Aset aset)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SP_TambahAset", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter();
                name.ParameterName = "@name";
                name.Value = aset.Name;
                sqlCommand.Parameters.Add(name);

                SqlParameter detail = new SqlParameter();
                detail.ParameterName = "@detail";
                detail.Value = aset.Details;
                sqlCommand.Parameters.Add(detail);

                SqlParameter stock = new SqlParameter();
                stock.ParameterName = "@stock";
                stock.Value = aset.Stock;
                sqlCommand.Parameters.Add(stock);

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

        public void Update(int ID, Aset aset)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@id";
                id.Value = ID;
                sqlCommand.Parameters.Add(id);

                SqlParameter name = new SqlParameter();
                name.ParameterName = "@name";
                name.Value = aset.Name;
                sqlCommand.Parameters.Add(name);

                SqlParameter detail = new SqlParameter();
                detail.ParameterName = "@detail";
                detail.Value = aset.Details;
                sqlCommand.Parameters.Add(detail);

                try
                {
                    sqlCommand.CommandText = "UPDATE Aset " +
                        "SET nama_aset = @name, detail_aset = @detail " + " WHERE id = @id; ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    sqlConnection.Close();
                    Console.WriteLine("Success update");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine("Failed update");
                }
            }
        }

        public void Delete(int ID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter id = new SqlParameter();
                id.ParameterName = "@id";
                id.Value = ID;
                sqlCommand.Parameters.Add(id);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Inventaris_Aset WHERE aset_id = @id "
                        + "DELETE FROM Peminjaman_Aset WHERE aset_id = @id "
                        + "DELETE FROM Aset WHERE id = @id ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    sqlConnection.Close();
                    Console.WriteLine("Success delete");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine("Failed delete");
                }
            }
        }
    }
}
