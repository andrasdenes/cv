using cv.Components;
using Microsoft.AspNetCore.Localization;
using Radzen;
using System.Globalization;

namespace cv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddRadzenComponents();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            var supportedCultures = new[] { "en-US", "hu-HU" }
                .Select(c => new CultureInfo(c))
                .ToList();

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders = new IRequestCultureProvider[]
            {
                new CookieRequestCultureProvider(),
                // optionally: new AcceptLanguageHeaderRequestCultureProvider(),
                // optionally: new RouteDataRequestCultureProvider() // if you want /hu/...
            };

            app.UseRequestLocalization(localizationOptions);

            var supported = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "en-US", "hu-HU" };

            app.MapGet("/culture/set", (string culture, string? redirectUri, HttpContext http) =>
            {
                if (!supported.Contains(culture))
                    culture = "en-US";

                // prevent open redirect
                if (string.IsNullOrWhiteSpace(redirectUri) || !Uri.IsWellFormedUriString(redirectUri, UriKind.Relative))
                    redirectUri = "/";

                http.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        IsEssential = true,
                        HttpOnly = false,
                        Secure = http.Request.IsHttps,
                        SameSite = SameSiteMode.Lax
                    });

                return Results.LocalRedirect(redirectUri);
            });

            app.Run();
        }
    }
}
