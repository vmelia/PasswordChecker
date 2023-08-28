namespace PasswordChecker.Model.Rules;

public class DigitRule : RuleBase
{
    protected override bool IsValid => Password.Any(char.IsDigit);

    protected override string ErrorMessage => "Password must contain at least one digit";
}