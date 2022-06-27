using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crudlab.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crudlab.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlumnoPage : ContentPage
    {
        public AlumnoPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.AlumnosDatabase.ReadAlumnos();
            }
            catch { }
        }
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlumnoDetail());
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var Item = sender as SwipeItem;
            var alumn = Item.CommandParameter as AlumnoModel;
            await Navigation.PushAsync(new AlumnoDetail(alumn));
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var alumn = item.CommandParameter as AlumnoModel;
            var result = await DisplayAlert("Eliminar", $"Eliminar {alumn.Nombre} del sistema?", "Si", "No");
            if (result)
            {
                await App.AlumnosDatabase.DeleteAlumno(alumn);
                myCollectionView.ItemsSource = await App.AlumnosDatabase.ReadAlumnos();
            }

        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            myCollectionView.ItemsSource = await App.AlumnosDatabase.Search(e.NewTextValue);
        }
    }

}