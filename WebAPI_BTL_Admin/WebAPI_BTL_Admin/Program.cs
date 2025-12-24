using DAL;
using BLL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Lấy connection string từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<DAL.LoaichitieuDAL>(provider =>
    new DAL.LoaichitieuDAL(connectionString));

builder.Services.AddScoped<DAL.LoaithunhapDAL>(provider =>
    new DAL.LoaithunhapDAL(connectionString));





// Đăng ký BLL (tự động nhận DAL qua constructor)
builder.Services.AddScoped<LoaichitieuBLL>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();