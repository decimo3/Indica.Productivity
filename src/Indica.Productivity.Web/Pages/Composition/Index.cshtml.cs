using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indica.Productivity.Web.Pages.Composition;

public class IndexModel : PageModel
{
    private readonly IFieldTeamService _fieldTeamService;

    public IndexModel
    (
        IFieldTeamService fieldTeamService
    )
    {
        _fieldTeamService = fieldTeamService;
    }

    [BindProperty]
    public List<FieldTeamDTO> Compositions { get; set; } = [];
    [BindProperty]
    public bool IsError { get; set; } = false;

    public async Task<IActionResult> OnGetAsync(int page = 0)
    {
        Compositions = await _fieldTeamService.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _fieldTeamService.DeleteAsync(id);
        return RedirectToPage("./Index");
    }
}
