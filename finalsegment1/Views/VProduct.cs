using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalsegment1.Views
{
    class VProduct
    {
        public void CreateProduct()
        {
            Console.WriteLine("====== Product ======");
            Console.Write("Nama Product: ");
            string namaproduct = Console.ReadLine();

            Console.Write("Harga Product: ");
            string hargaproduct = Console.ReadLine();

            Console.Write("Stock Product: ");
            string stockproduct = Console.ReadLine();

            Console.WriteLine("Product berhasil ditambahkan");
        }

    }
}
