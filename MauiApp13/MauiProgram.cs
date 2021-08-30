using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Hosting;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace MauiApp13
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.SemanticOrderViewRenderer).Assembly);

#if ANDROID
                    handlers.AddCompatibilityRenderer(typeof(Xamarin.CommunityToolkit.UI.Views.Shield),
                        typeof(Microsoft.Maui.Controls.Compatibility.Platform.Android.ViewRenderer));
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}