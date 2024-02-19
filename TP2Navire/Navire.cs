﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Navire.Classesmetier
{
    
    internal class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.imo = imo;
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.qteFretMaxi = qteFretMaxi;
        }

        public Navire(string imo, string nom):this (imo, nom, "Indéfini", 0) { }
                   
            
        

        public string Imo { get => imo; set => imo = value; }
        public string Nom { get => nom; set => nom = value; }
        public string LibelleFret { get => libelleFret; set => libelleFret = value; }
        public int QteFretMaxi { get => qteFretMaxi; set => qteFretMaxi = value; }

        public override string ToString()
        {
            return "Identification  : " + this.imo + "\nNom :  " + this.nom + "\nType de frêt  : " + this.libelleFret + "\nQuantité de Frêt :" + this.qteFretMaxi;
        }
    }
}
