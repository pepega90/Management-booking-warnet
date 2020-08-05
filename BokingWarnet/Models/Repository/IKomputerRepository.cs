using BokingWarnet.Models.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models
{
    public interface IKomputerRepository
    {
        Komputer AddKomputer(Komputer komputer);
        IEnumerable<Komputer> GetAllKomputer();

        Komputer EditKomputer(Komputer komputer);

        void HapusKomputer(int Id);

        Komputer FindKomputerById(int Id);
    }
}
