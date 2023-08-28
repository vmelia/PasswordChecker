using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public abstract class TestBase
{
    public RuleBase Rule { get; }

    protected TestBase(RuleBase rule)
    {
        Rule = rule;
    }

    protected void CheckValidPassword(string password)
    {
        var ruleResult = Rule.Check(password);

        Assert.True(ruleResult.IsValid);
    }

    protected void CheckInvalidPassword(string password)
    {
        var ruleResult = Rule.Check(password);

        Assert.False(ruleResult.IsValid);
    }

    protected void CheckInvalidMessage(string password, string expectedMessage)
    {
        var ruleResult = Rule.Check(password);

        Assert.Equal(expectedMessage, ruleResult.Message);
    }
}