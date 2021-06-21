using CSharpquarium_class;
using System;
using CSharpquarium_program.Models;


namespace CSharpquarium_program
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialisation et accueil
            Aquarium aquarium = new Aquarium();
            aquarium.AddTurnEvent += MethodeConsole.EatedlivingAction;
            aquarium.AddTurnEvent += MethodeConsole.AddturnAction;
            bool wantAdd = true;
            Console.WriteLine("Bonjour. Bienvenu à notre merveilleux Poisson2021 Simulator.Ajoutez votre premier poisson :"); 
            #endregion
            #region Ajout d'un poisson
            do
            {
                Console.WriteLine("Inscrivez son nom :");
                string nom = Console.ReadLine();

                bool isCorrect = false;
                FishSex fishSex = default;
                ushort age = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Inscrivez son sex (Male = 1 ou Femelle = 0.)");
                        fishSex = Enum.Parse<FishSex>(Console.ReadLine());
                        isCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Oups les informations données sont inexactes. Attention la majuscule est importante.");
                    }
                } while (isCorrect == false);
                do
                {
                    isCorrect = false;
                    try
                    {
                        Console.WriteLine($"Veuillez donnez un âge à votre poisson. Attention un poisson plus âgé que 20 meurt.");
                        age = (ushort)int.Parse(Console.ReadLine());
                        isCorrect = true;
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Oups les informations données sont inexactes. Veuillez entrer un nombre en dessous de 20.");
                    }
                } while (isCorrect == false);
                do
                {
                    isCorrect = false; 
                    try
                    {
                    Console.WriteLine($"Veuillez choisir l'espèce de votre poisson (Merou(0), Bar(1), Carpe(3), Poisson_clown(4), Sole(5) et Thon(6))");
                    aquarium.AddFish(nom, fishSex, age, Enum.Parse<Species>(Console.ReadLine()));
                        isCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Oups les informations données sont inexactes. Attention les majuscules sont importantes.");

                    }
                } while (isCorrect == false);

                Console.WriteLine("Voulez-vous ajouter un nouveau poisson ? oui/non");

                wantAdd = (Console.ReadLine().ToLower() != "non") ? true : false;
                Console.Clear();
            } while (wantAdd);
            #endregion
            #region Ajout d'une algue

            Console.WriteLine("Très bien. Combien d'algue voulez-vous ?");

            int nbAlgue;
            Int32.TryParse(Console.ReadLine(), out nbAlgue);
            while (nbAlgue > 0)
            {
                aquarium.AddSeaweed();
                nbAlgue--;
            }
            #endregion
            #region Début du jeu
            Console.Clear();
            Console.WriteLine("Bien ! Commençons ! Ce simulateur va vous montrer ce qui se passe dans votre aquarium");
            MethodeConsole.AddturnAction(aquarium);
            wantAdd = true;
            Console.WriteLine("Voulez-vous faire avancer l'aquarium d'un tour? oui/non");
            wantAdd = (Console.ReadLine().ToLower() != "non") ? true : false;
            Console.Clear();
            bool isEmpty = false;
            do
            {
                aquarium.AddTurn();
                Console.WriteLine("Voulez-vous faire avancer l'aquarium d'un tour ? oui/non");
                wantAdd = (Console.ReadLine().ToLower() != "non") ? true : false;
                Console.Clear();
                if (aquarium.listingfish.Count == 0){isEmpty = true;}
            } while (wantAdd && (isEmpty == false));
            #endregion
            #region Fin et remerciement
            if (isEmpty)
            {
                Console.WriteLine("Quel dommage ! Tous vos poissons sont morts ... ");
                MethodeConsole.AddturnAction(aquarium);
            }
            else {Console.WriteLine("Vous nous quittez déjà ! Merci d'avoir jouer ! A plus tard ..."); }
            
            Console.WriteLine("Appuyez sur n'importe quelle touche pour sortir.");
            Console.ReadLine();
            Console.Clear();
            #endregion
        }
    }
}
