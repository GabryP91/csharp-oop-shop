/*
 
creare la classe Prodotto che gestisce i prodotti dello shop.
Un prodotto è caratterizzato da:
- codice (numero intero)
- nome
- descrizione
- prezzo
- iva
Usate opportunamente i livelli di accesso (public, private), i costruttori, i metodi getter e setter ed eventuali altri metodi di “utilità” per fare in modo che:
alla creazione di un nuovo prodotto il codice sia valorizzato con un numero random
Il codice prodotto sia accessibile solo in lettura
Gli altri attributi siano accessibili sia in lettura che in scrittura
Il prodotto esponga sia un metodo per avere il prezzo base che uno per avere il prezzo comprensivo di iva
Il prodotto esponga un metodo per avere il nome esteso, ottenuto concatenando codice + nome
Testate poi i vostri oggetti Prodotto, istanziandoli e provando ad interargirci per testare tutti i metodi che avete previsto.

BONUS:
- create un metodo che restituisca il codice con un pad left di 0 per arrivare a 8 caratteri (ad esempio codice 91 diventa 00000091, mentre codice 123445567 resta come è)
- Usando un array, dichiarate un elenco dei prodotti di un negozio e inseriteci al suo interno qualche prodotto che vi aspettate di trovare nel negozio. Stampate poi l’elenco dei vostri prodotti che avete previsto nel negozio.

 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_oop_shop
{

    //classe prodotto
    public class Prodotto
    {
        //variabile codice privata
        private int codice;

        //Dichiaro un metodo per la sola lettura della variabile codice (properties)
        public int Codice => codice;

        //Funzione per la lettura e scrittura della variabile (properties)
        public string Nome { get; set; }

        //Funzione per la lettura e scrittura della variabile (properties)
        public string Descrizione { get; set; }

        //Funzione per la lettura e scrittura della variabile (properties)
        public decimal Prezzo { get; set; }

        //Funzione per la lettura e scrittura della variabile (properties)
        public decimal Iva { get; set; }

        //costruttore
        public Prodotto(string nome, string descrizione, decimal prezzo, decimal iva) 
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Iva = iva;
            //assegno alla varaibile codice l'intero passato dal metodo privato GeneraCodice()
            this.codice = GeneraCodice();
        }

        //METODI

        private int GeneraCodice()
        {
            Random rnd = new Random();
            return rnd.Next(10000000); // Numero casuale a 8 cifre
        }

        //metodo che restituisce il prezzo base in decimale
        public decimal PrezzoBase()
        {
            return this.Prezzo;
        }

        //metodo che restituisce il prezzo base + IVA in decimale
        public decimal PrezzoConIVA()
        {
            return this.Prezzo + (this.Prezzo * this.Iva / 100);
        }

        //metodo che restituisce il codice + nome
        public string NomeEsteso()
        {
            return this.Codice.ToString("D8") + this.Nome;
        }

        public string CodiceFormat()
        {
            return this.Codice.ToString("D8");
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //per l'icona euro su console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Creazione di un prodotto
            Prodotto prodotto1 = new Prodotto("Penne", "Scatola di penne nere", 2.5m, 22);

            // Test dei metodi
            Console.WriteLine("Codice: " + prodotto1.CodiceFormat());
            Console.WriteLine("Nome: " + prodotto1.Nome);
            Console.WriteLine("Descrizione: " + prodotto1.Descrizione);
            Console.WriteLine("Prezzo base: " + prodotto1.PrezzoBase() + " \u20AC");
            Console.WriteLine("Prezzo con IVA: " + prodotto1.PrezzoConIVA() + " \u20AC");
            Console.WriteLine("Nome esteso: " + prodotto1.NomeEsteso());


            Console.WriteLine("\n\n****CREAZIONE SINGOLI PRODOTTI*****");

            int TotProd;

            Console.WriteLine("\nQuanti prodotti vuoi inserire?:");
            //controllo sull'input dell'utente, se quello che è stato digitato non è un numero darà errore
            while (int.TryParse(Console.ReadLine(), out TotProd) == false)
            {
                Console.WriteLine("Sintassi errata. Inserisci numero");
            }


            string nome, descrizione;

            decimal prezzo, iva;

            //creo un array di prodotti
            Prodotto[] listaProdotti = Population(TotProd);

            for (int i= 0; i< listaProdotti.Length; i++)
            {
                Console.WriteLine($"\nInserisci nome {i+1} prodotto:");
                nome = Console.ReadLine();

                Console.WriteLine($"\nInserisci descrizione {i+1} prodotto:");
                descrizione = Console.ReadLine();

                Console.WriteLine($"\nInserisci il prezzo del {i + 1} prodotto:");
                //controllo sull'input dell'utente, se quello che è stato digitato non è un numero darà errore
                while (decimal.TryParse(Console.ReadLine(), out prezzo) == false)
                {
                    Console.WriteLine("Sintassi errata. Inserisci numero");
                }

                Console.WriteLine($"\nInserisci l'iva del {i + 1} prodotto:");
                //controllo sull'input dell'utente, se quello che è stato digitato non è un numero darà errore
                while (decimal.TryParse(Console.ReadLine(), out iva) == false)
                {
                    Console.WriteLine("Sintassi errata. Inserisci numero");
                }

                //inserisco alla posizione i del mio array l'oggetto prodotto con tutti i valori richiesti
                listaProdotti[i] = new Prodotto(nome, descrizione, prezzo, iva);
            }

            Console.WriteLine("\n\nLa lista dei prodotti sarà:");
            for (int i = 0; i < listaProdotti.Length; i++)
            {
                // Test dei metodi
                Console.WriteLine($"\nPosizione: {i+1}");
                Console.WriteLine("Codice: " + listaProdotti[i].CodiceFormat());
                Console.WriteLine("Nome: " + listaProdotti[i].Nome);
                Console.WriteLine("Descrizione: " + listaProdotti[i].Descrizione);
                Console.WriteLine("Prezzo base: " + listaProdotti[i].PrezzoBase() + " \u20AC");
                Console.WriteLine("Prezzo con IVA: " + listaProdotti[i].PrezzoConIVA() + " \u20AC");
                Console.WriteLine("Nome esteso: " + listaProdotti[i].NomeEsteso());

            }


            //funzione settare la grandezza del il mio array 
            Prodotto[] Population( int number)
            {
                return new Prodotto[number];
            }

            Console.ReadKey();
        }
    }
}
