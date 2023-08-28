namespace PasswordChecker.Model.Interfaces;

public class RuleResult
{ 
    private RuleResult(bool isValid, string message = "")
    {
        IsValid = isValid;
        Message = message;
    }

    public bool IsValid { get; }
    public string Message { get; }

    public static RuleResult Valid() => new(true);
    public static RuleResult Invalid(string message) => new(false, message);
}