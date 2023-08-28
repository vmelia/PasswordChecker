using PasswordChecker.Model;
using PasswordChecker.Model.Interfaces;
using PasswordChecker.Model.Rules;
using PasswordCheckerConsoleApp.Externals;
using PasswordCheckerConsoleApp.Interfaces;
using PasswordCheckerConsoleApp.Model;

var rules = new List<RuleBase>
{
    new TooShortRule(6),
    new UpperAndLowerCaseRule(),
    new DigitRule(),
    new SymbolRule(),
    new DigitTotalRule(15),
    new PalindromeRule(),
};

IInputOutput inputOutput = new ConsoleInputOutput();
IRulesChecker rulesChecker = new RulesChecker(rules);
IPasswordCheck passwordCheck = new PasswordCheck(inputOutput, rulesChecker);

passwordCheck.Execute();