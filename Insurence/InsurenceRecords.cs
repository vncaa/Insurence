using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Insurence
{
    internal class InsurenceRecords
    {
        public List<User> Users { get; set; }
        public InsurenceRecords()
        {
            Users = new List<User>();
        }

        //tisk menu s vyberem moznosti
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Vitejte v evidence pojisteni.");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Pridani noveho pojistence");
            Console.WriteLine("2 - Zobrazeni vsech pojistencu");
            Console.WriteLine("3 - Vyhledani pojistence/uprava/odstraneni pojistence");
            Console.WriteLine("4 - Ukonceni evidence pojisteni");
            Console.WriteLine();
            Console.Write("Volba: ");

        }

        //pridani noveho uzivatele do listu
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

        //zobrazeni vsech ulozenych uzivatelu
        public void ShowAllUsers()
        {
            Console.Clear();
            foreach (User user in Users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();
            Console.WriteLine("MENU - enter");
            Console.ReadKey();
        }
        //vyhledani uzivatele podle jmena a prijmeni
        public void SearchUser()
        {
            bool exit = false;
            bool numberChange = true;
            User userToEdit = null;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Zadejte detaily o hledanem pojistenci.");
                Console.Write("Krestni jmeno: ");
                string fName = Console.ReadLine();
                Console.Write("Prijmeni: ");
                string lName = Console.ReadLine();

                bool userFound = false;

                foreach (User user in Users)
                {
                    if ((user.FirstName == fName) && (user.LastName == lName))
                    {
                        Console.WriteLine();
                        Console.WriteLine(user);
                        userFound = true;
                        userToEdit = user;
                        break;
                    }
                }
                if (!userFound) //uzivatel nebyl nalezen podle jmena
                {
                    Console.WriteLine();
                    Console.WriteLine("Pojistenec se zadanym jmenem neexistuje.");
                }
                else
                {
                    EditPhoneNumber(userToEdit); //zmena cisla
                    DeleteUser(userToEdit); //smazani pojistence
                }
                    
                Console.WriteLine();
                Console.Write("Chcete vyhledat znovu pojistenece? ano/ne: ");
                string mainMenu = Console.ReadLine();
                if (mainMenu == "ne")
                    exit = true;
            }
        }
        public void EditPhoneNumber(User user) //zmena tel. cisla
        {
            Console.WriteLine();
            Console.Write("Chcete zmenit telefonni cislo? ano/ne: ");
            string choice = Console.ReadLine();
            if(choice == "ano")
            {
                Console.Write("Zadejte nove telefonni cislo: ");
                int newPhoneNumber = int.Parse(Console.ReadLine());
                user.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Telefonni cislo bylo zmeneno.");
            }
        }
        public void DeleteUser(User user) //smazani pojistence
        {
            Console.WriteLine();
            Console.WriteLine($"Chcete pojistence - {user.FirstName} {user.LastName} - odstranit? ano/ne");
            string choice = Console.ReadLine();
            if (choice == "ano")
            {
                Users.Remove(user);
                Console.WriteLine("Pojistenec byl odstranen.");
            }
        }
    }
}
