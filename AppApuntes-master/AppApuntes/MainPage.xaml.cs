using System.Collections.ObjectModel;

namespace AppApuntes;
//definición de la clase mainpage
public partial class MainPage : ContentPage
{ //propiedad que contiene varios objetos de la clase Nota 
    public ObservableCollection<Nota> listaNotas { get; set; }

    public MainPage()
    {
        InitializeComponent();

        listaNotas = new ObservableCollection<Nota>();
        BindingContext = this;
    }

    public class Nota
    {
        public string Texto { get; set; }// contenido 
        public string Fecha { get; set; }// fecha de registro de la nota 
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
    {// verificamos si hay jna Nota seleccionada 
        if (e.CurrentSelection.FirstOrDefault() is Nota notaSeleccionada)
        { // Dejamos de seleccionar el elemento para permitir nuevas selecciones de notas 
            NotasCollectionView.SelectedItem = null;
            await Navigation.PushAsync(new NotaPage(listaNotas, notaSeleccionada));
        }
    }
}
