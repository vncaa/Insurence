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
            Console.WriteLine("Vitejte v evidenci pojisteni.");
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
            int age = ValidAge(); //funkce pro overeni spravnosti veku
            int phoneNumber = ValidPhoneNumber(); //funkce pro overeni spravnosti tel. cisla
            
            


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
                ValidPhoneNumber();
            }
            Console.WriteLine("Telefonni cislo bylo zmeneno.");
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
        public int ValidPhoneNumber()
        {
            int phoneNumber = 0;
            bool validNumber = false;
            bool validInput = false;
            while (!validNumber)
            {
                Console.Write("Zadejte telefonni cislo (bez mezer): +420");
                string input = Console.ReadLine().Trim();
                if (input.Length == 9)
                {
                    validInput = int.TryParse(input, out phoneNumber);
                }
                if (validInput)
                    validNumber = true;
                else
                {
                    Console.WriteLine("Telefonni cislo neni ve spravnem tvaru.");
                }
            }
            return phoneNumber;
        }
        public int ValidAge()
        {
            int age = 0;
            bool validAge = false;
            bool validInput = false;
            while (!validAge)
            {
                Console.Write("Zadejte svuj vek: ");
                string input = Console.ReadLine().Trim();
                validInput = int.TryParse(input, out age);
                if (validInput)
                    validAge = true;
                else
                {
                    Console.WriteLine("Vek neni ve spravnem tvaru");
                }
            }
            return age;
        }

    }
}
