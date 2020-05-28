


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
using Microsoft.AspNetCore.Authorization;

namespace AspAdminTemplate.Controllers.avatarController
            {
        
            public class formsController : Controller
            {
                private readonly ApplicationDbContext _context;
                    public formsController(ApplicationDbContext context)

                {
                    _context = context;
                }
        // GET: forms
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, int ? page)
                {
                    ViewBag.CurrentSort = sortOrder;
            ViewBag.idSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NomSortParm = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";
            ViewBag.PrenomSortParm = String.IsNullOrEmpty(sortOrder) ? "prenom_desc" : "";
            ViewBag.emailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.NumeroAbonnementSortParm = String.IsNullOrEmpty(sortOrder) ? "numeroabonnement_desc" : "";
            ViewBag.nomFilmSortParm = String.IsNullOrEmpty(sortOrder) ? "nomfilm_desc" : "";

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            
            var forms = from x in _context.forms select x;

                forms = sortOrder switch
        {
            "id_desc"=>  forms.OrderByDescending(x => x.id),
            "nom_desc"=>  forms.OrderByDescending(x => x.Nom),
            "prenom_desc"=>  forms.OrderByDescending(x => x.Prenom),
            "email_desc"=>  forms.OrderByDescending(x => x.email),
            "numeroabonnement_desc"=>  forms.OrderByDescending(x => x.NumeroAbonnement),
            "nomfilm_desc"=>  forms.OrderByDescending(x => x.nomFilm),
            _ => forms.OrderBy(x => x.id),
        };
        
            var result = await forms.ToListAsync();
            return View(result.ToPagedList(pageNumber, pageSize));

            }
                // GET: forms/Details/5

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
        
            var forms = await _context.forms
            .FirstOrDefaultAsync(m => m.id == id);
            if (forms == null)
            {
                return NotFound();
            }
                    return View(forms);
        }
        // GET: forms/Create
            public IActionResult Create()
            {
        ViewBag.returnUrl = Request.Headers["Referer"].ToString();

                return View();
            }
        
            // POST: forms/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("id,Nom,Prenom,email,NumeroAbonnement,nomFilm")] forms forms, string returnUrl)
            {
        
                if (ModelState.IsValid)
                {
                _context.Add(forms);
        await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }

                return View(forms);
            }
        
            // GET: forms/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();

            if (id == null)
            {
                return NotFound();
            }

            var forms = await _context.forms.FindAsync(id);
            if (forms == null)
            {
                return NotFound();
            }
        
                return View(forms);
            }
        
            // POST: forms/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nom,Prenom,email,NumeroAbonnement,nomFilm")] forms forms,string returnUrl)
            {
        
            if (id != forms.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!formsExists(forms.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect(returnUrl);
            }
        
                return View(forms);
            }

        // GET: forms/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
            {
                ViewBag.returnUrl = Request.Headers["Referer"].ToString();

            if (id == null)
            {
            return NotFound();
            }

            var forms = await _context.forms
            .FirstOrDefaultAsync(m => m.id == id);
            if (forms == null)
            {
            return NotFound();
            }
        
                return View(forms);
            }
        
            // POST: forms/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id,string returnUrl)
            {
        
            var forms = await _context.forms.FindAsync(id);
            _context.forms.Remove(forms);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
            private bool formsExists(int id)
            {
                return _context.forms.Any(e => e.id == id);
            }
        
            }
        
            }
                                     
















