using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Proyecto_Veterinaria.Models;
using Veterinaria.DAL;

namespace Proyecto_Veterinaria.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthDbContext _authDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUserStore<Usuario> _userStore;
        private readonly IUserEmailStore<Usuario> _emailStore;
        private readonly UserManager<Usuario> _userManager;

        public AdminController(AuthDbContext authDbContext, RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager, IUserStore<Usuario> userStore)
        {
            _authDbContext = authDbContext;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<Usuario>)_userStore;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userRoleViewModelList = new List<UserRoleViewModel>();
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userRoleViewModel = new UserRoleViewModel
                {
                    User = user,
                    Roles = userRoles
                };
                userRoleViewModelList.Add(userRoleViewModel);
            }

            return View(userRoleViewModelList);
        }

        public IActionResult CrearUsuario()
        {
            var listaRol = _roleManager.Roles;
            ViewData["Roles"] = new SelectList(listaRol, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CrearUsuario(AdminCrearUsuarioViewModel usuarioModel, IFormFile ImagenUsuario)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario();
                await _userStore.SetUserNameAsync(user, usuarioModel.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, usuarioModel.Email, CancellationToken.None);
                user.Nombre = usuarioModel.Nombre;
                user.PrimerApellido = usuarioModel.PrimerApellido;
                user.SegundoApellido = usuarioModel.SegundoApellido;
                user.Estado = true;
                user.UltimaConexion = DateTime.Now;
                if (ImagenUsuario != null && ImagenUsuario.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await ImagenUsuario.CopyToAsync(stream);
                        user.ImagenUsuario = stream.ToArray();
                    }
                }
                var result = await _userManager.CreateAsync(user, usuarioModel.Password);
                if (result.Succeeded)
                { 
                    string normalizeRoleName = _roleManager.Roles.FirstOrDefault(r => r.Id == usuarioModel.IdRol).NormalizedName;
                    var resultRole = await _userManager.AddToRoleAsync(user, normalizeRoleName);
                    return RedirectToAction("Index", "Home");
                }
            }
            var listaRol = _roleManager.Roles;
            ViewData["Roles"] = new SelectList(listaRol, "Id", "Name");
            return View(usuarioModel);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.ToListAsync();
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Nombre = user.Nombre,
                // ... (otros campos)
                SelectedRoleId = roles.FirstOrDefault(r => userRoles.Contains(r.Name))?.Id,
                Roles = new SelectList(roles, "Id", "Name")
            };

            return View(model);
        }


        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.FirstOrDefault() != model.SelectedRoleId)
                {
                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                    var newRole = await _roleManager.FindByIdAsync(model.SelectedRoleId);
                    if (newRole != null)
                    {
                        await _userManager.AddToRoleAsync(user, newRole.Name);
                    }
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Estado = false; // Establecer el usuario como inactivo
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Ativar/5
        public async Task<IActionResult> Activar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Ativar/5
        [HttpPost, ActionName("Activar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivarConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Estado = true; // Establecer el usuario como Ativar
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
