using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace RestArtIS.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddHttpClient("RestArtIS.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // Supply HttpClient instances that include access tokens when making requests to the server project
            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("RestArtIS.ServerAPI"));



            //builder.Services.AddOptions();
            //builder.Services.AddAuthorizationCore();
            //builder.Services.AddMudBlazorResizeListener();
            //builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();
            //// builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            //// builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            //builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();



            builder.Services.AddMudServices();
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar();
            


            //builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
