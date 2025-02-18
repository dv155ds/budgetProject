using budgetTest.Repository;
using NSubstitute;

namespace budgetTest;

public class Tests
{
    private readonly IBudgetRepository _budgetRepository;
    [SetUp]
    public void Setup()
    {
        var budgetRepository = Substitute.For<IBudgetRepository>();
        budgetRepository.GetAll().Returns(new List<BudgetModel>
        {
            new BudgetModel { YearMonth = "202501", Amount = 1500 }
        });

     
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}