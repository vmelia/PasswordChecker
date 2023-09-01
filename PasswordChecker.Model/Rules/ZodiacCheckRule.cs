namespace PasswordChecker.Model.Rules;

public class ZodiacCheckRule : RuleBase
{
    private readonly string[] _signs =
    {
        "aries", "taurus", "gemini", "cancer", "leo", "virgo",
        "libra", "scorpio", "sagittarius", "capricorn", "aquarius", "pisces"
    };

    protected override bool IsValid => _signs.Any(sign => Password.ToLower().Contains(sign));

    protected override string ErrorMessage => "Password must contain a sign of the Zodiac";
}