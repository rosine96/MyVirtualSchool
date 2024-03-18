
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using VirtualSchool.Models;

namespace VirtualSchool.Controllers

{
    [Authorize]
    [Authorize(Roles = "manager")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private  UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        }
        public IActionResult UserList()
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string? id)
        {
            if (id == null || _roleManager.Roles == null)
            {
                return NotFound();
            }
            var role = await _roleManager.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (role == null)
            {
                return NotFound();
            }
            return View(role);

        }

        [HttpPost, ActionName("DeleteRole")]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {

            if (_roleManager.Roles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Assign(string userId, string[] selectedRoles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles.ToArray());

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add selected roles to the user.");
                return View();
            }

            return RedirectToAction(nameof(UserList));
        }
    } 

}
    
