namespace PasswordChecker.Model.Rules;

public class SymbolRule : RuleBase
{
    protected override bool IsValid => Password.Any(char.IsSymbol) || Password.Any(char.IsPunctuation);

    protected override string ErrorMessage => "Password must contain at least one symbol";
}