using Microsoft.AspNetCore.Mvc;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
