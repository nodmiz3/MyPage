var builder = WebApplication.CreateBuilder(args);

// 起動時刻を保持するサービスを DI に登録
builder.Services.AddSingleton<StartTimeService>();

// 既存のサービス登録（例）
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 既存のミドルウェア構成（テンプレート標準想定）
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
