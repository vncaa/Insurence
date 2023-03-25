using Insurence;

InsurenceRecords insurence = new InsurenceRecords();

bool running = true;

while (running)
{
    insurence.ShowMenu();

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            insurence.AddNewUser();
            break;
        case "2":
            insurence.ShowAllUsers();
            break;
        case "3":
            insurence.SearchUser();
            break;
        case "4":
            running = false;
            break;
        default:
            break;
    }
}
