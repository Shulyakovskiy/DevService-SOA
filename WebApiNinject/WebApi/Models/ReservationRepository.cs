using System.Collections.Generic;
using System.Linq;

namespace WebApi.Models
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly List<Reservation> _data = new List<Reservation>
        {
            new Reservation {ReservationId = 1, ClientName = "Adam", Location = "London"},
            new Reservation {ReservationId = 2, ClientName = "Steve", Location = "Paris"},
            new Reservation {ReservationId = 3, ClientName = "Jane", Location = "New York"}
        };

        public IEnumerable<Reservation> GetAll()
        {
            return _data;
        }

        public Reservation Get(int id)
        {
            var matches = _data.Where(r => r.ReservationId == id);
            return matches.Count() > 0 ? matches.First() : null;
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = _data.Count + 1;
            _data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
                _data.Remove(item);
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }
              return false;
        }
    }
}