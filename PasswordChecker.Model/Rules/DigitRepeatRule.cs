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
                var alreadyThere = digitTotals.ContainsKey(d);
                if (alreadyThere)
                {
                    digitTotals[d]++;
                    if (digitTotals[d] > _allowed)
                        return false;
                }
                else
                {
                    digitTotals[d] = 1;
                }
            }

            return true;
        }
    }

    protected override string ErrorMessage => $"Password may only have {_allowed} of the same digit";
}