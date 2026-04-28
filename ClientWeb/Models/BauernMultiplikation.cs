using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RussischeBauernMultiplikation;

namespace ClientWeb.Models
{
    public class RechenschrittModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public string IstUngerade { get; set; }
        public string WirdAddiert { get; set; }
    }

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
        public string ErrorMessage { get; set; }
        public List<RechenschrittModel> Rechenschritte { get; set; }
        public KommunikationsModel()
        {
            KannBerechnetWerden = true;
            ZahlA = 0;
            ZahlB = 0;
            Ergebnis = 0;
            MultiplikationsErgebnis = 0;
            ErrorMessage = string.Empty;
            Rechenschritte = new List<RechenschrittModel>();
        }


    }

    /// <summary>
    /// Mit dieser Klasse wird zum Berechnen innerhalb des Kontrollers verwendet 
    /// </summary>
    public class MultiplikationModel : KommunikationsModel
    {
        public void Mult()
        {
            Rechenschritte.Clear();
            ErrorMessage = string.Empty;

            try
            {
                KannBerechnetWerden = BauernMultiplikation.KannBerechnetWerden(ZahlA, ZahlB);
                BauernMultiplikation.Rechenschritte.Clear();
                Ergebnis = BauernMultiplikation.Mul(ZahlA, ZahlB);
                MultiplikationsErgebnis = ZahlA * ZahlB;

                Rechenschritte = BauernMultiplikation.Rechenschritte
                    .Select(s => new RechenschrittModel
                    {
                        A = s.A,
                        B = s.B,
                        IstUngerade = s.A % 2 == 1 ? "Ja" : "Nein",
                        WirdAddiert = s.A % 2 == 1 ? "Ja" : "Nein"
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Ergebnis = null;
                MultiplikationsErgebnis = null;
                KannBerechnetWerden = false;
                Rechenschritte = new List<RechenschrittModel>();
            }

        }
    }
}

