using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController()
        {
            _reservationRepository = new ReservationRepository();
        }
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public IEnumerable<Reservation> GetAllReservation()
        {
            return _reservationRepository.GetAll();
        }

        [HttpGet]
        public Reservation GetReservation(int id)
        {
            return _reservationRepository.Get(id);
        }

        [HttpPost]
        public Reservation PostReservation(Reservation item)
        {
            return _reservationRepository.Add(item);
        }

        [HttpPut]
        public bool PutReservation(Reservation item)
        {
            return _reservationRepository.Update(item);
        }

        [HttpDelete]
        public void DeleteReservation(int id)
        {
            _reservationRepository.Remove(id);
        }
    }
}
