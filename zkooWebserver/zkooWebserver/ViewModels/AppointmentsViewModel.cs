using zkooWebserver.Models;

namespace zkooWebserver.ViewModels
{
    public class AppointmentsViewModel
    {
        public ICollection<Appointment> Appointments { get; set; }
    }
}
