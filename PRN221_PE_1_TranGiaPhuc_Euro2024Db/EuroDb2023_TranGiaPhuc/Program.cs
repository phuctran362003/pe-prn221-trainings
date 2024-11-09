using Repository;
using Repository.Entities;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Euro2024DbContext>();
//service
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<GroupTeamService>();
//repo
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<GroupTeamRepository>();
builder.Services.AddScoped<TeamRepository>();

//add session
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//use session
app.UseSession();
app.MapRazorPages();
app.Run();
