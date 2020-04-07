using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoMemoria
{
    class Memoria
    {
        public IList<Tarjeta> Emojis { private set; get; } = new List<Tarjeta>();

        public Memoria()
        {
            // Insertamos dos copias de cada emoji en posiciones aleatorias de la lista
            for (int i = 0; i < 8; i++)
            {
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
                Emojis.Insert((new Random()).Next(Emojis.Count), new Tarjeta(ListaEmojis.All[i]));
            }
        }

    }
}
