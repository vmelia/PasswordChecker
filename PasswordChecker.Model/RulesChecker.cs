using PasswordChecker.Model.Interfaces;
using PasswordChecker.Model.Rules;

namespace PasswordChecker.Model;

public class RulesChecker : IRulesChecker
{
    private readonly List<RuleBase> _rules;

    public RulesChecker(List<RuleBase> rules)
    {
        _rules = rules;
    }

    public RuleResult Check(string password)
    {
        foreach (var rule in _rules)
        {
            var ruleResult = rule.Check(password);
            if (!ruleResult.IsValid)
            {
                return ruleResult;
            }
        }

        return RuleResult.Valid();
    }
}