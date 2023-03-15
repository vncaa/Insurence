using Insurence;

InsurenceRecords pojisteni = new InsurenceRecords();

bool running = true;

while (running)
{
    pojisteni.ShowMenu();

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            pojisteni.AddNewUser();
            break;
        case "2":
            pojisteni.ShowAllUsers();
            break;
        case "3":
            pojisteni.SearchUser();
            break;
    }
}
