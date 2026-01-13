using System;

namespace DomowaApteczka.Models
{
    public class LekBezRecepty : Lek
    {
        public LekBezRecepty(string nazwa, DateTime dataWaznosci)
            : base(nazwa, dataWaznosci)
        {
        }

        public override string Typ()
        {
            return "Bez recepty";
        }
    }
}