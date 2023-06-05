using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Partie;

namespace JeuPOM
{
    static class Utilitaire
    {
        public static void afficheHistorique(this Partie[] tableau, int compteur)
        {
            Console.WriteLine("Vos parties:");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine("Partie N°{0}, " + tableau[i].info(), i +
               1);
            }
        }
        public static void afficheHistorique(this Partie[] tableau, int compteur,
       string nomFichier)
        {
            try
            {
                FileStream fs = new FileStream(nomFichier, FileMode.Create,
               FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Vos parties:");
                for (int i = 0; i <= compteur; i++)
                {
                    sw.WriteLine("Partie N°{0}, " + tableau[i].info(), i
                   + 1);
                }
                sw.Close();
                fs.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur: " + e.Message);
            }
        }
    }
}
