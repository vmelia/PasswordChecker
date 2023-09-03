namespace PasswordChecker.Model.Rules.ContainsRules;

public class TeletubbiesRule : ContainsRuleBase
{
    protected override string ErrorMessage => "Password must contain a Teletubbie";

    protected override string[] Allowed => new[] { "Tinky-Winky", "Dipsy", "Laa-Laa", "Po" };
}