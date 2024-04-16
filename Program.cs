


using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Impl;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDBContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

 
  builder.Services.AddScoped<ICompanyService, CompanyService>();
  builder.Services.AddScoped<IEmployeeService, EmployeeService>();
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
  builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
  builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
  builder.Services.AddMvc().AddControllersAsServices(); 
  builder.Services.AddControllersWithViews(); // Or services.AddMvc() for older versions


 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();
return;

