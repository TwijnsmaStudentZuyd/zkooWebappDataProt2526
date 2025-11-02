using Microsoft.IdentityModel.Tokens;

namespace zkooWebserver.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public string Date { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Appointment other)
            {
                return other.AppointmentId == this.AppointmentId;
            }
            return base.Equals(obj);
        }

        public static bool operator ==(Appointment left, Appointment right) => 
            left.AppointmentId == right.AppointmentId;
        public static bool operator !=(Appointment left, Appointment right) =>
            left.AppointmentId != right.AppointmentId;

    }
}
