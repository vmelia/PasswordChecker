using PasswordChecker.Model.Interfaces;
using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests;

public class RulesCheckerTests
{
    private readonly IRulesChecker _rulesChecker;

    public RulesCheckerTests()
    {
        var rules = new List<RuleBase>
        {
            new Rule1(),
            new Rule2()
        };

        _rulesChecker = new RulesChecker(rules);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123")]
    public void Check_WhenNeitherRuleIsValid_ReturnsFirstError(string password)
    {
        var ruleResult = _rulesChecker.Check(password);

        Assert.False(ruleResult.IsValid);
        Assert.Equal("Password must contain 'Rule1'", ruleResult.Message);
    }

    [Theory]
    [InlineData("Rule1")]
    [InlineData("abc Rule1 abc")]
    [InlineData("123 Rule1 123")]
    public void Check_WhenFirstRuleIsInvalidAndSecondRuleValid_ReturnsFirstError(string password)
    {
        var ruleResult = _rulesChecker.Check(password);

        Assert.False(ruleResult.IsValid);
        Assert.Equal("Password must contain 'Rule2'", ruleResult.Message);
    }

    [Theory]
    [InlineData("Rule1")]
    [InlineData("abc Rule1 abc")]
    [InlineData("123 Rule1 123")]
    public void Check_WhenFirstRuleIsValidAndSecondRuleInvalid_ReturnsSecondError(string password)
    {
        var ruleResult = _rulesChecker.Check(password);

        Assert.False(ruleResult.IsValid);
        Assert.Equal("Password must contain 'Rule2'", ruleResult.Message);
    }

    [Theory]
    [InlineData("Rule1 Rule2")]
    [InlineData("abc Rule1 abc Rule2")]
    [InlineData("Rule2 123 Rule1 123")]
    public void Check_WhenBothRulesAreValidReturnsSuccess(string password)
    {
        var ruleResult = _rulesChecker.Check(password);

        Assert.True(ruleResult.IsValid);
        Assert.Equal(string.Empty, ruleResult.Message);
    }
}

public class Rule1 : RuleBase
{
    protected override bool IsValid => Password.Contains("Rule1");

    protected override string ErrorMessage => "Password must contain 'Rule1'";
}

public class Rule2 : RuleBase
{
    protected override bool IsValid => Password.Contains("Rule2");

    protected override string ErrorMessage => "Password must contain 'Rule2'";
}