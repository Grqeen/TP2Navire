using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionNavire.Classesmetier
{
    class Port
    {
        private readonly string nom;
        private int nbNaviresMax = 5;
        private Dictionary<string, Navire> navires;
        private List<Stockage> stockages;

        //constructeur
        public Port(string nom)
        {
            this.nom = nom;
            navires = new Dictionary<string, Navire>();
            this.stockages = new List<Stockage>();
        }

        internal Dictionary<string, Navire> Navires { get => navires; }

        // Methods
        public void EnregistrerArrivee(Navire navire)
        {
            try
            {
                if (this.navires.Count < this.nbNaviresMax)
                {
                    this.navires.Add(navire.Imo, navire);//add verifie dans le dictionary si le meme navire existe deja
                }
                else
                {
                    throw new GestionPortException("Ajout impossible, le port est complet");
                }
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
            }

        }


        public void EnregistrerDepart(String imo)
        {
            bool index = EstPresent(imo);
            if (index)
            {
                // le navire est présent dans le port
                this.navires.Remove(imo);
            }
            else
            {
                // le navire n'est pas dans le port
                throw new GestionPortException("impossible d'enregistrer le départ du navire " + imo + ", il n'est pas dans le port ");
            }
        }




        /// <summary>
        ///  première version qui sera remplacée par EstPresent
        /// </summary>
        /// <param name="imo"></param>
        /// <returns></returns>
        public bool EstPresent(String imo)
        {
            return this.navires.ContainsKey(imo);
        }

        public void Dechargement(String imo)
        {
            Navire navire = GetNavire(imo);
            bool index = EstPresent(imo);
            if (!index)
            {
                throw new GestionPortException("Impossible , Le navire n'est pas dans le port");
            }
            else if (navire.LibelleFret != "Porte-conteneurs")
            {
                throw new GestionPortException("Ce type de Navire ne peut être déchargé dans les zones de stockage");
            }
            else
            {
                int i = 0;
                while (navire.QteFret != 0)
                {
                    navire.Decharger(this.stockages[i].CapaciteDispo);
                    navire.Decharger(navire.QteFret);
                }
            }

        }

        public void AjoutStockage(Stockage stockage)
        {
            stockages.Add(stockage);
        }

        public Navire GetNavire(String imo)
        {
            if (navires.ContainsKey(imo))
            {
                return navires[imo];
            }
            else
            {
                return null;
            }
        }




    }



}
