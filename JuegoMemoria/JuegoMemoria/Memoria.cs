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
        public enum Dificultad
        {
            facil = 4,
            medio = 16,
            dificil = 36,
        }

        public readonly int tam;  // AQUI SE CAMBIA LA "DIFICULTAD"

        public IList<Tarjeta> Emojis { private set; get; } = new List<Tarjeta>();

        public event PropertyChangedEventHandler PropertyChanged;

        public int CantidadReveladas { get; private set; }

        // ICommand implementations

        public Memoria(Dificultad dificultad = Dificultad.medio)
        {
            CantidadReveladas = 0;
            tam = (int)dificultad;

            // Insertamos dos copias de cada emoji en posiciones aleatorias de la lista
            for (int i = 0; i < tam/2; i++)
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
