using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Application.DTO;
using Microsoft.Extensions.Localization;

namespace Indica.Productivity.Web.Pages.Report;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IWorkOrderService _service;
    private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

    public IndexModel
    (
        ILogger<IndexModel> logger,
        IStringLocalizer<SharedResources> sharedLocalizer,
        IWorkOrderService service
    )
    {
        _logger = logger;
        _service = service;
        _sharedLocalizer = sharedLocalizer;
    }

    [BindProperty]
    public string? ErrorMessage { get; set; }
    [BindProperty]
    public IFormFile FileSent { get; set; }
    public List<WorkOrderResumeDTO> Reports { get; set; } = new();


    public async Task<IActionResult> OnGetAsync(int page = 0)
    {
        try { Reports = await _service.GetResumeAsync(page); }
        catch (System.Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _service.AddRangeAsync(FileSent.OpenReadStream(), FileSent.FileName);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            return Page();
        }
        return RedirectToPage("./Index");
    }

}
