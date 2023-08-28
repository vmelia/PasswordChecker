using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class RuleBaseTests
{
    private readonly RuleBase _rule;

    public RuleBaseTests()
    {
        _rule = new TestRule();
    }

    [Fact]
    public void WhenConstructed_PasswordIsEmpty()
    {
        Assert.Equal(string.Empty, _rule.Password);
    }

    [Fact]
    public void Check_WhenCalled_SetsPassword()
    {
        _rule.Check("password");

        Assert.Equal("password", _rule.Password);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsValid_WhenCalled_ReturnsCheckIsValid(bool isValid)
    {
        ((TestRule)_rule).OverrideIsValid = isValid;

        var ruleResult = _rule.Check("password");

        Assert.Equal(isValid, ruleResult.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("error-message")]
    public void Message_WhenCheckIsValidIsFalse_ReturnsErrorMessage(string errorMessage)
    {
        ((TestRule)_rule).OverrideIsValid = false;
        ((TestRule)_rule).OverrideErrorMessage = errorMessage;

        var ruleResult = _rule.Check("password");

        Assert.Equal(errorMessage, ruleResult.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData("error-message")]
    public void Message_WhenCheckIsValidIsTrue_ReturnsEmptyMessage(string errorMessage)
    {
        ((TestRule)_rule).OverrideIsValid = true;
        ((TestRule)_rule).OverrideErrorMessage = errorMessage;

        var ruleResult = _rule.Check("password");

        Assert.Equal(string.Empty, ruleResult.Message);
    }
}

internal class TestRule : RuleBase
{
    public bool OverrideIsValid { get; set; }
    public string OverrideErrorMessage { get; set; } = string.Empty;

    protected override bool IsValid => OverrideIsValid;
    protected override string ErrorMessage => OverrideErrorMessage;
}