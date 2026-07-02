using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indica.Productivity.Web.Pages.Composition;

public class UpsertModel : PageModel
{
    private readonly IFieldTeamService _fieldTeamService;
    private readonly IActivityRepository _fieldTeamActivityRepository;
    private readonly IFieldTeamRegionalRepository _fieldTeamRegionalRepository;


    public UpsertModel
    (
        IFieldTeamService fieldTeamService,
        IActivityRepository fieldTeamActivityRepository,
        IFieldTeamRegionalRepository fieldTeamRegionalRepository
    )
    {
        _fieldTeamService = fieldTeamService;
        _fieldTeamActivityRepository = fieldTeamActivityRepository;
        _fieldTeamRegionalRepository = fieldTeamRegionalRepository;
    }

    public bool IsEdit { get; private set; } = false;
    [BindProperty]
    public FieldTeamDTO Composition { get; set; } = new();
    public Exception? Error { get; set; }
    public SelectList FieldTeamActivity { get; set; } = null;
    public SelectList FieldTeamRegional { get; set; } = null;

    private async Task LoadEnumeratorsAsync()
    {
        FieldTeamActivity = new SelectList(
            await _fieldTeamActivityRepository.GetAllAsync(),
            nameof(Indica.Productivity.Domain.Entities.Activity.ActivityName),
            nameof(Indica.Productivity.Domain.Entities.Activity.ActivityName),
            Composition.ActivityName
            );
        FieldTeamRegional = new SelectList(
            await _fieldTeamRegionalRepository.GetAllAsync(),
            nameof(Indica.Productivity.Domain.Entities.FieldTeamRegional.RegionName),
            nameof(Indica.Productivity.Domain.Entities.FieldTeamRegional.RegionName),
            Composition.WorkArea
            );
    }

    public async Task<IActionResult> OnGetAsync(int id = 0)
    {
        if (id != 0)
        {
            try { Composition = await _fieldTeamService.GetByIdAsync(id); }
            catch (System.Exception ex) { Error = ex; return NotFound(); }
        }
        await LoadEnumeratorsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadEnumeratorsAsync();
        try { await _fieldTeamService.AddAsync(Composition); }
        catch (System.Exception ex) { Error = ex; return Page(); }
        return RedirectToPage("./Index");
    }
}
