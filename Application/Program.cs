using Domain.Modeli;
using Domain.Repozitorijumi;
using Presentation.Ispisi;
using Presentation.Meni;
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



            //opcija prikazi uredjaje za korisnika
            IspisMenija meni = new IspisMenija(korisnik);
            meni.PrikaziMeni();
            
        }
    }
}
