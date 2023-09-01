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

    public List<int> Digits
    {
        get
        {
            var digits = new List<int>();
            foreach (var c in Password)
            {
                if (int.TryParse(c.ToString(), out var result))
                {
                    digits.Add(result);
                }
            }

            return digits;
        }
    }

    protected abstract bool IsValid { get; }
    protected abstract string ErrorMessage { get; }
}