using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Indica.Productivity.Web.Pages.Employer
{
    public class ImportModel : PageModel
    {
        [BindProperty]
        public Exception? Error { get; set; }
        [BindProperty]
        public IFormFile FileSent { get; set; }
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        private readonly IEmployerService _service;

        public ImportModel
        (
            IStringLocalizer<SharedResources> sharedLocalizer,
            IEmployerService service
        )
        {
            _service = service;
            _sharedLocalizer = sharedLocalizer;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (FileSent == null || FileSent.Length == 0)
                    throw new InvalidOperationException(
                        _sharedLocalizer["FileErrorEmptyMessage"]);
                await _service.AddRangeAsync(FileSent.OpenReadStream(), FileSent.FileName);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Error = ex;
                return Page();
            }
        }
    }
}
