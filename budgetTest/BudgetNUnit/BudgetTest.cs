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
        var start = new DateTime(2025, 1, 1);
        var end = new DateTime(2025, 1, 31);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        Assert.AreEqual(6200, result);
    }

    [Test]
    public void Query_CrossMonth_ShouldReturnCorrectAmount()
    {
        // Arrange
        var start = new DateTime(2025, 3, 30);
        var end = new DateTime(2025, 4, 2);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        var expectedAmount = (3100 / 31m) * 2 + (6000 / 30m) * 2;
        Assert.AreEqual(expectedAmount, result);
    }

    [Test]
    public void Query_LeapYear_ShouldReturnCorrectAmount()
    {
        // Arrange
        var start = new DateTime(2020, 2, 1);
        var end = new DateTime(2020, 2, 29);
        var start2 = new DateTime(2025, 2, 1);
        var end2 = new DateTime(2025, 2, 28);

        // Act
        var result = _budgetService.Query(start, end);
        var result2 = _budgetService.Query(start2, end2);

        // Assert
        Assert.AreEqual(2900, result);
        Assert.AreEqual(2800, result2);
    }

    [Test]
    public void Query_InvalidDateRange_ShouldReturnZero()
    {
        // Arrange
        var start = new DateTime(2025, 8, 15);
        var end = new DateTime(2025, 7, 15);

        // Act
        var result = _budgetService.Query(start, end);

        // Assert
        Assert.AreEqual(0, result);
    }
}