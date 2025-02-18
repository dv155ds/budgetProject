namespace budgetTest.Repository;

public interface IBudgetRepository
{
    public IEnumerable<BudgetModel> GetAll();
}