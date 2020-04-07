using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JuegoMemoria
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Memoria model = new Memoria();

        public MainPage()
        {
            InitializeComponent();
            model = (Memoria)tablero.BindingContext;
        }

        void voltearTarjeta(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            int min = (model.Emojis[id].Visible) ? 3 : 2; // Si esta visible la seleccionada esta permitido ocultarla
            if(model.CantidadReveladas < min)
                model.voltearTarjeta(id);
        }
    }
}
