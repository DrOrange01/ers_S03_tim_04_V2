using Domain.Modeli;
using Domain.Repozitorijumi;
using Services.RepozitorijumServisi;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var consumer = new Consumer();
            IRepository<Consumer> userRepository = new GenericRepository<Consumer>();
            IRepository<Uredjaji> deviceRepository = new GenericRepository<Uredjaji>();

            //ovo ce biti prebaceno u prezentaciju{

            //opcija add consumer
            string name;
            do
            {
                Console.Write($"Unesite ime korisnika: ");
                name = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(name));
            
            var korisnik = new Consumer( Guid.NewGuid(), name, 0);
            userRepository.Add( korisnik );

            //opcija add uredjaj, moguce dodavanje vise uredjaja
            string uredjaj;
            do
            {
                Console.WriteLine("Unesite naziv uredjaja (Enter za kraj unosa):");
                uredjaj = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(uredjaj))
                {
                    korisnik.uredjaji.Add(new Uredjaji(Guid.NewGuid(), uredjaj, 5));
                    Console.WriteLine($"Uredjaj '{uredjaj}' uspesno dodat.");
                }

            } while (!string.IsNullOrWhiteSpace(uredjaj));

            Console.WriteLine("Unos uređaja zavrsen.");


            //opcija prikazi uredjaje za korisnika
            Console.WriteLine($"User: {korisnik.Name}");
            foreach (var uredjajj in korisnik.uredjaji)
            {
                Console.WriteLine($" - Device: {uredjajj.Naziv}, In Use: {uredjajj.Ukljucen}");
            }
            
        }
    }
}
