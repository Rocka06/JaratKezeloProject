namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private List<Jarat> jaratok;

        public JaratKezelo()
        {
            jaratok = new();
        }

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.Exists(x => x.JaratSzam == jaratSzam ))
            {
                throw new ArgumentException("A járat már létezik!");
            }

            jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas, 0));
        }

        public void Keses(string jaratSzam, int keses)
        {
            Jarat jarat = JaratLetezik(jaratSzam) ?? throw new ArgumentException("A járat nem létezik!");
        
            if(keses < 0)
            {
                if(jarat.Keses + keses < 0) throw new NegativKesesException();
            }

            jarat.Keses += keses;
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            Jarat jarat = JaratLetezik(jaratSzam) ?? throw new ArgumentException("A járat nem létezik!");
            return jarat.Indulas.AddMinutes(jarat.Keses);
        }

        public List<Jarat> JaratokRepuloterrol(string repter)
        {
            List<Jarat> jaratLista = new();

            foreach(Jarat jarat in jaratok)
            {
                if(jarat.HonnanRepter == repter) jaratLista.Add(jarat);
            }

            return jaratLista;
        }

        private Jarat? JaratLetezik(string jaratSzam)
        {
            Jarat? jarat = jaratok.Find(x => x.JaratSzam == jaratSzam) ?? null;
            return jarat;
        }
    }
}
