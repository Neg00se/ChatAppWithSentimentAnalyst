using ChatAppWithSentimentAnalyst.Components;
using ChatAppWithSentimentAnalyst.Hubs;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;
using ServicesLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents().AddCircuitOptions(options => { options.DetailedErrors = true; });

builder.Services.AddScoped<IChatRepository, ChatRepository>();

builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddSingleton<SentimentAnalysisService>();

builder.Services.AddDbContext<ChatAppDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("azureDb")));

builder.Services.AddResponseCompression(opts =>
{
	opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
		["application/octet-stream"]);
});

builder.Services.AddSignalR().AddAzureSignalR();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.MapHub<ChatHub>("/chathub");

app.Run();
