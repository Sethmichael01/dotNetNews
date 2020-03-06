using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotNetNews.Data;
using dotNetNews.Models;

namespace dotNetNews.Controllers
{
    public class dotNetNewsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public dotNetNewsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: dotNetNewsModels
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.dotNetNewsModels
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Title.Contains(searchString)
                                       || s.ShortDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.DateTime);
                    break;
                default:
                    students = students.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<dotNetNewsModel>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Tech(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.dotNetNewsModels
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Title.Contains(searchString)
                                       || s.ShortDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.DateTime);
                    break;
                default:
                    students = students.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<dotNetNewsModel>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Science(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.dotNetNewsModels
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Title.Contains(searchString)
                                       || s.ShortDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.DateTime);
                    break;
                default:
                    students = students.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<dotNetNewsModel>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: dotNetNewsModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dotNetNewsModel = await _context.dotNetNewsModels
                .FirstOrDefaultAsync(m => m.Title.Replace(" ","-") == id.Replace(" ","-"));
            if (dotNetNewsModel == null)
            {
                return NotFound();
            }

            return View(dotNetNewsModel);
        }

        // GET: dotNetNewsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dotNetNewsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(dotNetNewsModel dotNetNewsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dotNetNewsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dotNetNewsModel);
        }

        // GET: dotNetNewsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dotNetNewsModel = await _context.dotNetNewsModels.FindAsync(id);
            if (dotNetNewsModel == null)
            {
                return NotFound();
            }
            return View(dotNetNewsModel);
        }

        // POST: dotNetNewsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,dotNetNewsModel dotNetNewsModel)
        {
            if (id != dotNetNewsModel.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dotNetNewsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dotNetNewsModelExists(dotNetNewsModel.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dotNetNewsModel);
        }

        // GET: dotNetNewsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dotNetNewsModel = await _context.dotNetNewsModels
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (dotNetNewsModel == null)
            {
                return NotFound();
            }

            return View(dotNetNewsModel);
        }

        // POST: dotNetNewsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dotNetNewsModel = await _context.dotNetNewsModels.FindAsync(id);
            _context.dotNetNewsModels.Remove(dotNetNewsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dotNetNewsModelExists(int id)
        {
            return _context.dotNetNewsModels.Any(e => e.ProductId == id);
        }
    }
}
