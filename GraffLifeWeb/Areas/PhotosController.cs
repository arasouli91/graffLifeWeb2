using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraffLifeWeb.Data;
using System.IO;

namespace GraffLifeWeb.Areas
{
    [Area("PhotosController.cs")]
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhotosController.cs/Photos
        [Route("PhotosController")]
        public async Task<IActionResult> Index()
        {

            using (var fs = new FileStream(@"C:\fakedata\awards.png", FileMode.Open)) 
            { 
                using (var bf = new BufferedStream(fs))
                {
                    byte[] buffer = new byte[bf.Length];
                    bf.Read(buffer, 0, buffer.Length);
                    var p = new Photo
                    {
                        userId = "1e7f1479-4655-4695-9943-88d216c3e862",
                        photoId = 2,
                        photo = buffer,
                        fame = 9
                    };
                    await Create(p);
                    var p2 = new Photo
                    {
                        userId = "1e7f1479-4655-4695-9943-88d216c3e862",
                        photoId = 3,
                        photo = buffer,
                        fame = 2
                    };
                    await Create(p2);

                    var p3 = new Photo
                    {
                        userId = "1e7f1479-4655-4695-9943-88d216c3e862",
                        photoId = 4,
                        photo = buffer,
                        fame = 50
                    };
                    await Create(p3);

                } 
            }

            return View(await _context.UserPhotos.ToListAsync());
        }

        // GET: PhotosController.cs/Photos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.UserPhotos
                .FirstOrDefaultAsync(m => m.userId == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: PhotosController.cs/Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhotosController.cs/Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("photo,userId,photoId")] Photo _photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_photo);
        }

        // GET: PhotosController.cs/Photos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.UserPhotos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: PhotosController.cs/Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("photo,ID")] Photo photo)
        {
            if (id != photo.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.userId))
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
            return View(photo);
        }

        // GET: PhotosController.cs/Photos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.UserPhotos
                .FirstOrDefaultAsync(m => m.userId == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: PhotosController.cs/Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var photo = await _context.UserPhotos.FindAsync(id);
            _context.UserPhotos.Remove(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(string id)
        {
            return _context.UserPhotos.Any(e => e.userId == id);
        }
    }
}
