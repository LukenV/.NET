var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/calculatetva", (double productPrice, string countryCode) =>
{
    double belgiumTvaRate = 0.21;
    double franceTvaRate = 0.20;
    double tvaRate = 0.0;

    if (countryCode == "BE") tvaRate = belgiumTvaRate;
    if (countryCode == "FR") tvaRate = franceTvaRate;

    double tvaPrice = productPrice + productPrice*tvaRate;

    return $"price : {productPrice}, country : '{countryCode}' -> {tvaPrice}";
})
.WithName("CalculateTVA")
.WithOpenApi();

app.Run();
