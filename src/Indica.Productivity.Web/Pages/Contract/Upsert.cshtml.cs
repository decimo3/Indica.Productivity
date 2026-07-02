using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indica.Productivity.Web.Pages.Contract;

public class UpsertModel : PageModel
{
    private readonly ILogger<UpsertModel> _logger;
    private readonly IContractService _contractService;
    private readonly IProjectRepository _projectRepository;
    private readonly IDerivationRepository _derivationRepository;
    private readonly IFieldTeamRegionalRepository _regionalRepository;


    public UpsertModel
    (
        ILogger<UpsertModel> logger,
        IContractService contractService,
        IProjectRepository projectRepository,
        IDerivationRepository derivationRepository,
        IFieldTeamRegionalRepository regionalRepository
    )
    {
        _logger = logger;
        _contractService = contractService;
        _projectRepository = projectRepository;
        _derivationRepository = derivationRepository;
        _regionalRepository = regionalRepository;
    }

    [BindProperty]
    public Exception? Error { get; set; }
    [BindProperty]
    public ContractDTO Contract { get; set; } = new();
    public SelectList ProjectSelect { get; set; } = null;
    public SelectList DerivationSelect { get; set; } = null;
    public SelectList RegionalSelect { get; set; } = null;

    private async Task LoadEnumeratorsAsync()
    {
        ProjectSelect = new SelectList(
            await _projectRepository.GetAllAsync(),
            nameof(Indica.Productivity.Domain.Entities.Project.ProjectName),
            nameof(Indica.Productivity.Domain.Entities.Project.ProjectName)
            );
        DerivationSelect = new SelectList(
            await _derivationRepository.GetAllAsync(),
            nameof(Indica.Productivity.Domain.Entities.Derivation.DerivationName),
            nameof(Indica.Productivity.Domain.Entities.Derivation.DerivationName)
            );
        RegionalSelect = new SelectList(
            await _regionalRepository.GetAllAsync(),
            nameof(Indica.Productivity.Domain.Entities.FieldTeamRegional.RegionName),
            nameof(Indica.Productivity.Domain.Entities.FieldTeamRegional.RegionName)
            );
    }

    public async Task<IActionResult> OnGetAsync(int id = 0)
    {
        if (id != 0)
        {
            try { this.Contract = await _contractService.GetByIdAsync(id); }
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

        if (this.Contract.Id == 0)
            await _contractService.AddAsync(this.Contract);
        else
            await _contractService.UpdateAsync(this.Contract);

        return Page();
    }
}
