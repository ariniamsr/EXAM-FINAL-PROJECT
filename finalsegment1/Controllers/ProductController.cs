using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using finalsegment1.Contexts;
using System.Collections;


namespace finalsegment1.Controllers
{
        class ProductController
    {
        public string NamaProduct { get; set; }
        public int HargaProduct { get; set; }
        public int StockProduct { get; set; }
        public int IdProduct { get; set; }

        // GETBYID : REGION (Command) 
        public void GetProductById(int Id)
        {
            var connection = MyContext.GetConnection();

            //Membuka koneksi
            connection.Open();

            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_product  WHERE id = @Id";

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
                    Console.WriteLine("Name: " + reader[1]);
                    Console.WriteLine("Harga: " + reader[2]);
                    Console.WriteLine("Stock: " + reader[3]);            

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

        public void GetAllProduct()
        {
            var connection = MyContext.GetConnection();


            //Memmbuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tbl_product";  //sesuaikan querynya

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
                    Console.WriteLine("Harga: " + reader[2]);
                    Console.WriteLine("Stock: " + reader[3]);
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

        public void InsertProduct (string namaproduct, int hargaproduct, int stockproduct)
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
                command.CommandText = "INSERT INTO tbl_product (nama_product, harga_product, stock_product) VALUES (@nama, @harga, @stock)";
                command.Transaction = transaction;

                //Membuat paramater
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@nama";
                pName.Value = namaproduct;
                pName.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pHarga = new SqlParameter();
                pHarga.ParameterName = "@harga";
                pHarga.Value = hargaproduct;
                pHarga.SqlDbType = SqlDbType.Int;

                SqlParameter pStock = new SqlParameter();
                pStock.ParameterName = "@stock";
                pStock.Value = stockproduct;
                pStock.SqlDbType = SqlDbType.Int;



                //Menambahkan parameter ke command
                command.Parameters.Add(pName);
                command.Parameters.Add(pHarga);
                command.Parameters.Add(pStock);

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
            }
        }

        public void UpdateProduct(int Id, string namaproduct, int hargaproduct, int stockproduct)

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
                command.CommandText = "UPDATE tbl_product SET nama_product = @nama, harga_product = @harga, stock_product = @stock  WHERE id = @Id";
                command.Transaction = transaction;

                //Membuat paramater
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@nama";
                pName.Value = namaproduct;
                pName.SqlDbType = SqlDbType.VarChar;  //sesuaikan database


                SqlParameter pHarga = new SqlParameter();
                pHarga.ParameterName = "@harga";
                pHarga.Value = hargaproduct;
                pHarga.SqlDbType = SqlDbType.Int;

                SqlParameter pStock = new SqlParameter();
                pStock.ParameterName = "@stock";
                pStock.Value = stockproduct;
                pStock.SqlDbType = SqlDbType.Int;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.Value = Id;
                pId.SqlDbType = SqlDbType.Int;


                //Menambahkan parameter ke command
                command.Parameters.Add(pName);                                
                command.Parameters.Add(pHarga);
                command.Parameters.Add(pStock);
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

        public void DeleteProduct(int Id) //method untuk menghapus data region
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
                command.CommandText = "DELETE FROM tbl_product  WHERE id = @Id";
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

        /*public ProductController
        {
            this.NamaProduct = namaproduct;
            this.HargaProduct = hargaproduct;
            this.StockProduct = stockproduct;
            this.IdProduct = idproduct;
        }*/
    }

}
