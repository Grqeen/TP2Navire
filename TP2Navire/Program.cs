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
                //port = new Port("Toulon");
                ////Instanciations();
                //try { TesterEnregistrerArrivee(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                //try { TesterEnregistrerArriveeV2(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                //try { TesterEnregistrerDepart(); }
                //catch (GestionPortException ex)
                //{ Console.WriteLine(ex.Message); }

                TesterInstanciationsStockage();

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
            unNavire = new Navire("IM09427639", "Copper Spirit", "Hydrocarbures", 156827 , 15);
            Affiche(unNavire);
            Console.WriteLine("--------------------------");

            // Declaration ET instantiation d'un autre objet de la classe Navire
            Navire unAutreNavire = new Navire("IM09839272", "MSC Isabella", "Porte-conteneurs", 197500 , 12);
            Affiche(unAutreNavire);
            Console.WriteLine("--------------------------");

            unAutreNavire = new Navire("IM08715871", "MSC PILAR");
            Affiche(unAutreNavire);
        }

        public static void Affiche(Navire navire)
        {
            Console.WriteLine(navire);
        }

        //public static void TesterEnregistrerDepart()
        //{
        //    Port port = new Port("Toulon");
        //    port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
        //    port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
        //    port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
        //    port.EnregistrerDepart("IMO8715871");
        //    Console.WriteLine("Départ du navire IMO8715871 enregistré");
        //    port.EnregistrerDepart("IMO1111111");
        //    Console.WriteLine("Départ du navire IMO1111111 enregistré");
        //    Console.WriteLine("fin des enregistrements des départs");
        //}

        public static void TesterEstPresent()
        {
            Port port = new Port("Toulon");
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827 , 6));
            port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500, 9));
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
                Navire navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827 , 7);
                navire = new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500 , 9);
                navire = new Navire("IMO8715871", "MSC PILAR");
                navire = new Navire("IMO9235232", " FORTUNE TRADER");
                navire = new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201 , 2);

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
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 8);
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827 ,9 );
                port.EnregistrerArrivee(navire);
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    

        private static void TesterEnregistrerArriveeV2()
        {
            Navire navire = null;
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500, 5));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerArrivee(new Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750 , 6 ));
                port.EnregistrerArrivee(new Navire("IMO9405423", "SERENEA", "Tanker", 158583, 7));
                port.EnregistrerArrivee(new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201 , 8));
                port.EnregistrerArrivee(new Navire("IMO9748681", "NORDIC SPACE", "Tanker", 157587, 9 ));
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException) 
            {
                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
            }
            

        }

        public static void TesterEnregistrerDepart()
        {
            try
            {
                port.EnregistrerDepart("IMO9427639");
                port.EnregistrerDepart("IMO9405423");
                port.EnregistrerDepart("IMO1111111");
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TesterInstanciationsStockage()
        {
            try
            { new Stockage(1, 15000); }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try 
            { new Stockage(2, 12000, 10000); }
            catch ( GestionPortException ex)
            { Console.WriteLine(ex.Message); }
            try
            { new Stockage(3, -25000, -10000); }
            catch (GestionPortException ex)
            { Console.WriteLine(ex.Message); }
            try
            { new Stockage(4, 15000, 20000); }
            catch(GestionPortException ex)
            { Console.WriteLine(ex.Message); }


            
        }

    }


}
