using TDD_BudgetAPI.Interface;

namespace TDD_BudgetAPI;

public interface IBudgetService
{
    decimal Query(DateTime start, DateTime end);
}

public class BudgetService(IBudgetRepo budgetRepo) : IBudgetService
{
    public decimal Query(DateTime start, DateTime end)
    {
        if (start > end)
        {
            // 需求情境
            return 0;
        }

        var budgets = budgetRepo.GetAll();
        decimal totalAmount = 0;

        foreach (var budget in budgets)
        {
            var budgetYearMonth = DateTime.ParseExact(budget.YearMonth, "yyyyMM", null);
            var budgetStart = new DateTime(budgetYearMonth.Year, budgetYearMonth.Month, 1);
            var budgetEnd = budgetStart.AddMonths(1).AddDays(-1);

            if (start > budgetEnd || end < budgetStart)
            {
                continue;
            }

            var effectiveStart = start > budgetStart ? start : budgetStart;
            var effectiveEnd = end < budgetEnd ? end : budgetEnd;

            var daysInMonth = GetDaysInMonth(budget.YearMonth);
            var daysInRange = (effectiveEnd - effectiveStart).Days + 1;

            totalAmount += (budget.Amount / daysInMonth) * daysInRange;
        }

        return totalAmount;
    }

    public static int GetDaysInMonth(string yearMonth)
    {
        if (yearMonth.Length != 6)
        {
            throw new ArgumentException("Invalid yearMonth format. Expected format: YYYYMM");
        }

        int year = int.Parse(yearMonth.Substring(0, 4));
        int month = int.Parse(yearMonth.Substring(4, 2));

        return DateTime.DaysInMonth(year, month);
    }
}
