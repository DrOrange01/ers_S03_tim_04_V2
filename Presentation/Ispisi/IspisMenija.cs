using Domain.Modeli;
using Domain.Repozitorijumi;
using Domain.Servisi;
using Presentation.Ispisi;
using Services.DistributionCenterServisi;
using Services.LoggerServisi;
using Services.RepozitorijumServisi;
using Services.UredjajServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Meni
{
    public class IspisMenija
    {
        private readonly Consumer _consumer;
        DistributionCenterServis _distributionCenter = new DistributionCenterServis();
        UkljuciUredjajServis _ukljuciUredjaj = new UkljuciUredjajServis();
        IskljuciUredjajServis _iskljuciUredjaj = new IskljuciUredjajServis();
        ObrisiUredjajServis _obrisiUredjaj = new ObrisiUredjajServis();
        ILogServis _logger = new FileLoggerServis("KorisnikLog.txt");
        IRepository<Consumer> _userRepository;

        public IspisMenija(Consumer consumer, GenericRepository<Consumer> userRepository)
        {
            _consumer = consumer;
            _userRepository = userRepository;
        }
        public void PrikaziMeni()
        {
            IspisUredjaja ispis = new IspisUredjaja(_consumer); ;
            bool kraj = false;
            while(!kraj)
            {
                Console.WriteLine("\n 1. Prikazi uredjaje\n 2. Ukljuci/iskljuci uredjaj\n 3. Dodaj uredjaj\n 4. Obrisi uredjaj\n 5. Obrisi korisnika\n 6. Odjavi se");
                Console.Write("Opcija: ");
                string? opcija = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcija))
                    continue;

                switch (opcija[0])
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine($"User: {_consumer.Name}");
                        ispis.PrikaziUredjaje();
                        break;
                    case '2':
                        Console.WriteLine("Izaberite uredjaj koji zelite da ukljucite/iskljucite: ");
                        string ukljucenUredjaj = Console.ReadLine() ?? "";
                        Console.Clear();
                        foreach (var uredjajj in _consumer.uredjaji)
                        {
                            if(uredjajj.Naziv.ToLower().Equals(ukljucenUredjaj.ToLower()))
                            {
                                if (!uredjajj.Ukljucen)
                                {
                                    if(_ukljuciUredjaj.UkljuciUredjaj(uredjajj))
                                    {
                                        _consumer.UkupnaPotrosnja += uredjajj.Potrosnja;
                                    }
                                }
                                else
                                {
                                    if(_iskljuciUredjaj.IskljuciUredjaj(uredjajj))
                                    {
                                        _consumer.UkupnaPotrosnja -= uredjajj.Potrosnja;
                                    }
                                }
                                double cena = _distributionCenter.PosaljiZahtev(_consumer.UkupnaPotrosnja, _consumer);
                                Console.WriteLine($"Vasa potrosnja je: {_consumer.UkupnaPotrosnja}, i to ce vas kostati: {cena}");
                                
                                PorukaUDatoteci poruka = new UredjajPoruka(DateTime.Now, uredjajj.Naziv,_consumer.Name, uredjajj.Ukljucen);
                                _logger.Loguj(poruka.ToString()?? "");
                                goto EndOfCase;
                            }
                        }
                        Console.WriteLine($"Uredjaj {ukljucenUredjaj} ne postoji");
                        goto EndOfCase;
                        EndOfCase:
                            break;
                    case '3':
                        Console.Clear();
                        string uredjaj;
                        do
                        {
                            Console.WriteLine("Unesite naziv uredjaja (Enter za kraj unosa):");
                            uredjaj = Console.ReadLine() ?? "";

                            if (!string.IsNullOrWhiteSpace(uredjaj))
                            {
                                _consumer.uredjaji.Add(new Uredjaji(Guid.NewGuid(), uredjaj, 5));
                                Console.WriteLine($"Uredjaj '{uredjaj}' uspesno dodat.");
                            }

                        } while (!string.IsNullOrWhiteSpace(uredjaj));
                        Console.WriteLine("Unos uređaja zavrsen.");
                        break;
                    case '4':
                        Console.WriteLine("Izaberite uredjaj koji zelite da izbrisete: ");
                        string naziv = Console.ReadLine() ?? "";
                        Console.Clear();
                        if (_obrisiUredjaj.ObrisiUredjaj(_consumer, naziv))
                        {
                            Console.WriteLine($"Uredjaj {naziv} je uspesno obrisan");
                        }
                        else
                        {
                            Console.WriteLine($"Uredjaj {naziv} ne postoji");
                        }
                            break;
                    case '5':
                        Console.Clear();
                        _userRepository.Delete(_consumer.Id);
                        Console.WriteLine("Uspesno ste izbrisali svoj nalog!");
                        kraj = true;
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("Uspesno ste se odjavili!");
                        kraj = true;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
