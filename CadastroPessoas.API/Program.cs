using CadastroPessoas.API.Models;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using CadastroPessoas.API.Service;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Server=localhost;Database=BancoTeste;Trusted_Connection=True;TrustServerCertificate=True;")!;

builder.Services.AddControllers();

builder.Services.AddScoped<PessoasCadastro>(sp => new PessoasCadastro(connectionString!));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();


