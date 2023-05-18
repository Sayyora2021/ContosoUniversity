using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (course != null && ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null && _context.Courses.Find(id) != null)
            {
                var course = await _context.Courses.FindAsync(id);
                return View(course);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (course != null && ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var course = await _context.Courses.FirstOrDefaultAsync(s => s.Id == id);
                if (course != null)
                {
                    return View(course);
                }
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var course = await _context.Courses.FindAsync(id);

                if (course != null)
                {

                    return View(course);
                }

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);


        }
    }
}
