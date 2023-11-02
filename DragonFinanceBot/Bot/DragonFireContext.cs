using DragonFinanceBot.AsciiArts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Bot
{
    public class DragonFireContext
    {
        //vamos chamar os nossos
        //frames aqui

        public static void GenerateAnimation()
        {
            //laço de 1 a 7
            //são 7 frames
            for(int i = 1; i <= 7; i++)
            {
                //Passo cada frame
                //que quero exibir
                PrintFrame(i);
            }
            //aqui chamo o menu
            //outra vez
            Menu.ShowMenu();
        }
        //Aqui crio a ação de
        //exibir os frames
        public static void PrintFrame(int frame)
        {
            //tempo é 1 segundo
            var time = 1000;
            //se for o frame 7
            //do game over é 3 seg
            if(frame == 7)
            {
                time = 3000;
            }

            //Chamo cada frame
            Console.WriteLine(Dragon.FireBallFrames(frame));
            //espero o tempo
            //configurado
            Thread.Sleep(time);
            //Limpo o console
            Console.Clear();
        }
    }
}
