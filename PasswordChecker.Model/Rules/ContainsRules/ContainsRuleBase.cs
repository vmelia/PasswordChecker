namespace PasswordChecker.Model.Rules.ContainsRules;

public abstract class ContainsRuleBase : RuleBase
{
    protected abstract string[] Allowed { get; }

    protected override bool IsValid => Allowed.Any(a => Password.ToLower().Contains(a.ToLower()));
}