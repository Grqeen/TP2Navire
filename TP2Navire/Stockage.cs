using GestionNavire.Exceptions;

namespace GestionNavire.Classesmetier
{
    internal class Stockage
    {
        private readonly int numero;
        private int capaciteMaxi;
        private int capaciteDispo;

        public Stockage(int numero, int capaciteMaxi, int capaciteDispo)
        {
            this.numero = numero;
            this.CapaciteMaxi = capaciteMaxi;
            this.CapaciteDispo = capaciteDispo;
        }

        public Stockage(int numero, int capaciteMaxi) : this(numero, capaciteMaxi, capaciteMaxi) { }

        public int Numero { get => numero; }
        public int CapaciteMaxi
        {
            get => capaciteMaxi;
            private set
            {
                if (value > 0)
                {
                    capaciteMaxi = value;
                }
                else
                {
                    throw new GestionPortException("Impossible de créer un stockage avec une capacité négative");
                }
            }
        }
        public int CapaciteDispo
        {
            get => capaciteDispo;
            private set
            {
                if (value <= 0)
                {
                    throw new GestionPortException("La quantité à stocker dans un stockage ne peut être négative ");
                }
                else if (value > this.CapaciteMaxi)
                {
                    throw new GestionPortException("Impossible de stocker plus que la capacité disponible");

                }
                else
                {
                    //On peut stocker
                    this.capaciteDispo = value;
                }
            }


        }

        public void Stocker(int quantite)
        {
            if (quantite > 0)
            {
                this.capaciteDispo -= quantite;
            }
            else
            {
                throw new GestionPortException("La quantite à stocker dans un stockage ne peut être négative ou nulle");

            }

        }


    }
}
