namespace PasswordChecker.Model.Rules;

public class DigitRepeatRule : RuleBase
{
    private readonly int _allowed;

    public DigitRepeatRule(int allowed)
    {
        _allowed = allowed;
    }

    protected override bool IsValid
    {
        get
        {
            var digitTotals = new Dictionary<int, int>();
            foreach (var d in Digits)
            {
                if (digitTotals.ContainsKey(d))
                {
                    digitTotals[d]++;
                }
                else
                {
                    digitTotals[d] = 1;
                }

                if (digitTotals[d] > _allowed)
                    return false;
            }

            return true;
        }
    }

    protected override string ErrorMessage => $"Password may not contain the same digit more than {_allowed} times";
}