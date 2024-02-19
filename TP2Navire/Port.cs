using System;
using System.Collections.Generic;

namespace GestionNavire.Classesmetier
{
    class Port
    {
        private readonly string nom;
        private int nbNaviresMax = 5;
        private Dictionary<string, Navire> navires;

        //constructeur
        public Port(string nom)
        {
            this.nom = nom;
            navires = new Dictionary<string, Navire>();
        }

        internal Dictionary<string, Navire> Navires { get => navires; }

        // Methods
        public void EnregistrerArrivee(Navire navire)
        {
            if (this.navires.Count < this.nbNaviresMax && !this.navires.ContainsValue(navire))
            {
                this.navires.Add(navire.Imo, navire);
            }
            else
            {
                throw new Exception("Ajout impossible, le port est complet");
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
                throw new Exception("impossible d'enregistrer le départ du navire " + imo + ", il n'est pas dans le port ");
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



    }



}
