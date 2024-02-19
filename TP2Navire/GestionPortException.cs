using System;

namespace GestionNavire.Exceptions
{
    class GestionPortException
    {
        public GestionPortException(string message)
           : base("Erreur de : " + Environment.UserName + " le " + DateTime.Now.ToLocalTime() +
                "\n" + message) {}
        
    }
}
