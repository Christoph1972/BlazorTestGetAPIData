using Microsoft.Net.Http.Headers;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


//https://localhost:7096;http://localhost:5096 Webpage urls
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7096;http://localhost:5096");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

//https://localhost:7096;http://localhost:5096 Webpage urls
//app.UseCors(policy =>
//    policy.WithOrigins("https://localhost:7096;http://localhost:5096")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType));

app.UseAuthorization();

app.MapControllers();

app.Run();
