using GestionNavire.Classesmetier;
using GestionNavire.Exceptions;
using System;

namespace GestionNavire.Application
{
    class Program

    {
        private static Port port;
        static void Main(string[] args)
        {
            try
            {
                //TesterInstanciations();
                //TesterEnregistrerArrivee();          
                //TesterEnregistrerDepart();
                //TesterEstPresent();
                port = new Port("Toulon");
                //Instanciations();
                TesterEnregistrerArrivee();
                Console.WriteLine("Fin normale du programme");
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }


        }

        public static void TesterInstanciations()
        {
            // declaration de l'objet unNavire de la classe Navire
            Navire unNavire;
            // Instantiation de l'objet
            unNavire = new Navire("IM09427639", "Copper Spirit", "Hydrocarbures", 156827);
            Affiche(unNavire);
            Console.WriteLine("--------------------------");

            // Declaration ET instantiation d'un autre objet de la classe Navire
            Navire unAutreNavire = new Navire("IM09839272", "MSC Isabella", "Porte-conteneurs", 197500);
            Affiche(unAutreNavire);
            Console.WriteLine("--------------------------");

            unAutreNavire = new Navire("IM08715871", "MSC PILAR");
            Affiche(unAutreNavire);
        }

        public static void Affiche(Navire navire)
        {
            Console.WriteLine(navire);
        }

        //public static void TesterEnregistrerArrivee()
        //{
        //    Port port = new Port("Toulon");
        //    port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneur", 5));
        //    port.EnregistrerArrivee(new Navire("IMO9839273", "Bateau 1", "Type bateau 1", 6));
        //    port.EnregistrerArrivee(new Navire("IMO9839274", "Bateau 2 ", "Type bateau 2", 7));
        //    //port.EnregistrerArrivee(new Navire("IMO9839275", "Bateau 3 ", "Type bateau 3", 8));
        //    //port.EnregistrerArrivee(new Navire("IMO9839276", "Bateau 4 ", "Type bateau 4", 9));
        //    //port.EnregistrerArrivee(new Navire("IMO9839277", "Bateau 5 ", "Type bateau 5", 10));

        //    Console.WriteLine("Navires bien enregistrés dans le port");
        //}

        //public static void TesterRecupPosition()
        //{
        //    (new Classesmetier.Port("Toulon")).TesterRecupPosition();
        //}

        //public static void TesterRecupPositionV2()
        //{
        //    (new Classesmetier.Port("Toulon")).TesterRecupPositionV2();
        //}

        public static void TesterEnregistrerDepart()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            port.EnregistrerDepart("IMO8715871");
            Console.WriteLine("Départ du navire IMO8715871 enregistré");
            port.EnregistrerDepart("IMO1111111");
            Console.WriteLine("Départ du navire IMO1111111 enregistré");
            Console.WriteLine("fin des enregistrements des départs");
        }

        public static void TesterEstPresent()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
            port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            String imo = "IMO9427639";
            Console.WriteLine("Le navire " + imo + " est présent dans le port : " + port.EstPresent(imo));
            imo = "IMO1111111";
            Console.WriteLine("Le navire " + imo + " est présent dans le port : " + port.EstPresent(imo));
        }

        private static void Instanciations()
        {
            try
            {
                Navire navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                navire = new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500);
                navire = new Navire("XMO8715871", "MSC PILAR");
                navire = new Navire("IMO9235232", " FORTUNE TRADER");
                navire = new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201);

            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }

        private static void TesterEnregistrerArrivee()
        {
            Navire navire = null;
            try
            {
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArrivee(navire);
            }
            catch(GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
