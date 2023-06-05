using System.IO;

int valeurSecrete, valuerSaisie = -1,nbTentative=0,meilleurScore = 50,nbParties = 0;
string reponse;
int[] historiqueValeur = new int[20], historiqueTentative = new int[20];
Random rnd = new Random();
valeurSecrete = rnd.Next(100);
string nom_du_fichier = "";
do
{
    nbTentative = 0;
    do
    {
        try {
            nom_du_fichier = "";
        nbTentative++;
        valuerSaisie = getEntier("saisir un nombre");
       
        }catch(Exception e) {  Console.WriteLine(e.Message); }

        if (valuerSaisie == valeurSecrete)
        {
            Console.WriteLine("vous avez gagner");
            Console.WriteLine("saisir le nom du fichier comprte votre historique de jeu");
          nom_du_fichier = Console.ReadLine();
        }
        else if (valuerSaisie > valeurSecrete)
        {
            Console.WriteLine("tres grande");
        }
        else if (valuerSaisie < valeurSecrete)
        {
            Console.WriteLine("tres petite");
        }
    } while (valuerSaisie != valeurSecrete);
    nbParties++;
    historiqueValeur[nbParties] = valeurSecrete;
historiqueTentative[nbParties] = nbTentative;
if (meilleurScore < nbTentative)
    {
        Console.WriteLine("vous n'avez pas réussi a battre le meilleur score avec nombre de tentatives est egal a {0}", nbTentative);
        

    }
    else
    {
        Console.WriteLine("vous avez réussi de battre le meilleur score avec nombre de tentatives est egal a {0}", nbTentative);
        meilleurScore = nbTentative;
    }

    reponse = getString("vous voulez rejouer ? repondre par oui ou non");
    valeurSecrete = rnd.Next(100);
} while (reponse == "oui");

afficheHistorique(nbParties, historiqueValeur, historiqueTentative, nom_du_fichier);

static  void  afficheHistorique(int compteur , int[] tabValeur , int[] tabCoup, string nomFichier)
{
    try
    {
        FileStream fs = new FileStream(nomFichier, FileMode.CreateNew,
             FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("Vos parties:");

        for (int i = 0; i <= compteur; i++)
        {
            sw.WriteLine("Partie N°{0}, valeur secrète={1}," +
           "trouvé en {2} coup(s).", i + 1, tabValeur[i], tabCoup[i]);
        }
        sw.Close();
        fs.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine("Erreur: " + e.Message);
    }

}

static string getString(string message)
{
    string chaine = "";
    Console.WriteLine(message);
    chaine = Console.ReadLine();
    return chaine;
}

static int getEntier(string message)
{
    string chaine = "";
    int sortie;
    Console.WriteLine(message);
    chaine = Console.ReadLine();

        sortie = int.Parse(chaine);
        
    
  

       

    if (!int.TryParse(chaine, out sortie))
        sortie = -1;
    return sortie;
}

 
