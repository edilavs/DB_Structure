using DBStructure.Data.DAL;
using DBStructure.Data.Entities;
using DBStructure.Services;
using System;
using System.Linq;

namespace DBStructure
{
    class Program
    {
        static void Main(string[] args)
        {


            ProductDbContext db = new ProductDbContext();

            string answer = Console.ReadLine();
           
            bool check = true;
          
            string priceStr = "";
            double price;
            string disPerStr = "";
            double disPercent;
            string countStr = "";
            int count;
            string dateStr = "";
            DateTime createdAt;
            string proName = "";
            double sum = 0;
            int counter = 0;
            string date1Str = "";
            DateTime firstDate;
            string date2Str = "";
            DateTime secondDate;
            while (check)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.Product elave et");
                Console.WriteLine("2.Productlar uzre axtaris et");
                Console.WriteLine("3.Secilmis productin commentlerine bax");
                Console.WriteLine("4.Secilmis userin commentlerine baX");
                Console.WriteLine("5.Commenti sil ");
                Console.WriteLine("6.Productlarin ortalama qiymetine bax");
                Console.WriteLine("7.Verilmis 2 tarix araligindaki Commentlere bax");
                Console.WriteLine("0.Proqrami bitir");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
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
                            AboutText = aboutText,
                            Price = price,
                            DiscountPercent = disPercent,
                            Count = count,
                            CreatedAt = createdAt
                        };
                        db.Products.Add(product);
                        db.SaveChanges();
                        break;
                    case "2":
                        Console.WriteLine("Product adi daxil edin:");
                        proName = Console.ReadLine();
                        var list1 = db.Products.Where(x => x.Name.Contains(proName)).ToList();
                        foreach (var item in list1)
                        {
                            Console.WriteLine(item.Id + " " + item.Name);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Product Id daxil edin:");
                        int prId = Convert.ToInt32(Console.ReadLine());
                        var list2 = db.Comments.Where(x => x.Id == prId).ToList();
                        foreach (var item in list2)
                        {
                            Console.WriteLine(item.Id + " " + item.Text);
                        }
                        break;
                    case "4":
                        Console.WriteLine("User Id daxil edin:");
                        int usrId = Convert.ToInt32(Console.ReadLine());
                        var list3 = db.Comments.Where(x => x.Id == usrId).ToList();
                        foreach (var cmt in list3)
                        {
                            Console.WriteLine(cmt.Id +" "+cmt.Text);
                        }

                        break;
                    case "5":
                        Console.WriteLine("Silinecek commentin id-ni daxil edin:");
                        int removedId = Convert.ToInt32(Console.ReadLine());
                        var data =db.Comments.Find(removedId);
                        db.Comments.Remove(data);
                        db.SaveChanges();
                        break;
                    case "6":
                        var allProduct = db.Products.ToList();

                        foreach (var item in allProduct)
                        {
                            sum += item.Price;
                            counter++;
                        }
                        Console.WriteLine($"Ortalama:{sum/counter}");
                        break;
                    case "7":
                        do
                        {
                            Console.WriteLine("1.ci Tarix daxil edin:");
                            date1Str = Console.ReadLine();
                        } while (!DateTime.TryParse(date1Str, out firstDate));

                        do
                        {
                            Console.WriteLine("2.ci Tarix daxil edin:");
                            date2Str = Console.ReadLine();
                        } while (!DateTime.TryParse(date2Str, out secondDate));

                        var list4 = db.Comments.Where(x => x.CreatedAt >= firstDate & x.CreatedAt > secondDate);
                        foreach (var item in list4)
                        {
                            Console.WriteLine(item.Id+" "+item.Text );
                        }

                        break;

                    case "0":
                        check = false;
                        Console.WriteLine("proqram bitdi");

                        break;

                    default:
                        Console.WriteLine("Menuda bele secim yoxdur.");
                        break;
                }
            }
            

        }
    }
}
