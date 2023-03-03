using SchoolHashing;
using System.Diagnostics;

namespace Test;

public class LogicTests
{
    [Fact]
    public void RegistrationSuccess()
    {
        Assert.True(new Context(false).Registrate("Bob", "Test123!"));
    }

    [Fact]
    public void RegistrationFailed()
    {
        var context = new Context(false);
        context.Registrate("Bob", "Test123!");
        Assert.False(context.Registrate("Bob", "Test123!"));
    }

    [Fact]
    public void LogInSuccess()
    {
        var context = new Context(false);
        context.Registrate("Bob", "Test123!");
        Assert.True(context.Login("Bob", "Test123!") != null);
    }

    [Fact]
    public void LogInFailed()
    {
        var context = new Context(false);
        context.Registrate("Bob", "Test123!");
        Assert.False(context.Login("Bob", "Test124!") != null);
    }

    [Fact]
    public void DifferentPasswords()
    {
        string val1 = Hasher.HashAndSalt("Test123!");
        string val2 = Hasher.HashAndSalt("Test123!");
        Assert.False(string.Equals(val1, val2));
    }
}