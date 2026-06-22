using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indica.Productivity.Web.Pages.Employer;

public class UpsertModel : PageModel
{
    private readonly ILogger<UpsertModel> _logger;
    private readonly IEmployerService _service;
    public readonly IEmployerSituationRepository _employerSituationRepository;
    public readonly IEmployerFunctionRepository _employerFunctionRepository;
    public SelectList EmployerFunctions { get; set; } = null;
    public SelectList EmployerSituations { get; set; } = null;

    public UpsertModel
    (
        ILogger<UpsertModel> logger,
        IEmployerSituationRepository employerSituationRepository,
        IEmployerFunctionRepository employerFunctionRepository,
        IEmployerService employerService
    )
    {
        _logger = logger;
        _service = employerService;
        _employerFunctionRepository = employerFunctionRepository;
        _employerSituationRepository = employerSituationRepository;
    }

    public bool IsEdit { get; private set; } = false;
    [BindProperty]
    public EmployerDTO Employer { get; set; } = new();
    public Exception? Error { get; set; }

    private async Task LoadEnumeratorsAsync()
    {
        EmployerSituations = new SelectList(
            await _employerSituationRepository.GetAllAsync(),
            nameof(EmployerSituation.Id),
            nameof(EmployerSituation.SituationName),
            Employer.IdSituation
            );
        EmployerFunctions = new SelectList(
            await _employerFunctionRepository.GetAllAsync(),
            nameof(EmployerFunction.Id),
            nameof(EmployerFunction.FunctionName),
            Employer.IdFunction
            );
    }
    public async Task<IActionResult> OnGetAsync(int id = 0)
    {
        if (id != 0)
        {
            try { Employer = await _service.GetByIdAsync(id); }
            catch (Exception ex) { Error = ex; }
        }
        await LoadEnumeratorsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadEnumeratorsAsync();

        if (!ModelState.IsValid)
            return Page();

        if (Employer.Id == 0)
            await _service.AddAsync(Employer);
        else
            await _service.UpdateAsync(Employer);

        return RedirectToPage("./Index");
    }
}
