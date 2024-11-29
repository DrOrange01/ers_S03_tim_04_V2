using Domain.Modeli;
using Domain.Repozitorijumi;
using Services.RepozitorijumServisi;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Consumer> userRepository = new GenericRepository<Consumer>();
            IRepository<Uredjaji> deviceRepository = new GenericRepository<Uredjaji>();

            //ovo ce biti prebaceno u prezentaciju{
            //opcija add consumer
            string name;
            do
            {
                Console.Write($"Unesite ime korisnika: ");
                name = Console.ReadLine();
            } while( name == "" );
            
            var korisnik = new Consumer( 1, name, 0);

            userRepository.Add( korisnik );
            //opcija add uredjaj
            string uredjaj;
            do
            {
                Console.Write($"Unesite naziv uredjaja: ");
                uredjaj = Console.ReadLine();
            } while (uredjaj == "");
            korisnik.uredjaji.Add(new Uredjaji(1, uredjaj, 5));

            //opcija prikazi uredjaje za korisnika
            Console.WriteLine($"User: {korisnik.Name}");
            foreach (var uredjajj in korisnik.uredjaji)
            {
                Console.WriteLine($" - Device: {uredjajj.Naziv}, In Use: {uredjajj.Ukljucen}");
            }
            //}
        }
    }
}
