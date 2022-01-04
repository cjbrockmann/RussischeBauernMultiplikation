using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RussischeBauernMultiplikation;

namespace ClientWeb.Models
{

    /// <summary>
    /// Diese Klasse dient zur Kommunikation mit dem WebFrontend 
    /// </summary>
    public class KommunikationsModel
    {
        public int? ZahlA { get; set; }
        public int? ZahlB { get; set; }
        public long? Ergebnis { get; set; }
        public long? MultiplikationsErgebnis { get; set; }
        public bool KannBerechnetWerden { get; set; }
        public KommunikationsModel()
        {
            KannBerechnetWerden = true;
            ZahlA = 0;
            ZahlB = 0;
            Ergebnis = 0;
            MultiplikationsErgebnis = 0;
        }


    }

    /// <summary>
    /// Mit dieser Klasse wird zum Berechnen innerhalb des Kontrollers verwendet 
    /// </summary>
    public class MultiplikationModel : KommunikationsModel
    {


        public void Mult()
        {
            KannBerechnetWerden = BauernMultiplikation.KannBerechnetWerden(this.ZahlA, this.ZahlB);
            this.Ergebnis = BauernMultiplikation.Mul(this.ZahlA, this.ZahlB);
            this.MultiplikationsErgebnis = this.ZahlA * this.ZahlB;

        }
    }
}

