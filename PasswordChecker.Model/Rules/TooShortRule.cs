namespace PasswordChecker.Model.Rules;

public class TooShortRule : RuleBase
{
    private readonly int _minimumLength;

    public TooShortRule(int minimumLength)
    {
        _minimumLength = minimumLength;
    }

    protected override bool IsValid => Password.Length >= _minimumLength;

    protected override string ErrorMessage => $"Password must contain at least {_minimumLength} character(s)";
}