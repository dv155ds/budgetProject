using budgetTest.Repository;
using TDD_Tech;

namespace budgetTest.Service;

public class BudgetService:IBudgetService
{
    private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public decimal Query(DateTime start,DateTime end)
    {
        return 1.0m;
    }
}