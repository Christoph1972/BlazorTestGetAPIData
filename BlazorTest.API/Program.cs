using Microsoft.Net.Http.Headers;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//https://localhost:7096;http://localhost:5096 Webpage urls
builder.Services.AddCors(options =>
{
    /*
    Browser security prevents a web page from making requests to a different domain than the one that served 
    the web page. This restriction is called the same-origin policy. The same-origin policy prevents a malicious 
    site from reading sensitive data from another site. Sometimes, you might want to allow other sites to make 
    cross-origin requests to your app. For more information, see the Mozilla CORS article.
     */
    options.AddPolicy(MyAllowSpecificOrigins, builder => builder.WithOrigins("https://localhost:7096")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true));
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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
