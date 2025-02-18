namespace TDD_Tech;

public interface IBudgetService
{
   public decimal Query(DateTime start, DateTime end);
}