namespace PasswordChecker.Model.Interfaces;

public interface IRulesChecker
{
    RuleResult Check(string password);
}