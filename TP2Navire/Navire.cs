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
        

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.Imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
        }

        public Navire(string imo, string nom) : this(imo, nom, "Indéfini", 0) { }




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



        public override string ToString()
        {
            return "Identification  : " + this.imo + "\nNom :  " + this.nom + "\nType de frêt  : " + this.libelleFret + "\nQuantité de Frêt :" + this.qteFretMaxi;
        }
    }
}
