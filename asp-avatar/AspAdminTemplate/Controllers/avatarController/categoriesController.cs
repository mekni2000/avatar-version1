


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
            using AspAdminTemplate.ViewModels;
            using System.IO;
            using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace AspAdminTemplate.Controllers.avatarController
            {

    public class categoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hosting;

        public categoriesController(ApplicationDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }

        // GET: categories
      
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, int ? page)
                {
                    ViewBag.CurrentSort = sortOrder;
            ViewBag.idSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.nameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AvatarSortParm = String.IsNullOrEmpty(sortOrder) ? "avatar_desc" : "";

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            
            var category = from x in _context.Category select x;

                category = sortOrder switch
        {
            "id_desc"=>  category.OrderByDescending(x => x.id),
            "name_desc"=>  category.OrderByDescending(x => x.name),
            "avatar_desc"=>  category.OrderByDescending(x => x.Avatar),
            _ => category.OrderBy(x => x.id),
        };
        
            var result = await category.ToListAsync();
            return View(result.ToPagedList(pageNumber, pageSize));

        }




        // GET: categories



        // GET: categories
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Category.ToListAsync());
        //}
        //index category admin


        [Authorize] 
        public async Task<IActionResult> IndexAdmin(string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.idSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.nameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AvatarSortParm = String.IsNullOrEmpty(sortOrder) ? "avatar_desc" : "";

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var category = from x in _context.Category select x;

            category = sortOrder switch
            {
                "id_desc" => category.OrderByDescending(x => x.id),
                "name_desc" => category.OrderByDescending(x => x.name),
                "avatar_desc" => category.OrderByDescending(x => x.Avatar),
                _ => category.OrderBy(x => x.id),
            };

            var result = await category.ToListAsync();
            return View(result.ToPagedList(pageNumber, pageSize));

        }
        // GET: categories/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Category
                    .FirstOrDefaultAsync(m => m.id == id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

        // GET: categories/Create
        [Authorize]
        public IActionResult Create()
            {
                return View();
            }

            // POST: categories/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(AvatarCategories avatarCategories)
            {
                try
                {
                    string fileName = string.Empty;
                if (avatarCategories.avatar != null)
                {
                    string UPload = Path.Combine(hosting.WebRootPath, "assets/files");
                    fileName = avatarCategories.avatar.FileName;
                    string fullPath = Path.Combine(UPload, fileName);
                    avatarCategories.avatar.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                category Catego = new category
                    {
                        id = avatarCategories.id,
                        name = avatarCategories.name,
                        Avatar = fileName,
                    };


                    _context.Category.Add(Catego);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexAdmin));
                }
                catch
                {
                    return View();
                }

            }

        // GET: categories/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Category.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                var viewModel = new AvatarCategories
                {
                    id = category.id,
                    name = category.name,
                    Avatar = category.Avatar
                };
                return View(viewModel);
            }

            // POST: categories/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,avatar,Avatar")]  AvatarCategories avatarCategories)
            {

                if (id != avatarCategories.id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        string fileName = string.Empty;
                    if (avatarCategories.avatar != null)
                    {
                        string UPload = Path.Combine(hosting.WebRootPath, "assets/files");
                        fileName = avatarCategories.avatar.FileName;
                        string fullPath = Path.Combine(UPload, fileName);
                        avatarCategories.avatar.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    category Catego = new category
                        {
                            id = avatarCategories.id,
                            name = avatarCategories.name,
                            Avatar = fileName,
                        };
                        _context.Update(Catego);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!categoryExists(avatarCategories.id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(IndexAdmin));
                }
                return View(avatarCategories);
            }

        // GET: categories/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Category
                    .FirstOrDefaultAsync(m => m.id == id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

        // POST: categories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var category = await _context.Category.FindAsync(id);
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexAdmin));
            }
            public async Task<IActionResult> afFicheSubCategory(int id, categorySubCategories categorySubCategories)
            {
                ViewBag.getCategorie = _context.Category.Find(id);
                return View(await _context.subCategory.Include(a => a.Category).Where(a => a.Category.id == id).ToListAsync());
            }
            private bool categoryExists(int id)
            {
                return _context.Category.Any(e => e.id == id);
            }


            //search


        }
    }
















