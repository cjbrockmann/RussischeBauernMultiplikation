class Multiplikation {
    ZahlA : number = null;
    ZahlB : number = null;
    Ergebnis: number = null;
    MultiplikationsErgebnis: number = null;
    KannBerechnetWerden: boolean = true;  
    ErrorMessage: string = "";
    Rechenschritte: Rechenschritt[] = [];
}

class Rechenschritt {
    A: number = null;
    B: number = null;
    IstUngerade: string = "";
    WirdAddiert: string = "";
}