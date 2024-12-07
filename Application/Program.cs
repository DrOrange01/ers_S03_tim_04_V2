using Domain.Modeli;
using Domain.Repozitorijumi;
using Presentation.Ispisi;
using Presentation.Izbor;
using Presentation.Meni;
using Services.RepozitorijumServisi;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            GenericRepository<Consumer> userRepository = new GenericRepository<Consumer>();

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

            IspisMenija meni = new IspisMenija(korisnik, userRepository);
            meni.PrikaziMeni();
            
        }
    }
}
