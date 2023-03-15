using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurence
{
    internal class InsurenceRecords
    {
        public List<User> Users { get; set; }
        public InsurenceRecords() 
        {
            Users = new List<User>();
        }
        public void ShowMenu()
        {
            Console.WriteLine("Vitejte v evidence pojisteni.");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Pridani noveho pojistence");
            Console.WriteLine("2 - Zobrazeni vsech pojistencu");
            Console.WriteLine();
            Console.Write("Volba: ");

        }
        public void AddNewUser()
        {
            Console.Clear();
            Console.Write("Zadejte sve krestni jmeno: ");
            string firstName = Console.ReadLine();
            Console.Write("Zadejte sve prijmeni: ");
            string lastName = Console.ReadLine();
            Console.Write("Zadejte svuj vek: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Zadejte sve telefonni cislo: ");
            int phoneNumber = int.Parse(Console.ReadLine());


            Users.Add(new User(firstName, lastName, age, phoneNumber));
        }
        public void ShowAllUsers()
        {
            Console.Clear();
            foreach(User user in Users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
