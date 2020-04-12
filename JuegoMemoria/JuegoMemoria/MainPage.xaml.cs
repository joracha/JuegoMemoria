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
        Memoria model;

        public MainPage()
        {
            InitializeComponent();
            model = new Memoria(Memoria.Dificultad.medio); // Nuevo model con dificultad dificil
            tablero.BindingContext = model; // El bindingContext del grid con nombre tablero sera el modelo
            addRowDef(); // Se agregan los row y col necesarias segun el tam del tablero
            llenarTablero(); // se llenan los campos del tablero
        }

        // llena el tablero segun el model dado
        void llenarTablero()
        {
            int row = 0, colum = 0, counter = 0;

            foreach(Tarjeta tar in model.Emojis)
            {
                if (colum == Math.Sqrt(model.tam)) { colum = 0; row++; }

                tablero.Children.Add(createButton(tar, counter++, row, colum++));
            }
        }

        // Metodo para crear una celda clickeable con una tarjeta dada
        private Button createButton(Tarjeta t, int id, int row, int col)
        {
            Button button = new Button();
            button.ClassId = "" + id;
            button.SetBinding(Button.TextProperty, new Binding() { Path = $"Emojis[{id}]" });
            button.FontSize = 25;
            button.BackgroundColor = Color.FromHex("#075E54");
            button.Released += voltearTarjeta;
            button.Clicked += matenerOVoltearTarjeta;
            Grid.SetRow(button, row);
            Grid.SetColumn(button, col);

            return button;

        }

        // Segun el tamaño del tablero (4,16,36) acomoda todos los campos 
        private void addRowDef()
        {
            int tam = Convert.ToInt32(Math.Sqrt(model.tam));

            for (int i = 0; i < Math.Sqrt(model.tam); i++) 
            {
                tablero.RowDefinitions.Add(new RowDefinition { Height = new GridLength(tam, GridUnitType.Star) });
                tablero.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(tam, GridUnitType.Star) });
            }
                
        }

        // EVENTOS
        void voltearTarjeta(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            Console.WriteLine(" Button " + button.ClassId);
            int id = Int32.Parse(button.ClassId);
            //int min = (model.Emojis[id].Visible) ? 3 : 2; // Si esta visible la seleccionada esta permitido ocultarla
            //if (model.CantidadReveladas < min)
            model.voltearTarjeta(id);
        }

        private void matenerOVoltearTarjeta(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            Console.WriteLine(" Despues " + button.ClassId);
            model.matenerOVoltearTarjeta(id);
        }
    }
}
