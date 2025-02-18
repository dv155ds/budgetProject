namespace budgetTest.Repository;

public class BudgetRepository:IBudgetRepository
{
    public IEnumerable<BudgetModel> GetAll()
    {
        return new List<BudgetModel>();
    }
}