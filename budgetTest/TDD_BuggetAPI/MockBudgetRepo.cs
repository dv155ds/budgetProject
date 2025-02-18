using TDD_BudgetAPI.Interface;
using TDD_BudgetAPI.Models;

namespace TDD_BudgetAPI;

public class MockBudgetRepo : IBudgetRepo
{
    public List<Budget> GetAll()
    {
        return  new List<Budget>()
        {
            new Budget { YearMonth = "202002", Amount = 2900 },
            new Budget { YearMonth = "202301", Amount = 3100 },
            new Budget { YearMonth = "202302", Amount = 2800 },
            new Budget { YearMonth = "202501", Amount = 6200 },
            new Budget { YearMonth = "202502", Amount = 2800 },
            new Budget { YearMonth = "202503", Amount = 3100 },
            new Budget { YearMonth = "202504", Amount = 6000 },
            new Budget { YearMonth = "202505", Amount = 3100 },
            new Budget { YearMonth = "202506", Amount = 12000 },
            new Budget { YearMonth = "202507", Amount = 3100 },
            new Budget { YearMonth = "202508", Amount = 9300 },
            new Budget { YearMonth = "202509", Amount = 6000 },
            new Budget { YearMonth = "202510", Amount = 3100 },
            new Budget { YearMonth = "202511", Amount = 9000 },
            new Budget { YearMonth = "202512", Amount = 6200 }
        };
    }
}
