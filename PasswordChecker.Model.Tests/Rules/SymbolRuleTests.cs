using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class SymbolRuleTests : TestBase
{
    public SymbolRuleTests() : base(new SymbolRule()) { }

    [Theory]
    [InlineData("!")]
    [InlineData("@")]
    [InlineData("£")]
    [InlineData("$")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must contain at least one symbol");
    }
}