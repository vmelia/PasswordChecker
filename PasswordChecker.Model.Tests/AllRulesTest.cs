using PasswordChecker.Model.Interfaces;
using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests;

public class AllRulesTest
{
    private readonly IRulesChecker _rulesChecker;

    public AllRulesTest()
    {
        var rules = new List<RuleBase>
        {
            new TooShortRule(6),
            new UpperAndLowerCaseRule(),
            new DigitRule(),
            new SymbolRule(),
            new DigitTotalRule(9),
            new PalindromeRule(),
            new ZodiacCheckRule(),    
            new DigitRepeatRule(2)
        };

        _rulesChecker = new RulesChecker(rules);
    }

    [Fact]
    public void Check_WhenAllRulesPass_ReturnsTrue()
    {
        const string password = "Leo$12321$oeL";

        var ruleResult = _rulesChecker.Check(password);

        Assert.True(ruleResult.IsValid);
        Assert.Equal(string.Empty, ruleResult.Message);
    }
}