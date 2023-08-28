namespace PasswordChecker.Model.Rules;

public class UpperAndLowerCaseRule : RuleBase
{
    protected override bool IsValid => Password.Any(char.IsUpper) && Password.Any(char.IsLower);

    protected override string ErrorMessage => "Password must contain both upper and lower case characters";
}