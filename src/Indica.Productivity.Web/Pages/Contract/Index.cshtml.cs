using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indica.Productivity.Web.Pages.Contract;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IContractService _contractService;

    public IndexModel
    (
        ILogger<IndexModel> logger,
        IContractService contractService
    )
    {
        _logger = logger;
        _contractService = contractService;
    }

    [BindProperty]
    public Exception? Error { get; set; }
    [BindProperty]
    public List<ContractDTO> Contracts { get; set; } = new();


    public async Task<IActionResult> OnGetAsync()
    {
        try { Contracts = await _contractService.GetAllAsync(); }
        catch (Exception ex) { Error = ex; }
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try { await _contractService.DeleteAsync(id); }
        catch (Exception ex) { Error = ex; return Page(); }
        return RedirectToPage("./Index");
    }
}
