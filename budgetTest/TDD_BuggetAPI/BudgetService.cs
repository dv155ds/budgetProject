using TDD_BudgetAPI.Models;

namespace TDD_BudgetAPI;

public class BudgetService(IBudgetRepo budgetRepo)
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
            int daysInRange;
            if (start > budget.LastDay() || end < budget.FirstDay())
            {
                daysInRange=0;
            }
            else
            {
                var effectiveStart = start > budget.FirstDay() ? start : budget.FirstDay();
                var effectiveEnd = end < budget.LastDay() ? end : budget.LastDay();
                daysInRange = (effectiveEnd - effectiveStart).Days + 1;
            }
            var daysInMonth = GetDaysInMonth(budget.YearMonth);
            // :流程中對於暫存變數可抽出去，
            // Ex: daysInRange是由很多不同的暫存變數推出來的、這樣的話就可以抽成GetDaysInRange
            totalAmount += (budget.Amount / daysInMonth) * daysInRange;
        }

        return totalAmount;
    }

    
    private int GetDaysInMonth(string yearMonth)
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
