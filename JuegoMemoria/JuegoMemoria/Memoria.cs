using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

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

        private int anterior;
        private int nose;

        public IList<Tarjeta> Emojis { private set; get; } = new List<Tarjeta>();

        public event PropertyChangedEventHandler PropertyChanged;

        public int CantidadReveladas { get; private set; }

        // ICommand implementations

        public Memoria(Dificultad dificultad = Dificultad.medio)
        {
            CantidadReveladas = 0;
            tam = (int)dificultad;
            anterior = -1;
            nose = -1;

            // Insertamos dos copias de cada emoji en posiciones aleatorias de la lista
            fillList();
        }

        private void fillList()
        {
            for (int i = 0; i < tam / 2; i++)
            {
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
            }
        }

        public void voltearTarjeta(int numero)
        {
            if (!Emojis[numero].Visible)
            {
                Emojis[numero].voltear();
                CantidadReveladas++;
                OnPropertyChanged("Emojis");
                if (nose == -1)
                {
                    anterior = numero;
                    nose = -3;
                } else
                    nose = -2;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void matenerOVoltearTarjeta(int numero)
        {
            if (nose == -2)
            {
                if (Emojis[numero] != Emojis[anterior])
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                    Emojis[numero].voltear();
                    Emojis[anterior].voltear();
                    CantidadReveladas -= 2;
                    OnPropertyChanged("Emojis");
                }
                else if (tam == CantidadReveladas)
                {
                    Emojis.Clear();
                    fillList();
                    OnPropertyChanged("Emojis");
                    CantidadReveladas = 0;
                }
                nose = -1;
            }

        }
    }
}
