using SchoolHashing;

//string hashed1 = Hasher.HashAndSalt("Test");
//string hashed2 = Hasher.HashAndSalt("Test");
//string hashed3 = Hasher.HashAndSalt("This is a test");
//string hashed4 = Hasher.HashAndSalt("This is a test");
//Console.WriteLine(hashed1);
//Console.WriteLine(hashed2);
//Console.WriteLine(hashed3);
//Console.WriteLine(hashed4);


var context = new Context();
context.Registrate("Bob", "Test123!");
context.Registrate("Bob The Second", "Test123!");
var test = context.Login("Bob", "Test123!");
var test2 = context.Login("Bob The Second", "Test123!");
var test3 = context.Login("Bob", "Test124!");
Console.WriteLine(test is not null);
Console.WriteLine(test2 is not null);
Console.WriteLine(test3 is not null);
string text = File.ReadAllText("DataContext.txt");
Console.WriteLine(text);