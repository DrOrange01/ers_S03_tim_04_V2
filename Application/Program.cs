using Domain.Modeli;
using Domain.Repozitorijumi;
using Presentation.Ispisi;
using Presentation.Izbor;
using Presentation.Meni;
using Services.RepozitorijumServisi;
using System.Timers;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var consumer = new Consumer();
            GenericRepository<Consumer> userRepository = new GenericRepository<Consumer>();
            IRepository<Uredjaji> deviceRepository = new GenericRepository<Uredjaji>();

            //ovo ce biti prebaceno u prezentaciju{

            //opcija add consumer
            string name;
            do
            {
                Console.Write($"Unesite ime korisnika: ");
                name = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(name));

            IzborKorisnika izbor = new IzborKorisnika(userRepository);
            Consumer korisnik;
            int provera = izbor.ProveriKorisnika(name);
            if (provera != -1)
            {
                korisnik = izbor._consumers[provera];
            }
            else
            {
                korisnik = new Consumer(Guid.NewGuid(), name, 0);
            }
            userRepository.Add( korisnik );

            //opcija add uredjaj, moguce dodavanje vise uredjaja



            //opcija prikazi uredjaje za korisnika
            IspisMenija meni = new IspisMenija(korisnik, userRepository);
            meni.PrikaziMeni();
            
        }
    }
}
