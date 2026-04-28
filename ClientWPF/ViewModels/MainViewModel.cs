using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ClientWPF.Helper;
using ClientWPF.Models;
using RussischeBauernMultiplikation;

namespace ClientWPF.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private readonly RelayCommand berechneCommand;

        private string zahlA = string.Empty;
        private string zahlB = string.Empty;
        private string ergebnis = "-";
        private string multiplikationsErgebnis = "-";
        private string errorMssg = string.Empty;

        public MainViewModel()
        {
            Rechenschritte = new ObservableCollection<Rechenschritt>();
            berechneCommand = new RelayCommand(Berechne, KannBerechnetWerden);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand BerechneCommand => berechneCommand;

        public ObservableCollection<Rechenschritt> Rechenschritte { get; }

        public string ZahlA
        {
            get => zahlA;
            set
            {
                if (SetProperty(ref zahlA, value))
                {
                    errorMssg = string.Empty;
                    OnPropertyChanged(nameof(ErrorMssg));
                    berechneCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string ZahlB
        {
            get => zahlB;
            set
            {
                if (SetProperty(ref zahlB, value))
                {
                    errorMssg = string.Empty;
                    OnPropertyChanged(nameof(ErrorMssg));
                    berechneCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Ergebnis
        {
            get => ergebnis;
            private set => SetProperty(ref ergebnis, value);
        }

        public string MultiplikationsErgebnis
        {
            get => multiplikationsErgebnis;
            private set => SetProperty(ref multiplikationsErgebnis, value);
        }

        public string ErrorMssg
        {
            get => errorMssg;
            private set => SetProperty(ref errorMssg, value);
        }

        private void Berechne()
        {
            if (!TryParseZahlen(out int a, out int b))
            {
                ErrorMssg = "Bitte gueltige ganze Zahlen eingeben.";
                SetzeLeereErgebnisse();
                return;
            }

            try
            {
                BauernMultiplikation.Rechenschritte.Clear();
                int? result = BauernMultiplikation.Mul(a, b);

                Ergebnis = result?.ToString() ?? "-";
                MultiplikationsErgebnis = (a * b).ToString();
                ErrorMssg = string.Empty;

                Rechenschritte.Clear();
                foreach (var schritt in BauernMultiplikation.Rechenschritte)
                {
                    bool addiert = schritt.A % 2 == 1;
                    Rechenschritte.Add(new Rechenschritt
                    {
                        A = schritt.A,
                        B = schritt.B,
                        IstUngerade = addiert ? "Ja" : "Nein",
                        WirdAddiert = addiert ? "Ja" : "Nein"
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorMssg = ex.Message;
                SetzeLeereErgebnisse();
            }
        }

        private bool KannBerechnetWerden()
        {
            if (!TryParseZahlen(out int a, out int b))
            {
                return false;
            }

            return BauernMultiplikation.KannBerechnetWerden(a, b);
        }

        private bool TryParseZahlen(out int a, out int b)
        {
            bool okA = int.TryParse(ZahlA?.Trim(), out a);
            bool okB = int.TryParse(ZahlB?.Trim(), out b);
            return okA && okB;
        }

        private void SetzeLeereErgebnisse()
        {
            Ergebnis = "-";
            MultiplikationsErgebnis = "-";
            Rechenschritte.Clear();
        }

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
