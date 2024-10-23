using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

[Authorize]
public class ContainerController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContainerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var containers = _context.Containers.ToList();
        return View(containers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Container container, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            if (file != null && file.ContentType == "application/pdf" && file.Length <= 5 * 1024 * 1024)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                container.FilePath = filePath;
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("File", "Only PDF files also 5 MB(Max) are allowed.");
            }
        }
        return View(container);
    }
}
