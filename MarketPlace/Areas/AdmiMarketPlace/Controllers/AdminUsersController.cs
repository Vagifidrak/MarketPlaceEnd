using MarketPlace.Models;
using MarketPlace.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MarketPlace.Areas.AdmiMarketPlace.Controllers
{
    public class AdminUsersController : Controller
    {
        // GET: AdmiMarketPlace/AdminUsers
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminUsersController()
        {
            
        }
        public AdminUsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public ActionResult Index()
        {
            return View(/*_userManager.Users.ToList()*/);
        }


        public async Task<ActionResult> Edit(string Id)
        {
            if (Id == null)
                return HttpNotFound();
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(Id);
            if (applicationUser == null)
                return HttpNotFound();
            return View(applicationUser);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string userid, string role)
        {
            if (userid == null || role == null)
            {
                return HttpNotFound();
            }
            ApplicationUser appUser = await _userManager.FindByIdAsync(userid);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            IdentityResult result = await _userManager.RemoveFromRoleAsync(userid, role);
            return RedirectToAction(nameof(Edit), new { id = userid });

        }

        public async Task<ActionResult> AddRole(string userid)
        {
            if (userid == null) HttpNotFound();
            ApplicationUser appUser = await _userManager.FindByIdAsync(userid);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            var userRoles = (await _userManager.GetRolesAsync(appUser.Id)).ToList();
            var allRoles = _roleManager.Roles.Select(x => x.Name).ToList();

            UserAddRoleVM userAddRoleVM = new UserAddRoleVM()
            {
                AppUser = appUser,
                Roles = allRoles.Except(userRoles)
            };
            return View(userAddRoleVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRole(string id, string role)
        {
            if (id == null || role == null)
            {
                return HttpNotFound();
            }
            ApplicationUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            var result = await _userManager.AddToRoleAsync(appUser.Id, role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), new { id = id });
            }
            return RedirectToAction(nameof(AddRole), new { id = id });
        } 
    }
}