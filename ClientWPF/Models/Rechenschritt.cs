namespace ClientWPF.Models
{
    public sealed class Rechenschritt
    {
        public int A { get; set; }

        public int B { get; set; }

        public string IstUngerade { get; set; } = string.Empty;

        public string WirdAddiert { get; set; } = string.Empty;
    }
}
