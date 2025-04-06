// MauiProgram.cs
using MabeApp.Services;
using MabeApp.ViewModels;
using MabeApp.Views;
using MabeApp.Converters;

namespace MabeApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { /* ... */ });

        builder.Services.AddSingleton<App>();  
        builder.Services.AddSingleton<AppShell>();
        

        builder.Services.AddSingleton<AuthService>();        
        builder.Services.AddSingleton<MockDataService>();

        builder.Services.AddSingleton<LoginPage>();                                                    
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<SignUpPage>();
        builder.Services.AddSingleton<SignUpViewModel>();
        
        builder.Services.AddSingleton<MainView>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<ProductView>();
        builder.Services.AddTransient<ProductViewModel>();

        builder.Services.AddTransient<DetailsView>();
        builder.Services.AddTransient<DetailsViewModel>();

        builder.Services.AddSingleton<BoolToStatusConverter>();
        builder.Services.AddSingleton<BoolToColorConverter>();

        return builder.Build();
    }
}