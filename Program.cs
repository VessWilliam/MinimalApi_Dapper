using APIDonefully;
using DataAccess.DbAccess;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISqlDataAccess , SqlDataAccess>();
builder.Services.AddScoped<IUserData, UserData>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.ConfigureApi();

app.Run();

