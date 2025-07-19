namespace AppApuntes;

public partial class About : ContentPage
{
    public About()
    {
        InitializeComponent();
    }
    // realizamos una incialializaciok de la clases 

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://learn.microsoft.com/dotnet/maui/");
    }
}
