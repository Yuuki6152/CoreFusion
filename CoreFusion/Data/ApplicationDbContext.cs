
using CoreFusion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreFusion.Data
{
    //IdentityDbContext<TUser>を継承
    //TUserはIdentityUserクラスか、それを継承したカスタムユーザープロファイルクラス
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {

        }

        //必要に応じて、他のエンティティのDbSetをここに追加
        //public DbSet<Product> Products {get;set;}
    }
}
