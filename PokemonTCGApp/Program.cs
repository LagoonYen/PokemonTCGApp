var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//.net 6.0 寫法
//注入分散式記憶體快取
builder.Services.AddDistributedMemoryCache();
// 注入Session
builder.Services.AddSession(options =>
{
    //session過期時間
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    //設置為true表示前端js等腳本無法讀取cookie,防止了xss攻擊(默認為true)
    options.Cookie.HttpOnly = true;
    //Cookies是必須的(默認為false)
    options.Cookie.IsEssential = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //這樣的話，Controller、Action不必再加上[RequireHttps]屬性
app.UseStaticFiles();  //用於尋找wroot下的資料夾css, js檔案

app.UseRouting();

//使用Session
app.UseSession();

app.UseAuthorization(); //Controller、Action才能加上 [Authorize] 屬性

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
