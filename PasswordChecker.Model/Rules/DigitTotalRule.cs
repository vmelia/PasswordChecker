namespace PasswordChecker.Model.Rules;

public class DigitTotalRule : RuleBase
{
    private readonly int _total;

    public DigitTotalRule(int total)
    {
        _total = total;
    }

    protected override bool IsValid
    {
        get
        {
            var total = 0;
            foreach (var c in Password)
            {
                if (int.TryParse(c.ToString(), out var result))
                {
                    total += result;
                }
            }

            return total == _total;
        }
    }

    protected override string ErrorMessage => $"Password digits must total {_total}";
}