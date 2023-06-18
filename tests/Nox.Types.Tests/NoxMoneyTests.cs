using System.Globalization;
using FluentValidation.Results;

namespace Nox.Types.Tests;

public class NoxMoneyTests
{
    [Fact]
    public void Money_DefaultConstructor_InitializedWithDefaultValues()
    {
        // Arrange
        Money money = new Money();

        // Assert
        Assert.Equal(0, money.Value);
        Assert.Equal(CurrencyCode.USD, money.CurrencyCode);
    }

    [Fact]
    public void Money_ParameterizedConstructor_InitializedWithProvidedValues()
    {
        // Arrange
        decimal value = 1000.50m;
        var currency = CurrencyCode.EUR;

        // Act
        var money = Money.From(value, currency);

        // Assert
        Assert.Equal(value, money.Value);
        Assert.Equal(currency, money.CurrencyCode);
    }

    [Fact]
    public void Money_FromMethod_CreatesMoneyObject()
    {
        // Arrange
        decimal value = 500.75m;
        var currency = CurrencyCode.GBP;

        // Act
        var money = Money.From(value, currency);

        // Assert
        Assert.Equal(value, money.Value);
        Assert.Equal(currency, money.CurrencyCode);
    }

    [Fact]
    public void ToString_ReturnsFormattedString()
    {
        // Arrange
        var money = Money.From(-16325.62m);

        
        // Act
        string defaultString = money.ToString();
        string gFormattedString = money.ToString("G");
        string fFormattedString = money.ToString("F");
        string cFormattedString = money.ToString( new CultureInfo("en-US"), "C");
        
        // Assert
        Assert.Equal("-16325.62", defaultString);
        Assert.Equal("-16325.62", gFormattedString);
        Assert.Equal("-16325.62", fFormattedString);
        Assert.Equal("-$16,325.62", cFormattedString);
        
    }

    [Fact]
    public void ToFormattedStringWithCurrency_ReturnsFormattedStringWithCurrency()
    {
        // Arrange
        var money = Money.From(1455453.55m,  CurrencyCode.TRY);

        // Act
        string formattedString = money.ToString(CultureInfo.InvariantCulture, "N2");

        // Assert
        Assert.Equal("1,455,453.55", formattedString);
    }

    [Fact]
    public void ToStringWithSymbol_ShouldReturnFormattedString_WithDefaultAmountFormat()
    {
        // Arrange
        Money money = Money.From(1000, CurrencyCode.EUR);

        // Act
        string result = money.ToStringWithSymbol();

        // Assert
        Assert.Equal("€1,000.00", result);
    }

    [Fact]
    public void ToStringWithSymbol_ShouldReturnFormattedString_WithCustomAmountFormat()
    {
        // Arrange
        Money money = Money.From(1000, CurrencyCode.EUR);

        // Act
        string result = money.ToStringWithSymbol("N0");

        // Assert
        Assert.Equal("€1,000", result);
    }

    [Fact]
    public void ToStringWithSymbol_WithCultureInfo_ShouldReturnFormattedString_WithDefaultAmountFormat()
    {
        // Arrange
        Money money = Money.From(1000, CurrencyCode.USD);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        // Act
        string result = money.ToStringWithSymbol(cultureInfo);

        // Assert
        Assert.Equal("$1,000.00", result);
    }

    [Fact]
    public void ToStringWithSymbol_WithCultureInfo_ShouldReturnFormattedString_WithCustomAmountFormat()
    {
        // Arrange
        Money money = Money.From(1000, CurrencyCode.USD);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        // Act
        string result = money.ToStringWithSymbol(cultureInfo, "N0");

        // Assert
        Assert.Equal("$1,000", result);
    }
    
   
    
    [Fact]
    public void Moneys_Should_Equal_When_Their_Value_And_Currency_Same()
    {
        // Arrange
        var money = Money.From(1455453.55m, CurrencyCode.USD);
        var money2 = Money.From(1455453.55m, CurrencyCode.USD);
        
        // Act
        var result = money.Equals(money2);
        
        // Assert
        Assert.True(result);
        Assert.Equal(money, money2);
        
    }
    
    [Fact]
    public void Moneys_Should_Not_Equal_When_Their_Value_And_Currency_Different()
    {
        // Arrange
        var money = Money.From(1455453.55m, CurrencyCode.USD);
        var money2 = Money.From(1455453.55m, CurrencyCode.TRY);
        
        var money3 = Money.From(1455453.55m, CurrencyCode.USD);
        var money4 = Money.From(1455453.56m, CurrencyCode.USD);
        
        // Act
        var result = money.Equals(money2);
        var result2 = money3.Equals(money4);
        
        // Assert

        Assert.False(result);
        Assert.False(result2);
        Assert.NotEqual(money, money2);
        Assert.NotEqual(money3, money4);
        
    }
}