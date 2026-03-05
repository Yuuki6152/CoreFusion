using Microsoft.AspNetCore.Identity;

namespace CoreFusion.Models
{
    public class ApplicationUser : IdentityUser
    {
        //カスタムプロパティを追加
        public string? FullName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
