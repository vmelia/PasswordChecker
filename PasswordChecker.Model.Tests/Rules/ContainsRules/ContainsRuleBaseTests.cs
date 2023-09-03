using PasswordChecker.Model.Rules.ContainsRules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules.ContainsRules;

public class ContainsRuleBaseTests : TestBase
{
    public ContainsRuleBaseTests() : base(new ContainsRuleTest()) { }

    [Theory]
    [InlineData("-abc-")]
    [InlineData("-ABC-")]
    [InlineData("-Abc-")]
    [InlineData("-xyz-")]
    [InlineData("-XYZ-")]
    [InlineData("-Xyz-")]

    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("def")]
    [InlineData("123")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("def")]
    [InlineData("123")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, "error-message");
    }
}

internal class ContainsRuleTest : ContainsRuleBase
{
    protected override string[] Allowed => new[] { "ABC", "xyz" };

    protected override string ErrorMessage => "error-message";
} 