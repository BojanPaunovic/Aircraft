using System;

namespace ConsoleApp47
{
    public class Zaposleni
    {
        public static double cenaRada = 300;
        public string ime;

        public Zaposleni(string ime)
        {
            this.ime = ime;
        }

        public virtual void PlataZaposlenog()
        {
            double plata = cenaRada * 160;
            Console.WriteLine("Plata za " + ime + " iznosi:" + plata + " dinara");
        }
    }


    public class Sef : Zaposleni
    {
        public double koeficijent;
        public Sef(string ime, double koeficijent) : base(ime)
        {

            this.koeficijent = koeficijent;
        }
        public override void PlataZaposlenog()
        {
            double plata = cenaRada * 160 * koeficijent;
            Console.WriteLine("Plata za " + ime + " iznosi:" + plata + " dinara");
        }

    }

    public class Direktor : Sef
    {
        public double funkcionaliDodatak;


        public Direktor(string ime, double koeficijent, double funkcionaliDodatak) : base(ime,koeficijent)
        {
            this.koeficijent = koeficijent;
            this.funkcionaliDodatak = funkcionaliDodatak;

        }
        public override void PlataZaposlenog()
        {
            double plata = cenaRada * 160 * koeficijent + funkcionaliDodatak;
            Console.WriteLine("Plata za " + ime + " iznosi:" + plata + " dinara");
        }

        public class Sekretarica
        {
            public string ime;
            public Sekretarica(string ime)
            {
                this.ime = ime;

            }

            public void ispisiIme()
            {
                Console.WriteLine("Sekretarica se zove:" + ime);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {


            Zaposleni zap = new Zaposleni("Perica");
            Sef sef = new Sef("Novica", 1.2);
            Direktor direktor = new Direktor("Jovica", 2, 30000);
            Direktor.Sekretarica sekretarica = new Direktor.Sekretarica("Milica");
            zap.PlataZaposlenog();
            sef.PlataZaposlenog();
            direktor.PlataZaposlenog();
            sekretarica.ispisiIme();
        }
    }

}


