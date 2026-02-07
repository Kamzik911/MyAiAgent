using MyAiAgent.Methods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var apiKey = builder.Configuration["OpenAI:ApiKey"];
if (string.IsNullOrEmpty(apiKey))
    throw new InvalidOperationException("Missing OpenAI: ApiKey in user secrets");

var model = builder.Configuration["OpenAI:Model"] ?? "gpt-5.2";

builder.Services.AddSingleton<MyAiAgent.ITestMethods>(_ =  new TestMethods(apiKey, model));
builder.Services.AddSingleton<MyAiAgent.Services.TestDesignAgent>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
