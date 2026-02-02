using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using AdapterOut.Messaging;
using AdapterOut.Persistence;
using AdapterOut.Repositories;
using Application.UseCase;
using Ports.Out;
using Core.Ports.Out;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ContractDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<CreateContractUseCase>();

builder.Services.AddScoped<IContractRepository, ContractRepository>();

builder.Services.AddHttpClient<IProposalQueryService, ProposalQueryService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5200");
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

