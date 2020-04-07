﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoMemoria
{
    class Tarjeta
    {
        String emojiOculto;
        String emojiRevelado;
        bool revelada;

        public Tarjeta(String emoji)
        {
            this.emojiOculto = emoji;
            this.emojiRevelado = emoji;
            this.revelada = false;
        }

        public String Emoji
        {
            get { return emojiRevelado; }
        }

        public void revelar()
        {
            if (!revelada)
            {
                this.emojiRevelado = emojiOculto.ToString();
                this.revelada = true;
            }
            else
            {
                this.emojiRevelado = "";
                this.revelada = false;
            }
        }

        public override string ToString()
        {
            return Emoji;
        }

        public static bool operator ==(Tarjeta a, Tarjeta b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Tarjeta a, Tarjeta b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Tarjeta)) return false;
            return (obj as Tarjeta).emojiOculto.Equals(this.emojiOculto);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}