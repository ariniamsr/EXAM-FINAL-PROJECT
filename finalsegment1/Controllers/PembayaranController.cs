using finalsegment1.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace finalsegment1.Controllers
{
    class PembayaranController
    {
        public int IdPembayaran { get; set; }
        public string NamaPembayaran { get; set; }
        public int DeskripsiPembayaran { get; set; }
        public int UrlLogo { get; set; }

        // GETBYID : REGION (Command) 
        public void GetPembayaranById(int Id)
        {
            var connection = MyContext.GetConnection();

            //Membuka koneksi
            connection.Open();

            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_pembayaran  WHERE id = @Id";

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
                    Console.WriteLine("Id: " + reader[0]);
                    Console.WriteLine("Nama: " + reader[1]);
                    Console.WriteLine("Deskripsi: " + reader[2]);
                    Console.WriteLine("UrlLogo: " + reader[3]);

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

        public void GetAllPembayaran()
        {
            var connection = MyContext.GetConnection();


            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_pembayaran";  //sesuaikan querynya

            //Membuka koneksi
            connection.Open();

            //Menampilkan data tidak ditemukan
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)                                     //jika reader nya ada data maka otomatis akan ngebaca
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader[0]);          //ditampilkan disini
                    Console.WriteLine("Nama: " + reader[1]);
                    Console.WriteLine("Deskripsi: " + reader[2]);
                    Console.WriteLine("UrlLogo: " + reader[3]);
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


        public void InsertPembayaran(string nama, string deskripsi, string urllogo)
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
                command.CommandText = "INSERT INTO tbl_pembayaran (nama, deskripsi, url_logo) VALUES (@nama, @deskripsi, @urllogo)";
                command.Transaction = transaction;

                //Membuat paramater
                SqlParameter pNama = new SqlParameter();
                pNama.ParameterName = "@nama";
                pNama.Value = nama;
                pNama.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pDeskripsi = new SqlParameter();
                pDeskripsi.ParameterName = "@deskripsi";
                pDeskripsi.Value = deskripsi;
                pDeskripsi.SqlDbType = SqlDbType.VarChar;

                SqlParameter pUrlLogo = new SqlParameter();
                pUrlLogo.ParameterName = "@urllogo";
                pUrlLogo.Value = urllogo;
                pUrlLogo.SqlDbType = SqlDbType.VarChar;



                //Menambahkan parameter ke command
                command.Parameters.Add(pNama);
                command.Parameters.Add(pDeskripsi);
                command.Parameters.Add(pUrlLogo);

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
        public void UpdatePembayaran(int Id, string nama, string deskripsi, string urllogo)

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
                command.CommandText = "UPDATE tbl_pembayaran SET nama = @nama, deskripsi = @deskripsi, url_logo = @urllogo  WHERE id = @Id";
                command.Transaction = transaction;

                //Membuat paramater
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@nama";
                pName.Value = nama;
                pName.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pDeskripsi = new SqlParameter();
                pDeskripsi.ParameterName = "@deskripsi";
                pDeskripsi.Value = deskripsi;
                pDeskripsi.SqlDbType = SqlDbType.VarChar;

                SqlParameter pUrlLogo = new SqlParameter();
                pUrlLogo.ParameterName = "@urllogo";
                pUrlLogo.Value = urllogo;
                pUrlLogo.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = Id;
                pId.SqlDbType = SqlDbType.Int;


                //Menambahkan parameter ke command
                command.Parameters.Add(pName);
                command.Parameters.Add(pDeskripsi);
                command.Parameters.Add(pUrlLogo);
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


        public void DeletePembayaran(int Id) //method untuk menghapus data region
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
                command.CommandText = "DELETE FROM tbl_pembayaran  WHERE id = @Id";
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
