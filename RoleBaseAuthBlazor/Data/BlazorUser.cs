using Microsoft.AspNetCore.Identity;

namespace RoleBaseAuthBlazor.Data
{
    public sealed class BlazorUser : IdentityUser
    {
        public ICollection<Practice> Practices { get; set; }
        public ICollection<Moneyy> Money { get; set; }
    }
}
