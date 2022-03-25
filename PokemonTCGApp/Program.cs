var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//.net 6.0 �g�k
//�`�J�������O����֨�
builder.Services.AddDistributedMemoryCache();
// �`�JSession
builder.Services.AddSession(options =>
{
    //session�L���ɶ�
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    //�]�m��true��ܫe��js���}���L�kŪ��cookie,����Fxss����(�q�{��true)
    options.Cookie.HttpOnly = true;
    //Cookies�O������(�q�{��false)
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

app.UseHttpsRedirection(); //�o�˪��ܡAController�BAction�����A�[�W[RequireHttps]�ݩ�
app.UseStaticFiles();  //�Ω�M��wroot�U����Ƨ�css, js�ɮ�

app.UseRouting();

//�ϥ�Session
app.UseSession();

app.UseAuthorization(); //Controller�BAction�~��[�W [Authorize] �ݩ�

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
