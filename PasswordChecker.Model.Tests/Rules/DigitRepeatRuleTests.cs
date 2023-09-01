using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class DigitRepeatRuleTests : TestBase
{
    private const int _allowed = 2;

    public DigitRepeatRuleTests() : base(new DigitRepeatRule(_allowed)) { }

    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("121")]
    [InlineData("12321")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("111")]
    [InlineData("12121")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("111")]
    [InlineData("12121")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, $"Password may not contain the same digit more than {_allowed} times");
    }
}