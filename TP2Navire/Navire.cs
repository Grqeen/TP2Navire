using GestionNavire.Exceptions;
using System.Text.RegularExpressions;

namespace GestionNavire.Classesmetier
{

    internal class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;
        private int qteFret;
        

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi, int qteFret)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
            this.QteFret = qteFret;
        }

        public Navire(string imo, string nom) : this(imo, nom, "Indéfini", 0, 0) { }




        public string Imo
        {
            get => imo;
            private set
            {
                if (Regex.IsMatch(value, @"^[I][M][O][1-9]\d{6}$"))
                {
                    this.imo = value;
                }
                else
                {
                    throw new GestionPortException("erreur : IMO non valide");
                }

            }
        }

        public string Nom { get => nom; set => nom = value; }
        public string LibelleFret { get => libelleFret; set => libelleFret = value; }
        public int QteFretMaxi
        {

            get => qteFretMaxi;
            set
            {
                if (value >= 0)
                {
                    this.qteFretMaxi = value;
                }
                else
                {
                    throw new GestionPortException("Erreur, quantité de fret non valide");
                }
            }
        }
        public int QteFret 
        {
            
            get => qteFret; 
            private set
            {
                if(value >= 0 && value <= qteFretMaxi)
                {
                    this.qteFret = value;
                }
                else
                {
                    throw new GestionPortException("Valeur incohérente pour la quantite de fret stockée dans le navire  ");
                }
            }


        
        
        }



        public override string ToString()
        {
            return "Identification  : " + this.imo + "\nNom :  " + this.nom + "\nType de frêt  : " + this.libelleFret + "\nQuantité de Frêt :" + this.qteFretMaxi;
        }

        public void Decharger(int quantite)
        {
            if (quantite < 0)
            {
                throw new GestionPortException("la quantité à décharger ne peux être négative ou nulle");
            }
            else if (quantite > this.QteFretMaxi)
            {
                throw new GestionPortException("Impossible de decharger plus que la quantité de fret dans le navire");
            }
            else
            {
                this.qteFret -= quantite;
            }

        }

        public bool EstDecharge()
        {
            return this.qteFret == 0;
        }
    }
}
