using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Indica.Productivity.Web.Pages.Composition
{
    public class ImportModel : PageModel
    {
        [BindProperty]
        public Exception? Error { get; set; }
        [BindProperty]
        public IFormFile FileSent { get; set; }
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        private readonly IFieldTeamService _service;

        public ImportModel
        (
            IStringLocalizer<SharedResources> sharedLocalizer,
            IFieldTeamService service
        )
        {
            _service = service;
            _sharedLocalizer = sharedLocalizer;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _service.AddRangeAsync(FileSent.OpenReadStream(), FileSent.FileName);
            }
            catch (Exception ex)
            {
                Error = ex;
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
