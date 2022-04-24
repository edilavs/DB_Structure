using DBStructure.Data.DAL;
using DBStructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBStructure.Services
{
    class ProductService
    {
        ProductDbContext db = new ProductDbContext();
        string priceStr = "";
        double price;
        string disPerStr = "";
        double disPercent;
        string countStr = "";
        int count;
        string dateStr = "";
        DateTime createdAt;

        string proName = "";

        public void AddProduct()
        {
            Console.WriteLine("Mehsulun adini daxil edin:");
            string name = Console.ReadLine();
            Console.WriteLine("Mehsul haqqinda melumat daxil edin:");
            string aboutText = Console.ReadLine();
            do
            {
                Console.WriteLine("Mehsulun qiymetini daxil edin:");
                priceStr = Console.ReadLine();
            } while (!double.TryParse(priceStr, out price));

            do
            {
                Console.WriteLine("Endirim faizi daxil edin:");
                disPerStr = Console.ReadLine();
            } while (!double.TryParse(disPerStr, out disPercent));

            do
            {
                Console.WriteLine("Mehsulun sayini daxil edin:");
                countStr = Console.ReadLine();
            } while (!int.TryParse(countStr, out count));

            do
            {
                Console.WriteLine("Mehsulun yaradilma tarixini daxil edin:");
                dateStr = Console.ReadLine();
            } while (!DateTime.TryParse(dateStr, out createdAt));

            Product product = new Product()
            {
                Name = name,
                AboutText=aboutText,
                Price=price,
                DiscountPercent=disPercent,
                Count=count,
                CreatedAt=createdAt
            };
            db.Products.Add(product);
            db.SaveChanges();
        }


        public void SearchProduct()
        {
            Console.WriteLine("Product adi daxil edin:");
            proName = Console.ReadLine();
            var list1 = db.Products.Where(x => x.Name.Contains(proName)).ToList();
            foreach (var item in list1)
            {
                Console.WriteLine(item.Id +" "+item.Name); 
            }
        }

        public void GetCommentbyPrId()
        {
            Console.WriteLine("Product Id daxil edin:");
            int prId = Convert.ToInt32(Console.ReadLine());
            var list2 = db.Comments.Where(x => x.Id == prId).ToList();
            foreach (var item in list2)
            {
                Console.WriteLine(item.Id +" "+item.Text);
            }
        }

    }

    }


