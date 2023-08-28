using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class TooShortRuleTests : TestBase
{
    public TooShortRuleTests() : base(new TooShortRule(4)) { }

    [Theory]
    [InlineData("1234")]
    [InlineData("12345")]
    [InlineData("123456")]
    [InlineData("1234567")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must contain at least 4 character(s)");
    }
}