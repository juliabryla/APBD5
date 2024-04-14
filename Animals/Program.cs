using System.ComponentModel.DataAnnotations;
using Animals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMockDb, MockDb>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/mzwierzeta", (IMockDb mockDb) =>
{
    return Results.Ok(mockDb.GetAll());
});

app.MapGet("/mzwierzeta/{id}", (IMockDb mockDb, int id) =>
{
    var zwierze = mockDb.GetById(id);
    if (zwierze is null) return Results.NotFound();
    
    return Results.Ok(zwierze);
});
app.MapPost("/mzwierzeta", (IMockDb mockDb, Zwierze zwierze) =>
{
    mockDb.Add(zwierze);
    return Results.Created();
});
app.MapDelete("/mzwierzeta/{id}", (IMockDb mockDb, int id) =>
{
    var existingZwierze = mockDb.GetById(id);
    if (existingZwierze is null) return Results.NotFound();
    mockDb.Remove(existingZwierze);
    return Results.Ok();
});
app.MapGet("/wizyty", (IMockDb mockDb,Zwierze zwierze) =>
{
    return Results.Ok(mockDb.GetWizyty(zwierze));
});
app.MapPost("/wizyty", (IMockDb mockDb, Wizyty wizyta) =>
{
    mockDb.AddWizyta(wizyta);
    return Results.Created();
});

app.Run();

