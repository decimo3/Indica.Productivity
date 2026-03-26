using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Application.DTO;

namespace Indica.Productivity.Web.App.Pages.Employer;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IEmployerService _service;

    public IndexModel(ILogger<IndexModel> logger, IEmployerService service)
    {
        _logger = logger;
        _service = service;
    }

    public List<EmployerDTO> Employers { get; private set; } = new();

    public async Task OnGetAsync()
    {
        try { Employers = await _service.GetAllAsync(); }
        catch (System.Exception) { }
    }
}
