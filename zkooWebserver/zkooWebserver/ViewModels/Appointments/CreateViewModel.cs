using zkooWebserver.Models;

namespace zkooWebserver.ViewModels.Appointments
{
    public class CreateViewModel
    {
        public string Patient { get; set; }
        public string Doctor { get; set; }

        public string Date { get; set; }
    }
}
