using TDD_BudgetAPI.Models;

namespace TDD_BudgetAPI.Interface;

public interface IBudgetRepo
{
    List<Budget> GetAll();
}