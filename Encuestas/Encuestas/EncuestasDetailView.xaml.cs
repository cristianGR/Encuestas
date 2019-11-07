using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encuestas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EncuestasDetailView : ContentPage
    {
        private readonly string[] equipos =
        {
            "Boca",
            "River",
            "San Lorenzo",
            "Racing",
            "Estudiantes",
            "Independiente",
            "Newell´s",
            "Lanús",
            "Huracán"
        };
        public EncuestasDetailView()
        {
            InitializeComponent();
        }

        private async void BtnEquipoFavorito(object sender, EventArgs args)
        {
            var equipoFavorito = await DisplayActionSheet("Equipo Favorito", null, null, equipos);
            if (!string.IsNullOrWhiteSpace(equipoFavorito))
                LblEquipoFavorito.Text = equipoFavorito;
        }

        private async void BtnAceptarEncuesta(object sender, EventArgs args)
        {
            if (string.IsNullOrWhiteSpace(EntryNombre.Text) || string.IsNullOrWhiteSpace(LblEquipoFavorito.Text))
                return;
            var encuesta = new Encuesta()
            {
                Nombre = EntryNombre.Text,
                Cumpleaños = DatePickerCumpleaños.Date,
                EquipoFavorito = LblEquipoFavorito.Text,
            };

            MessagingCenter.Send<EncuestasDetailView,Encuesta>(this,Mensajes.MsgEncuestaCompletada, encuesta);

            await Navigation.PopAsync();
        }
    }
}