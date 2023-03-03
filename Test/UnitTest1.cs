using SchoolHashing;

namespace Test;

public class UnitTest1
{
    [Fact]
    public void RegistrationSuccess()
    {
        Assert.True(new Context().Registrate("Bob", "Test123!"));
    }
    [Fact]
    public void RegistrationFailed()
    {
        var context = new Context();
        context.Registrate("Bob", "Test123!");
        Assert.False(context.Registrate("Bob", "Test123!"));
    }
}