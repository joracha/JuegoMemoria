using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static JuegoMemoria.Memoria;

namespace JuegoMemoria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDificultad : ContentPage
    {
        public MenuDificultad()
        {
            InitializeComponent();
            this.BackgroundImageSource = "https://androidhdwallpapers.com/media/uploads/2017/04/Rainbow-Abstract-Colors-Pattern.jpg";
        }

        void jugar(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            int dif = (int)Dificultad.medio;

            switch (id)
            {
                case 1: dif = (int)Dificultad.facil; break;
                case 2: dif = (int)Dificultad.medio; break;
                case 3: dif = (int)Dificultad.dificil; break;
            }

            Navigation.PushModalAsync(new MainPage(dif), true);
        }
    }
}