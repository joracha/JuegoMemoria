using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace JuegoMemoria
{
    class Memoria : INotifyPropertyChanged
    {
        public IList<Tarjeta> Emojis { private set; get; } = new List<Tarjeta>();

        public event PropertyChangedEventHandler PropertyChanged;

        public int CantidadReveladas { get; private set; }

        // ICommand implementations

        public Memoria()
        {
            CantidadReveladas = 0;

            // Insertamos dos copias de cada emoji en posiciones aleatorias de la lista
            for (int i = 0; i < 8; i++)
            {
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
            }
        }

        public void voltearTarjeta(int numero)
        {
            if (Emojis[numero].Visible)
                CantidadReveladas--;
            else 
                CantidadReveladas++;

            Emojis[numero].voltear();
            OnPropertyChanged("Emojis");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
