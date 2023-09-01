using PasswordChecker.Model.Interfaces;
using PasswordCheckerConsoleApp.Interfaces;

namespace PasswordCheckerConsoleApp.Model;

public class PasswordCheck : IPasswordCheck
{
    private readonly IInputOutput _user;
    private readonly IRulesChecker _rulesChecker;

    public PasswordCheck(IInputOutput user, IRulesChecker rulesChecker)
    {
        _user = user;
        _rulesChecker = rulesChecker;
    }

    public void Execute()
    {
        _user.WriteLine("Create a password:");

        while (true)
        {
            var password = _user.ReadLine();

            var ruleResult = _rulesChecker.Check(password!);
            if (ruleResult.IsValid)
            {
                _user.WriteLine($"Congratulations. '{password}' is a valid password:");
                break;
            }

            _user.WriteLine(ruleResult.Message);
        }
    }
}