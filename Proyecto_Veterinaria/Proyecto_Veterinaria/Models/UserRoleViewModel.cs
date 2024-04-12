using Veterinaria.DAL;

namespace Proyecto_Veterinaria.Models
{
    public class UserRoleViewModel
    {
        public Usuario User { get; set; }
        public IList<string> Roles { get; set; }
    }
}