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
            //opcija add uredjaj
            string uredjaj;
            do
            {
                Console.Write($"Unesite naziv uredjaja: ");
                uredjaj = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(uredjaj));
            korisnik.uredjaji.Add(new Uredjaji(Guid.NewGuid(), uredjaj, 5));

            //opcija prikazi uredjaje za korisnika
            Console.WriteLine($"User: {korisnik.Name}");
            foreach (var uredjajj in korisnik.uredjaji)
            {
                Console.WriteLine($" - Device: {uredjajj.Naziv}, In Use: {uredjajj.Ukljucen}");
            }
            
        }
    }
}
