using AdaptersOut.Messaging;
using AdaptersOut.Persistence;
using AdaptersOut.Repositories;
using Application.UseCases;
using Core.Application.UseCases.ApproveProposal;
using Core.Application.UseCases.CreateProposal;
using Core.Application.UseCases.RejectProposal;
using Microsoft.EntityFrameworkCore;
using Ports.In;
using Ports.Out;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();


#region Use Cases (Ports.In)

builder.Services.AddScoped<CreateProposalUseCase>();
builder.Services.AddScoped<ApproveProposalUseCase>();
builder.Services.AddScoped<RejectProposalUseCase>();
builder.Services.AddScoped<IProposalApprovedPublisher, ProposalApprovedPublisher>();
builder.Services.AddScoped<IContractProposalUseCase, ContractProposalUseCase>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
