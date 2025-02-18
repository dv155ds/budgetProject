using Microsoft.AspNetCore.Mvc;

namespace TDD_BudgetAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BudgetController(IBudgetService budgetService) : Controller
{
    [HttpGet]
    public IActionResult Query(DateTime start, DateTime end)
    {
        return Ok(budgetService.Query(start, end));
    }
}
