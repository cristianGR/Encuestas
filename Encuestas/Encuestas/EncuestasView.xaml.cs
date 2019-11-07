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
    public partial class EncuestasView : ContentPage
    {
        public EncuestasView()
        {
            InitializeComponent();
           
            MessagingCenter.Subscribe<EncuestasDetailView,Encuesta>(this,Mensajes.MsgEncuestaCompletada,(sender, args) =>
            {
                PanelDeEncuestas.Children.Add(new Label()
                {
                    Text =  args.ToString()
                });
                
            });
        }

        public async void AgregarEncuesta(Object sender, EventArgs args )
        {
            await Navigation.PushAsync(new EncuestasDetailView());
        }
       
    }
}