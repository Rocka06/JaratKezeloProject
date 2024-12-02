using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class Tests
    {
        JaratKezelo jaratKezelo;
        [SetUp]
        public void Setup()
        {
            jaratKezelo = new JaratKezelo();
        }

        [Test]
        public void UjJarat_HelyesAdatokkal()
        {
            Assert.DoesNotThrow(() => {
                jaratKezelo.UjJarat("1234", "Innen", "Oda", DateTime.Now);
            });
        }

        [Test]
        public void UjJarat_LetezoSzammal()
        {
            jaratKezelo.UjJarat("1234", "Innen", "Oda", DateTime.Now);
            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.UjJarat("1234", "Innen", "Máshova", DateTime.Now);
            });
        }

        [Test]
        public void UjJarat_VanEKeses()
        {
            DateTime indulas = DateTime.Now;
            jaratKezelo.UjJarat("1234", "Innen", "Oda", indulas);

            Assert.That(indulas == jaratKezelo.MikorIndul("1234"));
        }

        [Test]
        public void MikorIndul_HelyesAdatokkal()
        {
            DateTime indulas = DateTime.Now;
            jaratKezelo.UjJarat("1234", "Innen", "Oda", indulas);

            Assert.That(indulas == jaratKezelo.MikorIndul("1234"));
        }

        [Test]
        public void MikorIndul_NemLetezoJarat()
        {
            Assert.Throws<ArgumentException>(() => { jaratKezelo.MikorIndul("1234"); });
        }

        [Test]
        public void Keses_HelyesAdatokkal_Pozitiv_NemDobKivetelt()
        {
            jaratKezelo.UjJarat("1234", "Innen", "Oda", DateTime.Now);
            Assert.DoesNotThrow(() => { jaratKezelo.Keses("1234", 10); });
        }

        [Test]
        public void Keses_HelyesAdatokkal_Negativ_NemDobKivetelt()
        {
            jaratKezelo.UjJarat("1234", "Innen", "Oda", DateTime.Now);
            jaratKezelo.Keses("1234", 10);
            Assert.DoesNotThrow(() => { jaratKezelo.Keses("1234", -10); });
        }

        [Test]
        public void Keses_HelyesAdatokkal_Pozitiv()
        {
            DateTime indulas = DateTime.Now;
            jaratKezelo.UjJarat("1234", "Innen", "Oda", indulas);
            jaratKezelo.Keses("1234", 10);
            Assert.That(indulas != jaratKezelo.MikorIndul("1234"));
        }

        [Test]
        public void Keses_HelyesAdatokkal_Negativ()
        {
            DateTime indulas = DateTime.Now;
            jaratKezelo.UjJarat("1234", "Innen", "Oda", indulas);
            jaratKezelo.Keses("1234", 10);
            jaratKezelo.Keses("1234", -10);
            Assert.That(indulas == jaratKezelo.MikorIndul("1234"));
        }

        [Test]
        public void Keses_NegativKesesException()
        {
            jaratKezelo.UjJarat("1234", "Innen", "Oda", DateTime.Now);
            Assert.Throws<NegativKesesException>(() => { jaratKezelo.Keses("1234", -10); });
        }

        [Test]
        public void Keses_NemLetezoJarat()
        {
            Assert.Throws<ArgumentException>(() => { jaratKezelo.Keses("1234", -10); });
        }

    }
}