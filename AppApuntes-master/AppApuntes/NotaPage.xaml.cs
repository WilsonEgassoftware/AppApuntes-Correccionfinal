using System.Collections.ObjectModel;

namespace AppApuntes;

public partial class NotaPage : ContentPage
{
    private MainPage.Nota notaActual;
    private ObservableCollection<MainPage.Nota> listaNotas;

    public NotaPage(ObservableCollection<MainPage.Nota> notas, MainPage.Nota notaSeleccionada = null)
    {
        InitializeComponent();
        listaNotas = notas;
        notaActual = notaSeleccionada;

        if (notaActual != null)
        {
            TextEditor.Text = notaActual.Texto;
        }
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextEditor.Text))
        {
            await DisplayAlert("Advertencia", "La nota no puede estar vacía.", "OK");
            return;
        }

        if (notaActual != null)
        {
            notaActual.Texto = TextEditor.Text;
            notaActual.Fecha = DateTime.Now.ToString("g");
        }
        else
        {
            listaNotas.Add(new MainPage.Nota
            {
                Texto = TextEditor.Text,
                Fecha = DateTime.Now.ToString("g")
            });
        }

        await Navigation.PopAsync();
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        if (notaActual != null)
        {
            bool confirm = await DisplayAlert("Confirmar", "¿Eliminar esta nota?", "Sí", "No");
            if (confirm)
            {
                listaNotas.Remove(notaActual);
                await Navigation.PopAsync();
            }
        }
        else
        {
            await DisplayAlert("Nada que eliminar", "Esta nota no ha sido guardada aún.", "OK");
        }
    }
}
