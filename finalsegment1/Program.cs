using System;
using System.Collections.Generic;
using finalsegment1.Controllers;
using finalsegment1.Views;

namespace finalsegment1;


class Program
{
    //static List<ProductController> produk = new List<ProductController>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("== PENJUALAN ==");
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Product");           
            Console.WriteLine("2. Penjualan");
            Console.WriteLine("3. Pembayaran");

            Console.Write("Operation: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    Product();
                    break;
                case "2":
                    Penjualan();
                      break;
                case "3":
                      Pembayaran();                          
                      break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void Product()
    {
        VProduct vProduct = new VProduct();
        ProductController productController = new ProductController();  
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=======Table Product========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            
            Console.Write("Input: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    productController.GetAllProduct();

                    break;
                case "2":
                    // GET BY ID
                    Console.WriteLine("====== Cari Product ======");
                    Console.Write("Masukkan Id: ");
                    string id = Console.ReadLine();
                    productController.GetProductById(int.Parse(id));


                    break;
                case "3":
                    Console.WriteLine("====== Product ======");
                    Console.Write("Nama Product: ");
                    string namaproduct = Console.ReadLine();

                    Console.Write("Harga Product: ");
                    string hargaproduct = Console.ReadLine();

                    Console.Write("Stock Product: ");
                    string stockproduct = Console.ReadLine();

                    productController.InsertProduct(namaproduct, int.Parse(hargaproduct), int.Parse(stockproduct));

                    break;
                case "4":
                    Console.WriteLine("====== Update Product ======");
                    Console.Write("Id Product: ");
                    string idproduct = Console.ReadLine();

                    Console.Write("Nama Product: ");
                    namaproduct = Console.ReadLine();

                    Console.Write("Harga Product: ");
                    hargaproduct = Console.ReadLine();

                    Console.Write("Stock Product: ");
                    stockproduct = Console.ReadLine();

                    productController.UpdateProduct(int.Parse(idproduct), namaproduct, int.Parse(hargaproduct), int.Parse(stockproduct));

                    break;
                case "5":
                    Console.WriteLine("====== Cari Product ======");
                    Console.Write("Masukkan Id yang ingin dihapus: ");
                    id = Console.ReadLine();
                    productController.DeleteProduct(int.Parse(id));

                    // DELETE
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }


    static void Penjualan()
    {
        PenjualanController penjualanController = new PenjualanController();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=======Table Penjualan========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");

            Console.Write("Input: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    penjualanController.GetAllPenjualan();
                    break;
                case "2":
                    Console.WriteLine("====== Penjualan ======");
                    Console.Write("Masukkan Id: ");
                    string id = Console.ReadLine();
                    penjualanController.GetPenjualanById(int.Parse(id));

                    break;
                case "3":
                    Console.WriteLine("=== PENJUALAN ===");
                    Console.Write("Tanggal: ");
                    string tanggal = Console.ReadLine();

                    Console.Write("Nama: ");
                    string namapelanggan = Console.ReadLine();
                   
                    Console.Write("Productd: ");
                    string product = Console.ReadLine();

                    Console.Write("Pembayar: ");
                    string pembayaran = Console.ReadLine();

                    Console.Write("Total Harga: ");
                    string totalharga = Console.ReadLine();
                    
                    Console.Write("Telah Dibayar: ");
                    string telahdibayar = Console.ReadLine();

                    penjualanController.InsertPenjualan(namapelanggan, tanggal, int.Parse(product), int.Parse(pembayaran), int.Parse(totalharga), int.Parse(telahdibayar));

                    break;
                case "4":
                    Console.WriteLine("====== Update Penjualan ======");
                    Console.Write("Id Penjualan: ");
                    string idpenjualan = Console.ReadLine();

                    Console.Write("Tanggal: ");
                    tanggal = Console.ReadLine();

                    Console.Write("Nama: ");
                    namapelanggan = Console.ReadLine();

                    Console.Write("Productd: ");
                    product = Console.ReadLine();

                    Console.Write("Pembayar: ");
                    pembayaran = Console.ReadLine();

                    Console.Write("Total Harga: ");
                    totalharga = Console.ReadLine();

                    Console.Write("Telah Dibayar: ");
                    telahdibayar = Console.ReadLine();

                    penjualanController.UpdatePenjualan(int.Parse(idpenjualan), namapelanggan, tanggal, int.Parse(product), int.Parse(pembayaran), int.Parse(totalharga), int.Parse(telahdibayar));

                    break;
                case "5":
                    // DELETE
                    Console.WriteLine("====== Hapus Penjualan ======");
                    Console.Write("Masukkan Id yang ingin dihapus: ");
                    id = Console.ReadLine();
                    penjualanController.DeletePenjualan(int.Parse(id));

                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
            Console.WriteLine();
        }

        
    }

    static void Pembayaran()
    {
        PembayaranController pembayaranController = new PembayaranController();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=======Table Pembayaran========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");

            Console.Write("Input: ");
            string operation = Console.ReadLine();

            switch (operation)
            {
                case "1":
                    pembayaranController.GetAllPembayaran();

                    break;
                case "2":
                    Console.WriteLine("====== Cari Pembayaran ======");
                    Console.Write("Masukkan Id: ");
                    string id = Console.ReadLine();
                    pembayaranController.GetPembayaranById(int.Parse(id));
                    break;
                case "3":
                    Console.WriteLine("====== Pembayaran ======");
                    Console.Write(" Pembayaran: ");
                    string nama = Console.ReadLine();

                    Console.Write("Deskripsi: ");
                    string deskripsi = Console.ReadLine();

                    Console.Write("Url Logo: ");
                    string urllogo = Console.ReadLine();



                    pembayaranController.InsertPembayaran(nama, deskripsi, urllogo);

                    break;
                case "4":
                    Console.WriteLine("====== Update Pembayaran ======");
                    Console.Write("Id Pembayaran: ");
                    string idpembayaran = Console.ReadLine();

                    Console.Write("Nama pembayaran: ");
                    nama = Console.ReadLine();

                    Console.Write("Deskripsi: ");
                    deskripsi = Console.ReadLine();

                    Console.Write("Url Logo: ");
                    urllogo = Console.ReadLine();

                    pembayaranController.UpdatePembayaran(int.Parse (idpembayaran), nama, deskripsi, urllogo);
                    break;
                case "5":
                    // DELETE
                    Console.WriteLine("====== Hapus Pembayaran ======");
                    Console.Write("Masukkan Id yang ingin dihapus: ");
                    id = Console.ReadLine();
                    pembayaranController.DeletePembayaran(int.Parse(id));

                    // DELETE
                    break;
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

}









