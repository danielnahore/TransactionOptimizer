using TransactionProcessor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddSingleton<ITransactionQueue, TransactionQueue>();
builder.Services.AddHostedService<TransactionProcessorService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();


