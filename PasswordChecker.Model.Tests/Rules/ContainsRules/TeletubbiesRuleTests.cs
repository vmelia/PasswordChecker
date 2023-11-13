using PasswordChecker.Model.Rules.ContainsRules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules.ContainsRules;

public class TeletubbiesRuleTests : TestBase
{
    public TeletubbiesRuleTests() : base(new TeletubbiesRule()) { }

    [Fact]
    public void ErrorText_WhenEmptyPassword_ReturnsCorrectText()
    {
        var ruleResult = Rule.Check(string.Empty);

        Assert.Equal("Password must contain a Teletubbie", ruleResult.Message);
    }

    // Note: Other tests are covered in 'ContainsRuleBaseTests'.
}