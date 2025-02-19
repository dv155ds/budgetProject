
namespace TDD_BudgetAPI.Models;
public class Budget
{
    public string YearMonth { get; set; }
    public int Amount { get; set; }

    internal DateTime FirstDay()
    {
        return new DateTime(DateTime.ParseExact(YearMonth, "yyyyMM", null).Year, DateTime.ParseExact(YearMonth, "yyyyMM", null).Month, 1);
    }

    internal DateTime LastDay()
    {
        return FirstDay().AddMonths(1).AddDays(-1);
    }
}