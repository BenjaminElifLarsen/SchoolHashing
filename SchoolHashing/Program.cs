using SchoolHashing;

string hashed1 = Hasher.HashAndSalt("Test");
string hashed2 = Hasher.HashAndSalt("Test");
string hashed3 = Hasher.HashAndSalt("This is a test");
string hashed4 = Hasher.HashAndSalt("This is a test");
Console.WriteLine(hashed1);
Console.WriteLine(hashed2);
Console.WriteLine(hashed3);
Console.WriteLine(hashed4);