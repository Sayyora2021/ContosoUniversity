using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create( Student student)
        {
            if(student != null && ModelState.IsValid)
            {
                 _context.Students.Add(student);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id != null && _context.Students.Find(id) != null)
            {
                var student = await _context.Students.FindAsync(id);
                return View(student);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (student != null && ModelState.IsValid)
            {
                _context.Students.Update(student);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id!= null)
            {
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if(student != null)
                {
                    return View(student);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var student = await _context.Students.FindAsync(id);

                if (student != null)
                {

                    return View(student);
                }
                 
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(student);
           
            
        }
       
    }

}
