using SchoolHashing;

namespace Test;

public class Context
{
    [Fact]
    public void RegistrationSuccess()
    {
        Assert.True(new SchoolHashing.Context().Registrate("Bob", "Test123!"));
    }

    [Fact]
    public void RegistrationFailed()
    {
        var context = new SchoolHashing.Context();
        context.Registrate("Bob", "Test123!");
        Assert.False(context.Registrate("Bob", "Test123!"));
    }

    [Fact]
    public void LogInSuccess()
    {
        var context = new SchoolHashing.Context();
        context.Registrate("Bob", "Test123!");
        Assert.True(context.Login("Bob", "Test123!") != null);
    }

    [Fact]
    public void LogInFailed()
    {
        var context = new SchoolHashing.Context();
        context.Registrate("Bob", "Test123!");
        Assert.False(context.Login("Bob", "Test124!") != null);
    }
}