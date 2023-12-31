﻿using PasswordChecker.Model.Rules;
using Xunit;

namespace PasswordChecker.Model.Tests.Rules;

public class DigitTotalRuleTests : TestBase
{
    private const int _total = 9;

    public DigitTotalRuleTests() : base(new DigitTotalRule(_total)) { }

    [Theory]
    [InlineData("12321")]
    [InlineData("333")]
    public void Check_WhenValidPassword_ReturnsTrue(string password)
    {
        CheckValidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1234")]
    [InlineData("123456")]
    public void Check_WhenInvalidPassword_ReturnsFalse(string password)
    {
        CheckInvalidPassword(password);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1234")]
    [InlineData("123456")]
    public void ErrorText_WhenInvalidPassword_ReturnsCorrectText(string password)
    {
        CheckInvalidMessage(password, $"Password digits must total {_total}");
    }
}