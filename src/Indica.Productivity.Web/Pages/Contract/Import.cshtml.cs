using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indica.Productivity.Web.Pages.Contract;
public class ImportModel : PageModel
{
    private readonly ILogger<ImportModel> _logger;
    private readonly IContractService _contractService;

    public ImportModel
    (
        ILogger<ImportModel> logger,
        IContractService contractService
    )
    {
        _logger = logger;
        _contractService = contractService;
    }

    [BindProperty]
    public Exception? Error { get; set; }
    [BindProperty]
    public IFormFile? FileSent { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if (FileSent == null)
                throw new ArgumentNullException(nameof(FileSent));
            await _contractService.AddRangeAsync(FileSent.OpenReadStream(), FileSent.FileName);
        }
        catch (Exception ex)
        {
            Error = ex;
            return Page();
        }
        return RedirectToPage("./Index");
    }
}
