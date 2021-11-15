using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MisicPlay.Models;

using MusicPlay.WebApplication.Models;
using MusicPlay.Constants.Database;

namespace MusicPlay.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private const string NORMAL_USER_EMAIL = "user@test.test";
        private const string ADMIN_USER_EMAIL = "admin@test.test";

        private RoleManager<IdentityRole> roleManager;
        private UserManager<User> userManager;

        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            await this.SeedRoles();
            await this.SeedUsres();
            await this.SeedUsersRolesMappingTable();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task SeedRoles()
        {
            int rolesCount = roleManager.Roles.ToArray().Length;

            if (rolesCount != 0)
            {
                return;
            }

            var roleAdmin = new IdentityRole(DatabaseConstants.AdminRole);
            var roleUser = new IdentityRole(DatabaseConstants.NormalUserRole);

            await roleManager.CreateAsync(roleAdmin);
            await roleManager.CreateAsync(roleUser);
        }

        private async Task SeedUsres()
        {
            int usersCount = userManager.Users.ToArray().Length;

            if (usersCount != 0)
            {
                return;
            }

            string normalUserPassword = "1234";
            var normalUser = new User();
            normalUser.Email = NORMAL_USER_EMAIL;
            normalUser.UserName = NORMAL_USER_EMAIL;

            string adminUserPassword = "1234";
            var adminUser = new User();
            adminUser.Email = ADMIN_USER_EMAIL;
            adminUser.UserName = ADMIN_USER_EMAIL;

            await this.userManager.CreateAsync(normalUser, normalUserPassword);
            await this.userManager.CreateAsync(adminUser, adminUserPassword);
        }

        private async Task SeedUsersRolesMappingTable()
        {
            int usersCount = userManager.Users.ToArray().Length;
            int rolesCount = roleManager.Roles.ToArray().Length;

            bool hasUsersAndRoles = usersCount > 0 && rolesCount > 0;

            if (!hasUsersAndRoles)
            {
                return;
            }

            var normalUser = userManager.Users.SingleOrDefault(u => u.Email == NORMAL_USER_EMAIL);
            var adminUser = userManager.Users.SingleOrDefault(u => u.Email == ADMIN_USER_EMAIL);

            await userManager.AddToRoleAsync(normalUser, DatabaseConstants.NormalUserRole);
            await userManager.AddToRoleAsync(adminUser, DatabaseConstants.AdminRole);
        }
    }
}
