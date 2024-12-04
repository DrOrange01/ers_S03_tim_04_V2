using Domain.Modeli;
using Presentation.Ispisi;
using Services.DistributionCenterServisi;
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

        public IspisMenija(Consumer consumer)
        {
            _consumer = consumer;
        }
        public void PrikaziMeni()
        {
            bool kraj = false;
            while(!kraj)
            {
                Console.WriteLine("\n - 1. Prikazi uredjaje\n - 2. Ukljuci/iskljuci uredjaj\n - 3. Dodaj uredjaj\n - 4. Obrisi uredjaj\n - 5. Obrisi korisnika\n - 6. Odjavi se");
                Console.Write("Opcija: ");
                string? opcija = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(opcija))
                    continue;

                switch (opcija[0])
                {
                    case '1':
                        Console.WriteLine($"User: {_consumer.Name}");
                        IspisUredjaja ispis = new IspisUredjaja(_consumer);
                        ispis.PrikaziUredjaje();
                        break;
                    case '2':
                        Console.WriteLine("Izaberite uredjaj koji zelite da ukljucite/iskljucite: ");
                        string? ukljucenUredjaj = Console.ReadLine();
                        foreach (var uredjajj in _consumer.uredjaji)
                        {
                            if(uredjajj.Naziv.ToLower().Equals(ukljucenUredjaj.ToLower()))
                            {
                                if (!uredjajj.Ukljucen)
                                {
                                    bool da = _ukljuciUredjaj.UkljuciUredjaj(uredjajj);
                                    if(da)
                                    {
                                        _consumer.UkupnaPotrosnja += uredjajj.Potrosnja;
                                    }
                                }
                                else
                                {
                                    bool ne = _iskljuciUredjaj.IskljuciUredjaj(uredjajj);
                                    if(ne)
                                    {
                                        _consumer.UkupnaPotrosnja -= uredjajj.Potrosnja;
                                    }
                                }
                            }
                        }
                        double cena = _distributionCenter.PosaljiZahtev(_consumer.UkupnaPotrosnja, _consumer);
                        Console.WriteLine($"Vasa potrosnja je: {_consumer.UkupnaPotrosnja}, i to ce vas kostati: {cena}");
                        break;
                    case '3':
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
                        //obrisi uredjaj
                        break;
                    case '5':
                        //obrisi korisnika
                        break;
                    case '6':
                        kraj = true;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
