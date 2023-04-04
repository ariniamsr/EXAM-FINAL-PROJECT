using finalsegment1.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsegment1.Controllers
{
    class PenjualanController
    {
        public int IdPenjualan { get; set; }
        public string NamaPelanggan { get; set; }
        public DateTime Tanggal { get; set; }
        public int ProductId { get; set; }
        public int PembayaranId { get; set; }
        public int TotalHarga { get; set; }
        public bool TelahDibayar { get; set; }

        // GETBYID : REGION (Command) 
        public void GetAllPenjualan()
        {
            var connection = MyContext.GetConnection();


            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_penjualan";  //sesuaikan querynya

            //Membuka koneksi
            connection.Open();

            //Menampilkan data tidak ditemukan
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)                                     //jika reader nya ada data maka otomatis akan ngebaca
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);          //ditampilkan disini
                    Console.WriteLine("Name: " + reader[1]);
                    Console.WriteLine("Tanggal: " + reader[2]);
                    Console.WriteLine("Product: " + reader[3]);
                    Console.WriteLine("Pembayaran: " + reader[4]);
                    Console.WriteLine("Total Harga: " + reader[5]);
                    Console.WriteLine("Telah Dibayar: " + reader[6]);

                    Console.WriteLine("===================");

                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
            Console.ReadKey();
            reader.Close();
            //menutup koneksi
            connection.Close();
        }

        public void GetPenjualanById(int Id)
        {
            var connection = MyContext.GetConnection();

            //Membuka koneksi
            connection.Open();

            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_penjualan  WHERE id = @Id";

            //Menambahkan parameter
            SqlParameter parameter = new SqlParameter();
            parameter.Value = Id;
            parameter.SqlDbType = SqlDbType.Int;
            parameter.ParameterName = "@Id";
            command.Parameters.Add(parameter);

            //Membuat sql data reader
            using SqlDataReader reader = command.ExecuteReader();

            //Membaca data
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);          //ditampilkan disini
                    Console.WriteLine("Name: " + reader[1]);
                    Console.WriteLine("Tanggal: " + reader[2]);
                    Console.WriteLine("Product: " + reader[3]);
                    Console.WriteLine("Pembayaran: " + reader[4]);
                    Console.WriteLine("Total Harga: " + reader[5]);
                    Console.WriteLine("Telah Dibayar: " + reader[6]);
                    Console.WriteLine("============================");

                }
            }
            else
            {
                Console.WriteLine("No rows found!");


            }
            Console.ReadKey();
            reader.Close();
            connection.Close();
        }
        public void InsertPenjualan(string nama_pelanggan, string tanggal, int product_id, int pembayaran_id, int total_harga, int telah_dibayar)
        {
            var connection = MyContext.GetConnection();

            //Membuka Koneksi
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_penjualan (nama_pelanggan, tanggal, product_id, pembayaran_id, total_harga, telah_dibayar) VALUES (@nama, @tanggal, @product_id, @pembayaran_id, @total_harga, @telah_dibayar)";
                command.Transaction = transaction;

                //Membuat paramater
                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = nama_pelanggan;
                pNama.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pTanggal = new SqlParameter();
                pTanggal.ParameterName = "@tanggal";
                pTanggal.Value = tanggal;
                pTanggal.SqlDbType = SqlDbType.Date;

                SqlParameter pProduct = new SqlParameter();
                pProduct.ParameterName = "@product_id";
                pProduct.Value = product_id;
                pProduct.SqlDbType = SqlDbType.VarChar;


                SqlParameter pPembayaran = new SqlParameter();
                pPembayaran.ParameterName = "@pembayaran_id";
                pPembayaran.Value = pembayaran_id;
                pPembayaran.SqlDbType = SqlDbType.Int;



                SqlParameter pTotalharga = new SqlParameter();
                pTotalharga.ParameterName = "@total_harga";
                pTotalharga.Value = total_harga;
                pTotalharga.SqlDbType = SqlDbType.Int;



                SqlParameter pTelahbayar = new SqlParameter();
                pTelahbayar.ParameterName = "@telah_dibayar";
                pTelahbayar.Value = telah_dibayar;
                pTelahbayar.SqlDbType = SqlDbType.Bit;


                //Menambahkan parameter ke command
                command.Parameters.Add(pNama);
                command.Parameters.Add(pTanggal);
                command.Parameters.Add(pProduct);
                command.Parameters.Add(pPembayaran);
                command.Parameters.Add(pTotalharga);
                command.Parameters.Add(pTelahbayar);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil ditambahkan!");
                }
                else
                {
                    Console.WriteLine("Data gagal ditambahkan!");
                }
                //Menutup Koneksi            
                Console.ReadKey();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
                Console.ReadKey();
            }

        }
        public void UpdatePenjualan(int Id, string nama_pelanggan, string tanggal, int product_id, int pembayaran_id, int total_harga, int telah_dibayar)

        {
            var connection = MyContext.GetConnection();

            //Membuka Koneksi
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tbl_penjualan SET nama_pelanggan = @nama, tanggal = @tanggal, product_id = @product_id, pembayaran_id = @pembayaran_id, total_harga = @total_harga, telah_dibayar = @telah_dibayar  WHERE id = @Id";
                command.Transaction = transaction;


                //Membuat paramater
                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = nama_pelanggan;
                pNama.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pTanggal = new SqlParameter();
                pTanggal.ParameterName = "@tanggal";
                pTanggal.Value = tanggal;
                pTanggal.SqlDbType = SqlDbType.Date;

                SqlParameter pProduct = new SqlParameter();
                pProduct.ParameterName = "@product_id";
                pProduct.Value = product_id;
                pProduct.SqlDbType = SqlDbType.VarChar;


                SqlParameter pPembayaran = new SqlParameter();
                pPembayaran.ParameterName = "@pembayaran_id";
                pPembayaran.Value = pembayaran_id;
                pPembayaran.SqlDbType = SqlDbType.Int;



                SqlParameter pTotalharga = new SqlParameter();
                pTotalharga.ParameterName = "@total_harga";
                pTotalharga.Value = total_harga;
                pTotalharga.SqlDbType = SqlDbType.Int;



                SqlParameter pTelahbayar = new SqlParameter();
                pTelahbayar.ParameterName = "@telah_dibayar";
                pTelahbayar.Value = telah_dibayar;
                pTelahbayar.SqlDbType = SqlDbType.Bit;
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = Id;
                pId.SqlDbType = SqlDbType.Int;


                //Menambahkan parameter ke command
                command.Parameters.Add(pNama);
                command.Parameters.Add(pTanggal);
                command.Parameters.Add(pProduct);
                command.Parameters.Add(pPembayaran);
                command.Parameters.Add(pTotalharga);
                command.Parameters.Add(pTelahbayar);
                command.Parameters.Add(pId);

                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                if (result > 0)
                {
                    Console.WriteLine("Data berhasil diupdate!");
                }
                else
                {
                    Console.WriteLine("Data gagal diupdate!");
                }
                //Menutup Koneksi
                Console.ReadKey();
                connection.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                //Transaction Rollback
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }


        }
        public void DeletePenjualan(int Id) //method untuk menghapus data region
        {
            var connection = MyContext.GetConnection();

            //Membuka koneksi
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {


                //Memmbuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tbl_penjualan  WHERE id = @Id";
                command.Transaction = transaction;



                //Menambahkan parameter
                SqlParameter parameter = new SqlParameter();
                parameter.Value = Id;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@Id";
                command.Parameters.Add(parameter);


                //Menjalankan command
                int result = command.ExecuteNonQuery();
                transaction.Commit();

                //Menampilkan data
                if (result > 0)
                {
                    Console.WriteLine("Data berhasil dihapus!");
                }


                else
                {
                    Console.WriteLine("Data gagal dihapus!");
                }
                //Menutup Koneksi
                Console.ReadKey();
                connection.Close();
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                try
                {
                    transaction.Rollback();
                }
                //Transaction Rollback
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }

        }

    }
}