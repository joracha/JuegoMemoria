using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoMemoria
{
    // BY: https://github.com/egbakou/EmojisInXamarinForms
    class Emoji
    {
        readonly int[] codes;

        public Emoji(int[] codes)
        {
            this.codes = codes;
        }

        public Emoji(int code)
        {
            codes = new int[] { code };
        }

        public override string ToString()
        {
            if (codes == null)
                return string.Empty;

            var sb = new StringBuilder(codes.Length);

            foreach (var code in codes)
                sb.Append(Char.ConvertFromUtf32(code));

            return sb.ToString();
        }
    }

    public static class ListaEmojis
    {
        public static readonly String[] All = new String[]{
            new Emoji(0x1F600).ToString() , // 😀
            new Emoji(0x1F606).ToString() , // 😁
            new Emoji(0x1F605).ToString() , // 😅
            new Emoji(0x1F643).ToString() , // 🙃
            new Emoji(0x1F923).ToString() , // 🤣
            new Emoji(0x1F609).ToString() , // 😉
            new Emoji(0x1F607).ToString() , // 😇
            new Emoji(0x1F970).ToString() , // 🥰

            new Emoji(0x1F929).ToString() , // 🤩
            new Emoji(0x1F618).ToString() , // 😘
            new Emoji(0x1F60B).ToString() , // 😋
            new Emoji(0x1F911).ToString() , // 🤑
            new Emoji(0x1F61D).ToString() , // 😝
            new Emoji(0x1F92B).ToString() , // 🤫
            new Emoji(0x1F60F).ToString() , // 😏
            new Emoji(0x1F62C).ToString() , // 😬

            new Emoji(0x1F614).ToString() , // 😔
            new Emoji(0x1F634).ToString() , // 😴
            new Emoji(0x1F976).ToString() , // 🥶
        };
    }

}
