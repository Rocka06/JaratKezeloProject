namespace JaratKezeloProject
{
    public class Jarat
    {
        public string JaratSzam {  get; set; }
        public string HonnanRepter { get; set; }
        public string HovaRepter { get; set; }
        public DateTime Indulas { get; set; }
        public int Keses { get; set; }

        public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas, int keses)
        {
            JaratSzam = jaratSzam;
            HonnanRepter = honnanRepter;
            HovaRepter = hovaRepter;
            Indulas = indulas;
            Keses = keses;
        }
    }
    public class NegativKesesException : Exception
    {
        public NegativKesesException()
        {
        }

        public NegativKesesException(string message)
            : base(message)
        {
        }
    }
}
