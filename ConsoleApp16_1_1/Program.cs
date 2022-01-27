using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace ConsoleApp16_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] productArray = new Product[3];
            for (int i = 0; i < productArray.Length; i++)
            {
                Console.WriteLine("Name {0}, Code {0},Price {0}", i);
                productArray[i] = new Product()
                {
                    Name = Console.ReadLine(),
                    Code = Convert.ToInt32(Console.ReadLine()),
                    Price = Convert.ToDouble(Console.ReadLine())
                };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonstring = JsonSerializer.Serialize(productArray, options);
            Console.WriteLine(jsonstring);
            string path = "Products.json";
            StreamWriter sw = new StreamWriter(path);
            sw.Write(jsonstring);
            sw.Close();
            Console.ReadKey();
        }
    }
    class Product
    {
        public int Code { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
