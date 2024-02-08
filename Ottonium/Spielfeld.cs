using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ottonium
{
    public class Spielfeld
    {
        private const int REIHEN = 6;
        private const int SPALTEN = 6;
        private int[,] spielfeld = new int[REIHEN, SPALTEN];

        public Spielfeld()
        {
            
            Random rand = new Random();
            for (int i = 1; i < REIHEN; i++)
            {
                for (int j = 1; j < SPALTEN; j++)
                {
                    spielfeld[i, j] = rand.Next(2); 
                }
            }
        }

        public void KnopfDrücken(int zeile, int spalte)
        {
            
            Umschalten(zeile, spalte);
            Umschalten(zeile - 1, spalte); 
            Umschalten(zeile + 1, spalte); 
            Umschalten(zeile, spalte - 1); 
            Umschalten(zeile, spalte + 1); 
        }

        private void Umschalten(int zeile, int spalte)
        {
            if (zeile >= 0 && zeile < REIHEN && spalte >= 0 && spalte < SPALTEN)
            {
                spielfeld[zeile, spalte] = 1 - spielfeld[zeile, spalte]; 
            }
        }

        public bool IstGelöst()
        {
            
            for (int i = 1; i < REIHEN; i++)
            {
                for (int j = 1; j < SPALTEN; j++)
                {
                    if (spielfeld[i, j] == 1)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }

        public void SpielfeldAnzeigen()   
        {
            
            for (int i = 1; i < REIHEN; i++)
            {
                for (int j = 1; j < SPALTEN; j++)
                {
                    if (spielfeld[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan; 
                    }
                    Console.Write("O  "); 
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White; 
        }
    }
}
