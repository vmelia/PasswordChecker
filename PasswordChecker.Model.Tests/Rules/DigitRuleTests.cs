using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class DigitRuleTests : TestBase
{
    public DigitRuleTests() : base(new DigitRule()) { }

    [Theory]
    [InlineData("1")]
    [InlineData("a1")]
    [InlineData("£1")]
    [InlineData("99")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must contain at least one digit");
    }
}