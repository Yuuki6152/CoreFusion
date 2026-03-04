using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoreFusion.Data;
using CoreFusion.Models;  //ApplicationUserを使用する場合

var builder = WebApplication.CreateBuilder(args);

//データベース接続文字列の設定（appsettings.jsonから読み込み）
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//データベースエラーページミドルウェアの追加
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//Identityサービスの登録
/**
 * AddDefaultIdentiry<TUser>はIdentirtyUserManager<TUser>、SignManager<TUser>などを登録
 * AddEntityFrameworkstores<TContext>はIdentityがDbContextを使用してデータを永続化することを指定
 * AddDefaultUIはIdentityの既定のUI（ログイン、登録ページなど）を有効にする
 * AddDefaultTokenProvidesはパスワードリセットトークンなどを生成するためのプロバイダを登録
 */
builder.Services.AddDefaultIdentity<ApplicationUser>(option =>
    option.SignIn.RequireConfirmedAccount = true)   //カスタムユーザを使用
        .AddEntityFrameworkStores<ApplicationDbContext>();  //IdentiryUserを使用する場合

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(); //MVCとAPIコントローラーの両方を有効にする
//Learn more aboud configuring Swagger/OpenAPI at https://aka.ms.aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORSポリシーを追加
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") ///React開発サーバーのオリジンを指定
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //静的ファイルを提供するためのミドルウェア
app.UseRouting();

//認証ミドルウェアを認可ミドルウェアの前に配置することが重要
app.UseAuthentication();    //認証ミドルウェア
app.UseAuthorization();     //認可ミドルウェア


//CORSミドルウェアをルーティングの前に配置する
app.UseCors();


app.MapStaticAssets();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
