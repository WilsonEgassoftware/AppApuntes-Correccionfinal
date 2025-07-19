using System.Collections.ObjectModel;

namespace AppApuntes;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Nota> listaNotas { get; set; }

    public MainPage()
    {
        InitializeComponent();

        listaNotas = new ObservableCollection<Nota>();
        BindingContext = this;
    }

    public class Nota
    {
        public string Texto { get; set; }
        public string Fecha { get; set; }
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotaPage(listaNotas));
    }

    private async void About_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new About());
    }

    private async void NotasCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Nota notaSeleccionada)
        {
            NotasCollectionView.SelectedItem = null;
            await Navigation.PushAsync(new NotaPage(listaNotas, notaSeleccionada));
        }
    }
}
