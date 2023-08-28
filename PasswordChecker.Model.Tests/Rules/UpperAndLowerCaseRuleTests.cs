using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class UpperAndLowerCaseRuleTests : TestBase
{
    public UpperAndLowerCaseRuleTests() : base(new UpperAndLowerCaseRule()) { }

    [Theory]
    [InlineData("Aa")]
    [InlineData("Zz")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("A")]
    [InlineData("a")]
    [InlineData("Z")]
    [InlineData("z")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("A")]
    [InlineData("a")]
    [InlineData("Z")]
    [InlineData("z")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must contain both upper and lower case characters");
    }
}