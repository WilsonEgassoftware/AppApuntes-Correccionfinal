using Microsoft.Extensions.Logging;

namespace AppApuntes
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        { // creamos el constructor para configurar la app
            var builder = MauiApp.CreateBuilder();
            builder// configuramos la clase app como clase , y como punto de entrada
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>// configurar las funciones del programa 
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();// habilitamos el registro del mensaje para depurar
#endif

            return builder.Build();
        }
    }
}
