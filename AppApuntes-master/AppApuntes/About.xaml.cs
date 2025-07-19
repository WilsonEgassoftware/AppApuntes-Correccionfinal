namespace AppApuntes;

public partial class About : ContentPage
{
    public About() //iniciaríamos los componentes defenidos en la clase about
    {
        InitializeComponent();
    }
    // abre la navegación web con la URL de maui 
    //LearnMore se declarará para cuando hacer clic ejecuta el botón 

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://learn.microsoft.com/dotnet/maui/");
    }
}
