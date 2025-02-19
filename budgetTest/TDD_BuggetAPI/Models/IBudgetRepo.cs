namespace TDD_BudgetAPI.Models;

public interface IBudgetRepo
{
    List<Budget> GetAll();
}