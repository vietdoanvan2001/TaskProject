using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskProject.BL;
using TaskProject.BL.BaseBL;
using TaskProject.BL.KanbanBL;
using TaskProject.BL.ProjectBL;
using TaskProject.BL.TaskBL;
using TaskProject.DL;
using TaskProject.DL.BaseDL;
using TaskProject.DL.KanbanDL;
using TaskProject.DL.ProjectDL;
using TaskProject.DL.TaskDL;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//Dependency injection
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUsersDL, UserDL>();
builder.Services.AddScoped<IProjectBL, ProjectBL>();
builder.Services.AddScoped<IProjectDL, ProjectDL>();
builder.Services.AddScoped<IKanbanBL, KanbanBL>();
builder.Services.AddScoped<IKanbanDL, KanbanDL>();
builder.Services.AddScoped<ITaskBL, TaskBL>();
builder.Services.AddScoped<ITaskDL, TaskDL>();
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySQL");


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
