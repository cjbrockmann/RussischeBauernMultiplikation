using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientUIWpf.Helper;
using RussischeBauernMultiplikation;


namespace ClientUIWpf.VM
{

    /// <summary>
    /// Main.xaml ViewModel
    /// Diese Klasse wird mit dem Main.xaml verknüpft.... 
    /// </summary>
    class MainVM : INotifyPropertyChanged
    {

        #region Konstruktor
        public MainVM()
        {
            btnClick = new WpfKommando(MultipliziereNachRussischBauernMethode, KannBerechnetWerden);
            ErrorMssg = string.Empty;
            btnClick.Refresh();
            //ZahlA = int.MaxValue/2;
            //ZahlB = 2;
        }
        #endregion Konstruktor


        #region Properties
        //-----------------------------------------------------------------------------------------


        private WpfKommando btnClick;

        /// <summary>
        /// Hiermit wird ein Kommando vom Button ausgelöst
        /// </summary>
        public ICommand Berechne
        {
            get { return btnClick; }
        }

        private int? _a;
        public int? ZahlA
        {
            get { return _a; }
            set {
                _a = value;
                OnPropertyChanged("ZahlA");
                btnClick.Refresh();
                MultipliziereNachRussischBauernMethodeHelper();
            }
        }

        private int? _b;
        public int? ZahlB
        {
            get { return _b; }
            set {
                _b = value;
                OnPropertyChanged("ZahlB");
                btnClick.Refresh();
                MultipliziereNachRussischBauernMethodeHelper();
            }
        }


        private long? _ergebnis;
        public long? Ergebnis
        {
            get { return _ergebnis; }
            set { _ergebnis = value; OnPropertyChanged("Ergebnis");}
        }


        private long? _multiplikationsErgebnis;
        public long? MultiplikationsErgebnis
        {
            get { return _multiplikationsErgebnis; }
            set { _multiplikationsErgebnis = value; OnPropertyChanged("MultiplikationsErgebnis"); }
        }

        private string _errorMssg;

        public string ErrorMssg
        {
            get { return _errorMssg; }
            set { _errorMssg = value; OnPropertyChanged("ErrorMssg"); }
        }


        //-----------------------------------------------------------------------------------------
        #endregion Properties

        /// <summary>
        /// Berechne die Bauernmultiplikation und gebe Fehler aus, fall es zu einer Exception kommt. 
        /// </summary>
        /// <returns></returns>
        private long? MultipliziereNachRussischBauernMethodeHelper()
        {
            long? result;
            try
            {
                result = BauernMultiplikation.Mul(ZahlA, ZahlB);
                ErrorMssg = string.Empty;
            }
            catch (Exception e)
            {
                ErrorMssg = e.Message;
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Die Ergebnisse an die UI weitergeben...
        /// </summary>
        private void MultipliziereNachRussischBauernMethode()
        {
            Ergebnis = MultipliziereNachRussischBauernMethodeHelper();
            MultiplikationsErgebnis = ZahlA * ZahlB; 
        }

        /// <summary>
        /// Button aktivieren oder deaktivieren
        /// </summary>
        /// <returns></returns>
        private bool KannBerechnetWerden()
        {
            bool result = false;
            result = BauernMultiplikation.KannBerechnetWerden(ZahlA, ZahlB);
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
          
    }
}
