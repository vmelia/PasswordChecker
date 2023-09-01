namespace PasswordChecker.Model.Rules;

public class DigitTotalRule : RuleBase
{
    private readonly int _total;

    public DigitTotalRule(int total)
    {
        _total = total;
    }

    protected override bool IsValid => Digits.Sum() == _total;

    protected override string ErrorMessage => $"Password digits must total {_total}";
}