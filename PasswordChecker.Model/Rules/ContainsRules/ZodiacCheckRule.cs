namespace PasswordChecker.Model.Rules.ContainsRules;

public class ZodiacCheckRule : ContainsRuleBase
{
    protected override string ErrorMessage => "Password must contain a sign of the Zodiac";

    protected override string[] Allowed =>
        new[] {
            "aries", "taurus", "gemini", "cancer", "leo", "virgo",
            "libra", "scorpio", "sagittarius", "capricorn", "aquarius", "pisces"
        };
}