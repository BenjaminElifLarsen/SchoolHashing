using SchoolHashing;
using System.Runtime.CompilerServices;
using static System.Console;

var context = new Context();

byte options = 0;
bool exist = false;

User user = null;

do
{
    Clear();
    DisplayUser();
    MenuDisplay();
    options = MenuSelect(); 
    switch (options)
    {
        case 0:
            exist = true;
            break;
        case 1:
            Login();
            break;
        case 2:
            user = null;
            break;
        case 3:
            Registrate();
            break;
        default:
            break;
    }
} while (!exist);

void DisplayUser()
{
    if (user is null)
    {
        WriteLine("Ikke logget ind");
        return;
    }
    WriteLine("Bruger: " + user.Username);
}

void Registrate()
{
    WriteLine("Opret bruger");
    WriteLine("Brugernavn: ");
    string username = null;
    while (string.IsNullOrWhiteSpace(username))
    {
        username = ReadLine();
    }
    WriteLine("Kodeord: ");
    string password = null;
    while (string.IsNullOrWhiteSpace(password))
    {
        password = ReadLine();
    }
    context.Registrate(username, password);
}

void Login()
{
    Clear();
    WriteLine("Log ind");
    WriteLine("Brugernavn: ");
    string name = null;
    while (string.IsNullOrWhiteSpace(name))
    {
        name = ReadLine();
    }
    WriteLine("Kodeord: ");
    string pass = null;
    while (string.IsNullOrWhiteSpace(pass))
    {
        pass = ReadLine();
    }
    user = context.Login(name, pass);
}

void MenuDisplay()
{
    WriteLine("1 for at logge ind");
    WriteLine("2 for at logge ud");
    WriteLine("3 for at oprette bruger");
    WriteLine("0 for at stoppe programmet");
}

byte MenuSelect()
{
    byte selected = 0;
    string value = null;
    Write("Indtast værdi: ");
    do
    {
        value = ReadLine();
    }
    while (!byte.TryParse(value, out selected));
    return selected;
}