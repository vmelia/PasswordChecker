using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class ZodiacCheckRuleTests : TestBase
{
    public ZodiacCheckRuleTests() : base(new ZodiacCheckRule()) { }

    [Theory]
    [InlineData("capricorn")]
    [InlineData("Capricorn")]
    [InlineData("CAPRICORN")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("xyz")]
    [InlineData("123")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("xyz")]
    [InlineData("123")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must contain a sign of the Zodiac");
    }
}