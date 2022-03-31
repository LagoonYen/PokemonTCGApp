using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using PokemonTCGApp.Model;
using PokemonTCGApp.Repository;
using PokemonTCGApp.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PokemonTCGDatabaseSettings>(
    builder.Configuration.GetSection(nameof(PokemonTCGDatabaseSettings)));

builder.Services.AddSingleton<IPokemonTCGDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PokemonTCGDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("PokemonTCGDatabaseSettings:ConnectionStrings")));

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();


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

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PTCG�d�P�ӫ� API",
        Version = "v1",
        Description = "���ѦU���U��API�걵"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "PTCGSHOP API");
    x.RoutePrefix = String.Empty;
});

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
