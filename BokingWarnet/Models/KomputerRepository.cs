using BokingWarnet.Models.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models
{
    public class KomputerRepository : IKomputerRepository
    {
        private readonly AppDbContext db;

        public KomputerRepository(AppDbContext db)
        {
            this.db = db;
        }

        public Komputer AddKomputer(Komputer komputer)
        {
            db.Komputers.Add(komputer);
            db.SaveChanges();
            return komputer;

        }

        public Komputer EditKomputer(Komputer komputer)
        {
            db.Komputers.Update(komputer);
            //EditedKomputer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return komputer;
        }

        public Komputer FindKomputerById(int Id)
        {
            Komputer komputer = db.Komputers.Find(Id);
            return komputer;
        }

        public IEnumerable<Komputer> GetAllKomputer()
        {
            return db.Komputers.Include(e => e.OrangBookings);
        }

        public void HapusKomputer(int Id)
        {
            var komputer = db.Find<Komputer>(Id);
            db.Komputers.Remove(komputer);
            db.SaveChanges();
        }

    }
}
