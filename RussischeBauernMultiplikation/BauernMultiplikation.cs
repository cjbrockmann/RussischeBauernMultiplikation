using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussischeBauernMultiplikation
{
    /// <summary>
    /// Diese Klasse stellt die Methode der russischen Bauernmultiplikation zur Verfügung. 
    /// </summary>
    public static class BauernMultiplikation
    {
        /// <summary>
        /// Russische Bauernmultiplikation
        /// Der erste Faktor wird durch zwei geteilt, bis er eins wird. 
        /// Der zweite Faktor wird mal zwei multipliziert, so oft wie der erste Faktor behandelt wird.
        /// Vor jeder Operation wird überprüft, ob die erste Zahl ungerade ist, 
        /// und wenn das zutrifft, wird die zweite Zahl zum Endergebnis hinzu addiert.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int? Mul(int? a, int? b)
        {
            int? result  = null;
            int? prevB = b;

            string fehler = EingabeFehlerMeldung(a, b); 
            if (!string.IsNullOrEmpty(fehler))
            {
                if (fehler.Contains("Überlauf"))
                    throw new OverflowException(fehler);
                else 
                    throw new InvalidOperationException(fehler);
            }

            result = 0;
            while (a > 0)
            {
                if (a % 2 == 1)
                {
                    OverflowCheck(result + b);
                    result = checked(result + b);
                }
                if (a == 1 ) { a = 0; }
                else {
                    OverflowCheck(b * 2);
                    a = a / 2;
                    b = checked(b * 2);
                }
            }

            return result;
        }

        /// <summary>
        /// Überprüft, ob ein Überlauf stattfindet. 
        /// Und wenn ja, löse einen Fehler aus.
        /// </summary>
        /// <param name="value"></param>
        private static void OverflowCheck(long? value) {
            if (value > int.MaxValue) throw new OverflowException("Überlauf bei der Berechnung!");
            try
            {
                var c = checked(value);
            }
            catch (Exception e)
            {
                throw new OverflowException("Überlauf bei der Berechnung!");
            }
        }

        /// <summary>
        /// Warnmeldung ausgeben, falls ein Eingabefehler stattfinden würde. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static string EingabeFehlerMeldung(int? a, int? b)
        {
            string result = string.Empty;
            if (!a.HasValue && !b.HasValue) return "Bitte Werte eingeben!";
            if (!a.HasValue) return "Bitte erste Zahl eingeben!";
            if (!b.HasValue) return "Bitte zweite Zahl eingeben!";
            if (a < 0 || b < 0) return "Bitte Zahlen größer gleich null eingeben! ";
            try
            {
                var c = checked(a * b);
            }
            catch (Exception e)
            {
                return "Überlauffehler beim Produkt!";
            }
            return result; 
        }



        /// <summary>
        /// Gibt an, ob die Berechnung durchgeführt werden kann.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool KannBerechnetWerden(int? a, int? b)
        {
            bool result = true;
            if (!a.HasValue) result = false;
            if (!b.HasValue) result = false;
            if (a < 0 || b < 0) result = false;
            try
            {
                var c = checked(a * b);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result; 
        }


        /// <summary>
        /// Funktion, um die korrekte Rundung zwischen Ganzzahlen zu testen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int DivideHelper(int a, int b)
        {
            return a / b;
        }



    }
}
