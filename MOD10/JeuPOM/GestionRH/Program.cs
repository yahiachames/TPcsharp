using info;



namespace GestionRH
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employe e = new Employe("Martin", "Jean", "Paris", 35, "Technicien",
           2500.0);
            Console.WriteLine(e.getInfo());
            e.affectation("Technicien Senior");
            e.augmentation(500);
            Console.WriteLine(e.getInfo());
            using (Employe e2 = new Employe("Durand", "Michel", "Paris", 35,
           "Ingénieur", 3000.0))
            {
                Console.WriteLine(e2.getInfo());
            }

        }
    }
}