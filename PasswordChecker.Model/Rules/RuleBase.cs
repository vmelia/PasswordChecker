using PasswordChecker.Model.Interfaces;

namespace PasswordChecker.Model.Rules;

public abstract class RuleBase
{
    public RuleResult Check(string password)
    {
        Password = password;
        return IsValid ? RuleResult.Valid() : RuleResult.Invalid(ErrorMessage);
    }

    public string Password { get; private set; } = string.Empty;

    protected abstract bool IsValid { get; }
    protected abstract string ErrorMessage { get; }
}