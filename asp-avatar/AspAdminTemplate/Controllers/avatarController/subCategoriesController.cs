


            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Threading.Tasks;
            using Microsoft.AspNetCore.Mvc;
            using Microsoft.AspNetCore.Mvc.Rendering;
            using Microsoft.EntityFrameworkCore;
            using X.PagedList;
                    using AspAdminTemplate.Data;
            using AspAdminTemplate.Models.avatar;
using Microsoft.AspNetCore.Hosting;
using AspAdminTemplate.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace AspAdminTemplate.Controllers.avatarController
            {
        
            public class subCategoriesController : Controller
            {
                private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hosting;

        public subCategoriesController(ApplicationDbContext context, IHostingEnvironment hosting)

                {
                    _context = context;
            this.hosting = hosting;
        }
        // GET: subCategories
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, int ? page)
                {
                    ViewBag.CurrentSort = sortOrder;
            ViewBag.idSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NomSortParm = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";
            ViewBag.miseAjourSortParm = String.IsNullOrEmpty(sortOrder) ? "miseajour_desc" : "";
            ViewBag.TelechargementSortParm = String.IsNullOrEmpty(sortOrder) ? "telechargement_desc" : "";
            ViewBag.FileUrlSortParm = String.IsNullOrEmpty(sortOrder) ? "fileurl_desc" : "";

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            
            var subcategory = from x in _context.subCategory.Include(a => a.Category) select x;

                subcategory = sortOrder switch
        {
            "id_desc"=>  subcategory.OrderByDescending(x => x.id),
            "nom_desc"=>  subcategory.OrderByDescending(x => x.Nom),
            "miseajour_desc"=>  subcategory.OrderByDescending(x => x.miseAjour),
            "telechargement_desc"=>  subcategory.OrderByDescending(x => x.Telechargement),
            "fileurl_desc"=>  subcategory.OrderByDescending(x => x.FileUrl),
            _ => subcategory.OrderBy(x => x.id),
        };
        
            var result = await subcategory.ToListAsync();
            return View(result.ToPagedList(pageNumber, pageSize));

            }
                // GET: subCategories/Details/5

                public async Task<IActionResult> Details(int? id)
                {
                    ViewBag.returnUrl = Request.Headers["Referer"].ToString();

            if (id == null)
            {
                if (TempData["Id"] != null)
                {
                    id = int.Parse(TempData["Id"].ToString());
                }
                else
                {
                    return NotFound();
                }
            }
        
            var subCategory = await _context.subCategory
            .FirstOrDefaultAsync(m => m.id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
                    return View(subCategory);
        }
        // GET: subCategories/Create
        [Authorize]
        public IActionResult Create()
        {
            var model = new categorySubCategories
            {
                Cat = _context.Category.ToList()
            };
            return View(model);
        }

        // POST: subCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(categorySubCategories model)
        {
            try
            {
                string fileName = string.Empty;
                if (model.file != null)
                {
                    string UPload = Path.Combine(hosting.WebRootPath, "assets/files");
                    fileName = model.file.FileName;
                    string fullPath = Path.Combine(UPload, fileName);
                    model.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                subCategory SubCategory = new subCategory
                {

                    id = model.id,
                    Nom = model.Nom,
                    miseAjour = model.miseAjour,
                    Telechargement = model.Telechargement,
                    Category = _context.Category.Find(model.categorieid),
                    FileUrl = fileName,

                };


                _context.subCategory.Add(SubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: subCategories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.subCategory.FindAsync(id);
            var model = new categorySubCategories
            {
                Cat = _context.Category.ToList()
            };
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: subCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nom,miseAjour,Telechargement,file,FileUrl")] categorySubCategories model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string fileName = string.Empty;
                    if (model.file != null)
                    {
                        string UPload = Path.Combine(hosting.WebRootPath, "assets/files");
                        fileName = model.file.FileName;
                        string fullPath = Path.Combine(UPload, fileName);
                        model.file.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    subCategory Catego = new subCategory
                    {
                        id = model.id,
                        Nom = model.Nom,
                        miseAjour = model.miseAjour,
                        Telechargement = model.Telechargement,
                        Category = _context.Category.Find(model.categorieid),
                        FileUrl = fileName,
                    };
                    _context.Update(Catego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!subCategoryExists(model.id))
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
            return View(model);
        }

        // GET: subCategories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.subCategory
                .FirstOrDefaultAsync(m => m.id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: subCategories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.subCategory.FindAsync(id);
            _context.subCategory.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        private bool subCategoryExists(int id)
        {
            return _context.subCategory.Any(e => e.id == id);
        }
    }
}















