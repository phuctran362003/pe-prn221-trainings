using Repository;
using Repository.Entities;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//add dbcontext
builder.Services.AddDbContext<Equipments2024DbContext>();


//repo
builder.Services.AddScoped<AccountRespository>();
builder.Services.AddScoped<EquipmentRepository>();
builder.Services.AddScoped<RoomRepository>();

//service
builder.Services.AddScoped<AccountService>();
//builder.Services.AddScoped<OilPaintingArtService>();
//builder.Services.AddScoped<SupplierCompanyService>();

//session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
