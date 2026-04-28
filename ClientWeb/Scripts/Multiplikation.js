var Multiplikation = /** @class */ (function () {
    function Multiplikation() {
        this.ZahlA = null;
        this.ZahlB = null;
        this.Ergebnis = null;
        this.MultiplikationsErgebnis = null;
        this.KannBerechnetWerden = true;
        this.ErrorMessage = "";
        this.Rechenschritte = [];
    }
    return Multiplikation;
}());
var Rechenschritt = /** @class */ (function () {
    function Rechenschritt() {
        this.A = null;
        this.B = null;
        this.IstUngerade = "";
        this.WirdAddiert = "";
    }
    return Rechenschritt;
}());
//# sourceMappingURL=Multiplikation.js.map