using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Syncfusion.Licensing;


namespace ExpenseTracker.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    //GET : Category

    public async Task<IActionResult> Index()
    {
        return _context.Categories != null ? View(await _context.Categories.ToListAsync())
            : Problem("Entity Set 'ApplicationDbContext.Categories' is null.");
    }

    public IActionResult AddOrEdit(int id = 0)
    {
        if (id == 0)
            return View(new Category());
        else
        {
            return View(_context.Categories.Find(id));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
    {
        if (ModelState.IsValid)
        {
            if (category.CategoryId == 0)
                _context.Add(category);
            else
                _context.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    //POST: Category/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Categories == null)
        {
            return Problem(("Entity set 'ApplicationDbContext.Categories' is null"));
        }

        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}