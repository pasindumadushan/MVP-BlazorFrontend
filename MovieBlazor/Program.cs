using MovieBlazor.Clients;
using MovieBlazor.Components;

var builder = WebApplication.CreateBuilder(args); // Create a new instance of the webApplication Class

// Add services to the container.
// Services are object that add functionality to the application
// Such as NavigationManager, HttpClient etc
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
// RazorComponents are a new feature in ASP.NET core that allows you to build web application using c# and HTML

var movieAppUrl = builder.Configuration["MovieApiUrl"] ?? throw new Exception("Movie API URL is not set"); // Get the URL of the movie app from the configuration file 

builder.Services.AddHttpClient<MoviesClient>(client => client.BaseAddress = new Uri(movieAppUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(movieAppUrl));

var app = builder.Build(); // Build the application // Creates and instance of the WebApplication class

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPs

app.UseStaticFiles(); // Serves static files such as images, CSS and JavaScript in the wwwroot folder
app.UseAntiforgery(); // Protects the application from cross-site request forgery (CSRF) attacks

app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // Maps the RazorComponents to the App Component //Enable server side rendering of the componenets

app.Run(); // Start the application 
