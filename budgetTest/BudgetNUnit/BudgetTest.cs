using NSubstitute;
using TDD_BudgetAPI;
using TDD_BudgetAPI.Interface;
using TDD_BudgetAPI.Models;

namespace BudgetNUnit;

[TestFixture]
public class BudgetServiceTests
{
    private BudgetService _budgetService;

    [SetUp]
    public void SetUp()
    {
        _budgetService = new BudgetService(new MockBudgetRepo());
    }

    [Test]
    public void Query_WholeMonth_ShouldReturnCorrectAmount()
    {
        // Arrange
        var start = new DateTime(2023, 1, 1);
        var end = new DateTime(2023, 1, 31);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        Assert.AreEqual(3100, result);
    }

    [Test]
    public void Query_CrossMonth_ShouldReturnCorrectAmount()
    {
        // Arrange
        var start = new DateTime(2023, 1, 15);
        var end = new DateTime(2023, 2, 15);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        var expectedAmount = (3100 / 31m) * 17 + (2800 / 28m) * 15;
        Assert.AreEqual(expectedAmount, result);
    }

    [Test]
    public void Query_LeapYear_ShouldReturnCorrectAmount()
    {
        // Arrange
        var start = new DateTime(2020, 2, 1);
        var end = new DateTime(2020, 2, 29);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        Assert.AreEqual(2900, result);
    }

    [Test]
    public void Query_InvalidDateRange_ShouldReturnZero()
    {
        // Arrange
        var start = new DateTime(2023, 2, 15);
        var end = new DateTime(2023, 1, 15);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        Assert.AreEqual(0, result);
    }
}