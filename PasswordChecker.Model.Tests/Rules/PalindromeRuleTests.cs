using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class PalindromeRuleTests : TestBase
{
    public PalindromeRuleTests() : base(new PalindromeRule()) { }

    [Theory]
    [InlineData("")]
    [InlineData("aa")]
    [InlineData("a1a")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("123")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("123")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "Password must be a palindrome");
    }
}