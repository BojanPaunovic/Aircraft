using System;

namespace ConsoleApp44
{
    abstract class PrevoznoSredstvo
    {
        protected string proizvodjac;
        protected string tip;
        protected int godinaProizvodnje;

        abstract public void Ispis();
    }
    class Letelica:PrevoznoSredstvo
    {
        public Letelica(string proizvodjac, string tip, int godinaProizvodnje)
        {
            this.proizvodjac = proizvodjac;
            this.tip = tip;
            this.godinaProizvodnje = godinaProizvodnje;
        }

        public Letelica(string proizvodjac, string tip)
        {
            this.proizvodjac = proizvodjac;
            this.tip = tip;
            godinaProizvodnje = 0;
        }

        public string Proizvodjac
        {
            get { return proizvodjac; }
            set
            {
                string a = value;
                string b = a.ToUpper();
                if (b == "BOEING" || b == "AIRBUS")
                    proizvodjac = value;
                else Console.WriteLine("Greska! Uneli ste pogresno ime proizvodjaca.");
            }
        }
        override public void Ispis()
        {
            Console.WriteLine("Proizvodjac: " + proizvodjac);
            Console.WriteLine("Tip letelice: " + tip);
            Console.WriteLine("Godina proizvodnje: " + godinaProizvodnje);
        }
    }

    class Avion : Letelica
    {
        private int brojSedista;
        private int brojRedova;

        public Avion(string proizvodjac, string tip, int godinaProizvodnje, int brojSedista, int brojRedova) : base(proizvodjac, tip, godinaProizvodnje)
        {
            this.proizvodjac = proizvodjac;
            this.tip = tip;
            this.godinaProizvodnje = godinaProizvodnje;
            this.brojSedista = brojSedista;
            this.brojRedova = brojRedova;
        }

        public int BrojSedista
        {
            get { return brojSedista; }
            set { brojSedista = value; }
        }
        public int BrojRedova
        {
            get { return brojRedova; }
            set { brojRedova = value; }
        }
        public int UkupnoSedista()
        {
            return brojSedista;
        }

        public override void Ispis()
        {
            base.Ispis();
            Console.WriteLine("Ukupan broj sedista: " + brojSedista);
            Console.WriteLine("Ukupan broj redova: " + brojRedova);
        }



    }

    class AvionSpratni : Avion
    {
        public int brojSedistaPoRedu;
        public int brojRedovaNaSpratu;

        public AvionSpratni(string proizvodjac, string tip, int godinaProizvodnje, int brojSedista, int brojRedova, int brojSedistaPoRedu, int brojRedovaNaSpratu) : base(proizvodjac, tip, godinaProizvodnje, brojSedista, brojRedova)
        {
            this.brojSedistaPoRedu = brojSedistaPoRedu;
            this.brojRedovaNaSpratu = brojRedovaNaSpratu; //ne moramo za sve pisati, jer su iz osnovne klase
        }

        public int UkupnoSedista()
        {
            return BrojSedista + brojSedistaPoRedu * brojRedovaNaSpratu;
        }

        public override void Ispis()
        {
            base.Ispis();
            Console.WriteLine("Broj sedista po redu na spratu: " + brojSedistaPoRedu);
            Console.WriteLine("Broj redova na spratu: " + brojRedovaNaSpratu);
        }

        //ugnezdena klasa
        public class TovarniProstor
        {
            private double duzina;
            private double sirina;
            private double visina;

            public TovarniProstor(double duzina,double sirina,double visina)
            {
                this.duzina = duzina;
                this.sirina = sirina;
                this.visina = visina;
            }

            public double Zapremina()
            {
                return duzina * sirina * visina;
            }

        }
    }

    class Helikopter : Letelica
    {
        private bool spasilacki;

        public Helikopter(string proizvodjac, string tip, int godinaProizvodnje, bool spasilacki) : base(proizvodjac, tip, godinaProizvodnje)
        {
            this.proizvodjac = proizvodjac;
            this.tip = tip;
            this.godinaProizvodnje = godinaProizvodnje;
            this.spasilacki = spasilacki;
        }

        public bool Podoban()
        {
            if (spasilacki == true && godinaProizvodnje > 2000)
                return true;
            else return false;

        }

        public override void Ispis()
        {
            base.Ispis();
            if (spasilacki == true)
                Console.WriteLine("Helikopter je spasilacki.");
            else Console.WriteLine("Helikopter nije spasilacki.");
        }
    }

    class Program
    {
        static void Poruka(Letelica letelica1)
        {
            Console.WriteLine("Dobrodosli na aerodrom Nikola Tesla!\n");
            Console.WriteLine("Podaci o letelici:");
            letelica1.Ispis();
        }

        static void Main(string[] args)
        {
            Avion avion1 = new Avion("boeing", "Putnicki", 2001, 120, 12);
            Avion avion2 = new Avion("airbus", "Putnicki", 1999, 140, 16);

            avion1.Proizvodjac = "AIRBUS";
            avion2.Proizvodjac = "AIRBUS";

            avion1.Ispis();
            Console.WriteLine();
            avion2.Ispis();
            Console.WriteLine();

            Helikopter helikopter1 = new Helikopter("Tango", "Putnicki", 1995, true);
            Console.WriteLine("Prvi helikopter je podoban: " + helikopter1.Podoban());
            Console.WriteLine();

            Helikopter helikopter2 = new Helikopter("Tango", "Vojni", 2010, true);
            Console.WriteLine("Drugi helikopter je podoban: " + helikopter1.Podoban());
            Console.WriteLine();

            Poruka(avion1);
            Console.WriteLine();
            Poruka(helikopter1);

            AvionSpratni avioncic = new AvionSpratni("Boeing", "Putnicki", 2007, 50, 20, 60, 20);
            Poruka(avioncic);
            Console.WriteLine("Ukupan broj sedista u spratnom avionu: " + avioncic.UkupnoSedista());

            AvionSpratni.TovarniProstor objekat = new AvionSpratni.TovarniProstor(20, 20, 7);
            Console.WriteLine("Zapremina tovarnog prostora: " + objekat.Zapremina());
        }
    }
}
