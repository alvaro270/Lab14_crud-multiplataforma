using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crudlab.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlumnoDetail : ContentPage
    {
        public AlumnoDetail()
        {
            InitializeComponent();
        }
        Model.AlumnoModel _alumno;
        public AlumnoDetail(Model.AlumnoModel alumno)
        {
            InitializeComponent();
            Title = "Editar Informacion";
            _alumno = alumno;
            nombreEntry.Text = alumno.Nombre;
            cumpleEntry.Text = alumno.Cumple.ToString();
            notaEntry.Text = alumno.Nota.ToString();
            apruebaEntry.Text = alumno.Aprobado.ToString();
            nombreEntry.Focus();

        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombreEntry.Text) || string.IsNullOrEmpty(cumpleEntry.Text) || string.IsNullOrEmpty(notaEntry.Text) || string.IsNullOrEmpty(apruebaEntry.Text))
            {
                await DisplayAlert("Invalid", "Existen espacios vacios o en blanco!", "Ok");
            }
            else if (_alumno != null)
            {
                UpdateAlumno();
            }
            else
                AddNewAlumno();
        }

        async void AddNewAlumno()
        {
            await App.AlumnosDatabase.CreateAlumno(new Model.AlumnoModel
            {
                Nombre = nombreEntry.Text,
                Cumple = Convert.ToDateTime(cumpleEntry.Text),
                Nota = Convert.ToInt32(notaEntry.Text),
                Aprobado = bool.Parse(apruebaEntry.Text)
            });
            await Navigation.PopAsync();
        }

        async void UpdateAlumno()
        {
            _alumno.Nombre = nombreEntry.Text;
            _alumno.Cumple = Convert.ToDateTime(cumpleEntry.Text);
            _alumno.Nota = Convert.ToInt32(notaEntry.Text);
            _alumno.Aprobado = bool.Parse(apruebaEntry.Text);
            await App.AlumnosDatabase.UpdateAlumno(_alumno);
            await Navigation.PopAsync();
        }
    }
}