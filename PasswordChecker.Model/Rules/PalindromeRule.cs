namespace PasswordChecker.Model.Rules;

public class PalindromeRule : RuleBase
{
    protected override bool IsValid => Password.SequenceEqual(Password.Reverse());

    protected override string ErrorMessage => "Password must be a palindrome";
}